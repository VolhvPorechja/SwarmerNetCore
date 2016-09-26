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

namespace SwarmerServer.Controllers
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
            public static string Login { get; } = "AU001";
            public static string Logout { get; } = "AU002";
            public static string Signup { get; } = "AU003";
            public static string PreSignup { get; } = "AU004";
        }

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private readonly AccountsManagementCore mCore;
        private readonly LogMessagesManager mLogMessManager;
        private readonly string mReferenceId;
        private readonly IConfigurationRoot mConfig;
        private readonly SignUpActivationProviderContract mSignupDataProvider;

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
            mLogMessManager = logMessManager;
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
            Logger.Info(mLogMessManager.Log("", Codes.Login, "User login.", mReferenceId,
                new { request.Id }));

            var result = mCore.AuthenticationApi.Authenticate(request);
            if (result.IsSuccess)
                Response.Cookies.Append(mConfig["service:cookie-key"], Guid.NewGuid().ToString("n"));

            return new ObjectResult(result);
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
            Logger.Info(mLogMessManager.Log("", Codes.Logout, "User logout.", mReferenceId));
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
        [Route("/singup")]
        [SwaggerOperation("SingUp")]
        [SwaggerResponse(200, type: typeof(SingUpResponse))]
        public virtual IActionResult SingUp([FromBody] SingUpRequest request)
        {
            Logger.Info(mLogMessManager.Log("", Codes.Signup, "User signup.", mReferenceId,
                new { request }));

            var signupData = mSignupDataProvider.GetSignUpData(request.ActivationKey);

            var createdUser = mCore.UsersApi.CreateUser(new User
            {
                Login = request.Data.Login,
                Email = signupData.Email,
                Country = request.Data.Country,
                Gender = request.Data.Gender,
                BirthDate = request.Data.BirthDate,
                FirstName = request.Data.FirstName,
                SecondName = request.Data.SecondName,
                TimeZone = request.Data.TimeZone
            });
            mCore.UsersApi.AddAuthenticationData(createdUser, UsersApi.LoginTypes.LoginPassword, request.Password);

            return new ObjectResult(new SingUpResponse());
        }

        /// <summary>
        /// Prepare new sing up with
        /// </summary>
        /// <remarks>Method for registering new user in system.</remarks>
        /// <param name="request">Singup info.</param>
        /// <response code="200">Data for make decisions on successfull user login.</response>
        /// <response code="0">Unexpected error</response>
        [HttpPost]
        [Route("/presingup")]
        [SwaggerOperation("PreSingUp")]
        [SwaggerResponse(200, type: typeof(PreSingUpResponse))]
        public virtual IActionResult PreSingUp([FromBody] PreSignUpRequest request)
        {
            Logger.Info(mLogMessManager.Log("", Codes.PreSignup, "User presign up.", mReferenceId,
                new { request }));

            var result = mCore.AuthenticationApi.PreSingUp(request);

            if (result.IsSuccessful)
            {
                var signupKey = mSignupDataProvider.StoreSignUpData(new SignUpData
                {
                    Login = request.Login,
                    Email = request.Email
                });

                result.Url += $"?sk={signupKey}";
            }

            return new ObjectResult(result);
        }
    }
}