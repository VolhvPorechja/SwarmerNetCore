using System;
using Microsoft.AspNetCore.Mvc;
using NLog;
using Swarmer.AM.Contracts.Domain;
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
        }

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly AccountsManagementCore mCore;
        private readonly LogMessagesManager mLogMessManager;
        private readonly string mReferenceId;

        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="core"></param>
        /// <param name="logMessManager"></param>
        public AuthenticationApi(AccountsManagementCore core, LogMessagesManager logMessManager)
        {
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
                new {request.Id}));

            return new ObjectResult(mCore.AuthenticationApi.Authenticate(request));
        }
        
        /// <summary>
        /// Logout user.
        /// </summary>
        /// <remarks>This method returns data that can be user in decisions making 
        /// after success user login (redirect url, message, etc.). </remarks>
        /// <param name="request">Authentication info.</param>
        /// <response code="200">Data for make decisions on successfull user login.</response>
        /// <response code="0">Unexpected error</response>
        [HttpPost]
        [Route("/logout")]
        [SwaggerOperation("Logout")]
        [SwaggerResponse(200, type: typeof(LogoutResponse))]
        public virtual IActionResult Logout([FromBody] LogoutRequest request)
        {
            Logger.Info(mLogMessManager.Log("", Codes.Logout, "User logout.", mReferenceId,
                new {request.Id}));

            return new ObjectResult(mCore.AuthenticationApi.Logout(request));
        }
    }
}