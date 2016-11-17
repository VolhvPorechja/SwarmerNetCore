using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NLog;
using Swarmer.AM.Contracts.Contracts;
using Swarmer.AM.Contracts.Domain;
using Swarmer.AM.Contracts.Providers;
using Swarmer.AM.Contracts.Providers.Contracts;
using Swarmer.AM.Core;
using Swarmer.Common.Logging;
using Swashbuckle.SwaggerGen.Annotations;

namespace Swarmer.AM.Service.Controllers
{
    /// <summary>
    /// Api of authentication.
    /// </summary>
    public class AuthenticationApi : Controller
    {
        /// <summary>
        /// Static class that contains events types codes.
        /// </summary>
        public static class Codes
        {
            private const string SystemCode = "AU-";

            public static string Login { get; } = SystemCode + "LOGIN";
            public static string Logout { get; } = SystemCode + "LOGOUT";
            public static string Signup { get; } = SystemCode + "SIGNUP";
            public static string PreSignup { get; } = SystemCode + "PRESIGNUP";
        }

        private static readonly Logger ClassLogger = LogManager.GetCurrentClassLogger();

        private readonly AccountsManagementCore mCore;
        private readonly string mReferenceId;
        private readonly IConfigurationRoot mConfig;
        private readonly SignUpActivationProviderContract mSignupDataProvider;
        private readonly SystemLogger mLogger;

        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="core"></param>
        /// <param name="logMessManager"></param>
        /// <param name="signupDataProvider"></param>
        /// <param name="config"></param>
        public AuthenticationApi(AccountsManagementCore core,
            LogMessagesManager logMessManager,
            SignUpActivationProviderContract signupDataProvider,
            IConfigurationRoot config)
        {
            mSignupDataProvider = signupDataProvider;
            mConfig = config;
            mLogger = new SystemLogger(ClassLogger, logMessManager);
            mCore = core;
            mReferenceId = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Login user.
        /// </summary>
        /// <remarks>This method returns data that can be user in decisions making 
        /// after success user login (redirect url, message, etc.). </remarks>
        /// <param name="request">Authentication info.</param>
        /// <response code="200">Data for make decisions on successfull user login.</response>
        /// <response code="0">Unexpected error</response>
        [HttpPost]
        [Route("/login")]
        [SwaggerOperation("Login")]
        [SwaggerResponse(200, type: typeof(AuthResponse))]
        public virtual IActionResult Login([FromBody] AuthRequest request)
        {
            mLogger.Info("", Codes.Login, "User login attempt.", mReferenceId, new {request.Id});

            try
            {
                var result = mCore.AuthenticationApi.Authenticate(request);
                if (result.IsSuccess)
                    Response.Cookies.Append(mConfig["service:cookie-key"], Guid.NewGuid().ToString("n"));

                mLogger.Info("", Codes.Login, "User login success.", mReferenceId, new {request.Id});
                return new ObjectResult(result);
            }
            catch (NotValidRequestException exception)
            {
                mLogger.Info("SomeUser", Codes.Login, "Login error", mReferenceId, new { request.Id });
                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Logout user.
        /// </summary>
        /// <remarks>This method returns data that can be user in decisions making 
        /// after success user login (redirect url, message, etc.). </remarks>
        /// <response code="200">Data for make decisions on successfull user login.</response>
        /// <response code="0">Unexpected error</response>
        [HttpGet]
        [Route("/logout")]
        [SwaggerOperation("Logout")]
        [SwaggerResponse(200, type: typeof(LogoutResponse))]
        public virtual IActionResult Logout()
        {
            // TODO Logout from system
            mLogger.Info("", Codes.Logout, "User logout.", mReferenceId);
            return new ObjectResult(mCore.AuthenticationApi.Logout(new LogoutRequest()));
        }

        /// <summary>
        /// Sing up new user.
        /// </summary>
        /// <remarks>Method for registering new user in system.</remarks>
        /// <param name="request">Singup info.</param>
        /// <response code="200">Data for make decisions on successfull user login.</response>
        /// <response code="0">Unexpected error</response>
        [HttpPost]
        [Route("/signup")]
        [SwaggerOperation("SignUp")]
        [SwaggerResponse(200, type: typeof(SingUpResponse))]
        public virtual IActionResult SignUp([FromBody] SingUpRequest request)
        {
            mLogger.Info("", Codes.Signup, "User signup attempt.", mReferenceId,
                new {request});

            try
            {
                if (string.IsNullOrEmpty(request?.ActivationKey))
                    throw new NotValidRequestException(request == null ? "Emtpy request." : "Activation key not setted.");

                var signupData = mSignupDataProvider.GetSignUpData(request.ActivationKey);

                if(signupData == null)
                    throw new NotValidRequestException("Not valid");

                var createdUser = mCore.UsersApi.CreateUser(new User
                {
                    Login = request.Data?.Login,
                    Email = signupData.Email,
                    Country = request.Data?.Country,
                    Gender = request.Data?.Gender,
                    BirthDate = request.Data?.BirthDate,
                    FirstName = request.Data?.FirstName,
                    SecondName = request.Data?.SecondName,
                    TimeZone = request.Data?.TimeZone
                });
                mCore.UsersApi.AddAuthenticationData(createdUser, UsersApi.LoginTypes.LoginPassword, request.Password);

                mLogger.Info("", Codes.Signup, "User signup success.", mReferenceId,
                    new {request});
                return new ObjectResult(new SingUpResponse());

            }
            catch (NotValidRequestException exception)
            {
                mLogger.Info("SomeUser", Codes.Login, "Login error", mReferenceId);
                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Prepare new sing up with
        /// </summary>
        /// <remarks>Method for registering new user in system.</remarks>
        /// <param name="request">Singup info.</param>
        /// <response code="200">Data for make decisions on successfull user login.</response>
        /// <response code="0">Unexpected error</response>
        [HttpPost]
        [Route("/presignup")]
        [SwaggerOperation("PreSignUp")]
        [SwaggerResponse(200, type: typeof(PreSingUpResponse))]
        public virtual IActionResult PreSingUp([FromBody] PreSignUpRequest request)
        {
            mLogger.Info("", Codes.PreSignup, "User presign up.", mReferenceId,
                new { request });

            var result = mCore.AuthenticationApi.PreSingUp(request);

            if (result.IsSuccess)
            {
                var signupKey = mSignupDataProvider.StoreSignUpData(new SignUpData
                {
                    Login = request.Login,
                    Email = request.Email
                });

                result.Url += $"?sk={signupKey}&l={request.Login}";
            }

            return new ObjectResult(result);
        }
    }
}