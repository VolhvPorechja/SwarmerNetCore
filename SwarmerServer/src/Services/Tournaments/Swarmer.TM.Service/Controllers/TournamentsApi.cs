using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
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

        #region Tournaments

        /// <summary>
        /// Create new tournament.
        /// </summary>
        /// <remarks>During call new tournament will be created. </remarks>
        /// <param name="request">Request on tournament creation.</param>
        /// <response code="200">Data of created tournament.</response>
        /// <response code="0">Unexpected error</response>
        [HttpPost]
        [Route("/tournament")]
        [SwaggerOperation("CreateTournament")]
		[SwaggerResponse(200, type: typeof(Tournament))]
        public virtual IActionResult CreateTournament([FromBody] TournamentCreationRequest request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get tournament data.
        /// </summary>
        /// <remarks>Get tournament data by id. </remarks>
        /// <param name="tournamentId">Id of tournament.</param>
        /// <response code="200">Tournamen with given id.</response>
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
        /// Update tournament data.
        /// </summary>
        /// <remarks>Updated tournament data. </remarks>
        /// <param name="tournamentId">Id of updating tournament.</param>
        /// <param name="updatedTournamentData">Update tournament data.</param>
        /// <response code="200">Updated tournament data.</response>
        /// <response code="0">Unexpected error</response>
        [HttpPost]
        [Route("/tournament/{tournamentId}")]
        [SwaggerOperation("UpdateTournamentData")]
		[SwaggerResponse(200, type: typeof(Tournament))]
        public virtual IActionResult UpdateTournamentData([FromRoute] Guid tournamentId, [FromBody] TournamentUpdateRequest updatedTournamentData)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update tournament data.
        /// </summary>
        /// <remarks>Updated tournament aggregated stats. </remarks>
        /// <param name="tournamentId">Id of tournament.</param>
        /// <param name="stats">Updated aggregated tournament stats.</param>
        /// <response code="200">Updated tournament data.</response>
        /// <response code="0">Unexpected error</response>
        [HttpPost]
        [Route("/tournament/{tournamentId}/stats")]
        [SwaggerOperation("UpdateTournamentData")]
		[SwaggerResponse(200, type: typeof(Tournament))]
        public virtual IActionResult UpdateTournamentStats([FromRoute] Guid tournamentId, [FromBody] JObject stats)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Invites

        /// <summary>
        /// Get all tournament invites.
        /// </summary>
        /// <remarks>Get all created tournament invites. </remarks>
        /// <param name="tournamentId"></param>
        /// <response code="200">Tournament invites.</response>
        /// <response code="0">Unexpected error</response>
        [HttpGet]
        [Route("/tournament/{tournamentId}/invite")]
        [SwaggerOperation("GetTournamentInvites")]
		[SwaggerResponse(200, type: typeof(List<TournamentInvite>))]
        public virtual IActionResult GetTournamentInvites([FromRoute] Guid tournamentId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get all tournament invites.
        /// </summary>
        /// <remarks>Get all created tournament invites. </remarks>
        /// <param name="userid"></param>
        /// <response code="200">Tournament invites.</response>
        /// <response code="0">Unexpected error</response>
        [HttpGet]
        [Route("/tournament/invites/users/{userid}")]
        [SwaggerOperation("GetTournamentInvites")]
		[SwaggerResponse(200, type: typeof(List<TournamentInvite>))]
        public virtual IActionResult GetUserInvites([FromRoute] Guid userid)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get all tournament invites.
        /// </summary>
        /// <remarks>Get all created tournament invites. </remarks>
        /// <param name="teamid"></param>
        /// <response code="200">Tournament invites.</response>
        /// <response code="0">Unexpected error</response>
        [HttpGet]
        [Route("/tournament/invites/teams/{teamid}")]
        [SwaggerOperation("GetTournamentInvites")]
        [SwaggerResponse(200, type: typeof(List<TournamentInvite>))]
        public virtual IActionResult GetTeamInvites([FromRoute] Guid teamid)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get all tournament invites.
        /// </summary>
        /// <remarks>Get all created tournament invites. </remarks>
        /// <param name="joinRequest"></param>
        /// <response code="200">Tournament invites.</response>
        /// <response code="0">Unexpected error</response>
        [HttpPost]
        [Route("/tournament/join")]
        [SwaggerOperation("GetTournamentInvites")]
        public virtual IActionResult JoinTournament([FromBody] JoinTournamentRequest joinRequest)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create new tournament.
        /// </summary>
        /// <remarks>During call will be created. </remarks>
        /// <param name="tournamentId"></param>
        /// <param name="inviteId"></param>
        /// <response code="200">Tournament invite was successfully recalled.</response>
        /// <response code="0">Unexpected error</response>
        [HttpDelete]
        [Route("/tournament/{tournamentId}/invite/{inviteId}")]
        [SwaggerOperation("RecallTournamentInvite")]
        public virtual IActionResult RecallTournamentInvite([FromRoute] Guid tournamentId, [FromRoute] Guid inviteId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create tournament invite.
        /// </summary>
        /// <remarks>Create tournament player invite. </remarks>
        /// <param name="tournamentId">Id of tournament on which player will be invited.</param>
        /// <param name="inviteData">Invitation data.</param>
        /// <response code="200">Data for make decisions on successfull user login.</response>
        /// <response code="0">Unexpected error</response>
        [HttpPost]
        [Route("/tournament/{tournamentId}/invite")]
        [SwaggerOperation("CreateTournamentInvite")]
        public virtual IActionResult CreateTournamentInvite([FromRoute] Guid tournamentId, [FromBody] TournamentInvite inviteData)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Parties

        /// <summary>
        /// Get tournament parties.
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

        #endregion

        #region Games

        /// <summary>
        /// Get tournament games.
        /// </summary>
        /// <remarks>During call will be created. </remarks>
        /// <param name="tournamentId">Id of tournament.</param>
        /// <response code="200">Data for make decisions on successfull user login.</response>
        /// <response code="0">Unexpected error</response>
        [HttpGet]
        [Route("/tournament/{tournamentId}/game")]
        [SwaggerOperation("GetTournamentGames")]
        public virtual IActionResult GetTournamentGames([FromRoute] Guid tournamentId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get tournament games.
        /// </summary>
        /// <remarks>During call will be created. </remarks>
        /// <param name="tournamentId">Id of tournament.</param>
        /// <param name="gameId">Id of game that will be updated.</param>
        /// <response code="200">Data for make decisions on successfull user login.</response>
        /// <response code="0">Unexpected error</response>
        [HttpGet]
        [Route("/tournament/{tournamentId}/game/{gameId}")]
        [SwaggerOperation("GetTournamentGame")]
        public virtual IActionResult GetTournamentGame([FromRoute] Guid tournamentId, [FromRoute] Guid gameId)
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// Get tournament games.
        /// </summary>
        /// <remarks>During call will be created. </remarks>
        /// <param name="tournamentId">Id of tournament.</param>
        /// <param name="gameId">Id of game that will be updated.</param>
        /// <param name="updatedData">Updated game data.</param>
        /// <response code="200">Data for make decisions on successfull user login.</response>
        /// <response code="0">Unexpected error</response>
        [HttpPost]
        [Route("/tournament/{tournamentId}/game/{gameId}")]
        [SwaggerOperation("UpdateTournamentGameData")]
        public virtual IActionResult UpdateTournamentGameData([FromRoute] Guid tournamentId, [FromRoute] Guid gameId, [FromBody] Game updatedData)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
