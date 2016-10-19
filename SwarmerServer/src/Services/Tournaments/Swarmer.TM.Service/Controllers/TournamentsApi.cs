using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NLog;
using Swarmer.TM.Contracts.Contracts;
using Swarmer.TM.Contracts.Domain;
using Swashbuckle.SwaggerGen.Annotations;

namespace Swarmer.TM.Service.Controllers
{
    /// <summary>
    /// Api of authentication.
    /// </summary>
    public class TournamentsApi : Controller
    {
        /// <summary>
        /// Static class that contains events types codes.
        /// </summary>
        public static class Codes
        {
            public static string Login { get; } = "AU001";
        }

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private readonly IConfigurationRoot mConfig;
        private readonly string mReferenceId;

        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="config"></param>
        public TournamentsApi(
            IConfigurationRoot config)
        {
            mConfig = config;
            mReferenceId = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Create new tournament.
        /// </summary>
        /// <remarks>During call will be created. </remarks>
        /// <param name="request">Authentication info.</param>
        /// <response code="200">Data for make decisions on successfull user login.</response>
        /// <response code="0">Unexpected error</response>
        [HttpPost]
        [Route("/tournament")]
        [SwaggerOperation("CreateTournament")]
        public virtual IActionResult CreateTournament([FromBody] TournamentCreationRequest request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get tournament.
        /// </summary>
        /// <remarks>During call will be created. </remarks>
        /// <param name="tournamentId">Get tournament by id.</param>
        /// <response code="200">Data for make decisions on successfull user login.</response>
        /// <response code="0">Unexpected error</response>
        [HttpGet]
        [Route("/tournament/{tournamentId}")]
        [SwaggerOperation("GetTournament")]
		[SwaggerResponse(200, type: typeof(Tournament))]
        public virtual IActionResult GetTournament([FromRoute] Guid tournamentId)
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// Get tournament.
        /// </summary>
        /// <remarks>During call will be created. </remarks>
        /// <param name="tournamentId">Get tournament by id.</param>
        /// <response code="200">Data for make decisions on successfull user login.</response>
        /// <response code="0">Unexpected error</response>
        [HttpGet]
        [Route("/tournament/{tournamentId}/party")]
        [SwaggerOperation("GetTournamentParties")]
        public virtual IActionResult GetTournamentParties([FromRoute] Guid tournamentId)
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// Get tournament.
        /// </summary>
        /// <remarks>During call will be created. </remarks>
        /// <param name="tournamentId">Id of tournament where party will be created.</param>
        /// <response code="200">Data for make decisions on successfull user login.</response>
        /// <response code="0">Unexpected error</response>
        [HttpGet]
        [Route("/tournament/{tournamentId}/party")]
        [SwaggerOperation("CreateTournamentParty")]
        public virtual IActionResult CreateTournamentParty([FromRoute] Guid tournamentId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get tournament.
        /// </summary>
        /// <remarks>During call will be created. </remarks>
        /// <param name="tournamentId">Id of tournament.</param>
        /// <param name="partyId">Id of getting party.</param>
        /// <response code="200">Data for make decisions on successfull user login.</response>
        /// <response code="0">Unexpected error</response>
        [HttpGet]
        [Route("/tournament/{tournamentId}/party/{partyId}")]
        [SwaggerOperation("GetTournamentParty")]
        public virtual IActionResult GetTournamentParty([FromRoute] Guid tournamentId, [FromRoute] Guid partyId)
        {
            throw new NotImplementedException();
        }


    }
}
