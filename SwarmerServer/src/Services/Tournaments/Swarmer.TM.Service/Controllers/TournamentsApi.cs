using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using NLog;
using Swarmer.Common.Logging;
using Swarmer.TM.Contracts.Contracts;
using Swarmer.TM.Contracts.Domain;
using Swarmer.TM.Core;
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
            private const string SystemCode = "TN-";

            public static string TournamentCreation { get; } = SystemCode + "TOURNAMENT-CREATE";
            public static string TournamentDeletion { get; } = SystemCode + "TOURNAMENT-DELETE";
            public static string TournamentUpdate { get; } = SystemCode + "TOURNAMENT-UPDATE";
            public static string TournamentStasUpdated { get; } = SystemCode + "TOURNAMENT-STATSUPDATE";
            public static string TournamentGridUpdated { get; } = SystemCode + "TOURNAMENT-GRIDUPDATE";
            public static string InviteRecall { get; } = SystemCode + "PLAYER-DEINVITE";
            public static string PlayerJoined { get; } = SystemCode + "PLAYER-JOIN";
            public static string PlayerOrTeamInvited { get; } = SystemCode + "PLAYER-INVITE";
        }

        private static readonly Logger ClassLogger = LogManager.GetCurrentClassLogger();

        private readonly IConfigurationRoot mConfig;
        private readonly string mReferenceId;
        private readonly SystemLogger mLogger;
        private readonly TournamentsManagementCore mCore;

        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="config">Common service configuration.</param>
        /// <param name="core">Service core.</param>
        /// <param name="logMessagesManager">Log messages manager.</param>
        public TournamentsApi(IConfigurationRoot config,
            TournamentsManagementCore core,
            LogMessagesManager logMessagesManager)
        {
            mCore = core;
            mConfig = config;
            mLogger = new SystemLogger(ClassLogger, logMessagesManager);
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
            mLogger.Info("", Codes.TournamentCreation, "Tournament creation attempt", mReferenceId, request);

            var createdTournament = mCore.TournamentsApi.CreateTournament(request);

            mLogger.Info("", Codes.TournamentCreation, "Tournament created", mReferenceId);
            return new ObjectResult(createdTournament);
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
            return new ObjectResult(mCore.TournamentsApi.GetTournament(tournamentId));
        }

        /// <summary>
        /// Delete tournament.
        /// </summary>
        /// <remarks>Get tournament data by id. </remarks>
        /// <param name="tournamentId">Id of tournament.</param>
        /// <response code="200">Tournamen with given id.</response>
        /// <response code="0">Unexpected error</response>
        [HttpDelete]
        [Route("/tournament/{tournamentId}")]
        [SwaggerOperation("DeleteTournament")]
        [SwaggerResponse(200, type: typeof(Tournament))]
        public virtual IActionResult DeleteTournament([FromRoute] Guid tournamentId)
        {
            mLogger.Info("", Codes.TournamentDeletion, "Tournament creation attempt", mReferenceId, new { tournamentId });
            mCore.TournamentsApi.DeleteTournament(tournamentId);
            mLogger.Info("", Codes.TournamentDeletion, "Tournament delete success", mReferenceId);

            return Ok();
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
            mLogger.Info("", Codes.TournamentUpdate, "Tournament update attempt", mReferenceId,
                new {tournamentId, updatedTournamentData});

            var updatedTournament = mCore.TournamentsApi.UpdateTournament(tournamentId, updatedTournamentData);

            mLogger.Info("", Codes.TournamentUpdate, "Tournament update success", mReferenceId);

            return new ObjectResult(updatedTournament);
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
        [SwaggerOperation("UpdateTournamentStats")]
        public virtual IActionResult UpdateTournamentStats([FromRoute] Guid tournamentId, [FromBody] JObject stats)
        {
            mLogger.Info("", Codes.TournamentStasUpdated, "Tournament stats update attempt", mReferenceId,
                new { tournamentId, stats });

            mCore.TournamentsApi.UpdateTournamentStats(tournamentId, stats);

            mLogger.Info("", Codes.TournamentStasUpdated, "Tournament stats update success", mReferenceId);

            return Ok();
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
        [SwaggerResponse(200, type: typeof(IEnumerable<TournamentInvite>))]
        public virtual IActionResult GetTournamentInvites([FromRoute] Guid tournamentId)
        {
            return new ObjectResult(mCore.TournamentsApi.GetTournamentInvites(tournamentId));
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
        [SwaggerOperation("GetUserInvites")]
        [SwaggerResponse(200, type: typeof(IEnumerable<TournamentInvite>))]
        public virtual IActionResult GetUserInvites([FromRoute] Guid userid)
        {
            return new ObjectResult(mCore.TournamentsApi.GetUserInvites(userid));
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
        [SwaggerOperation("GetTeamInvites")]
        [SwaggerResponse(200, type: typeof(List<TournamentInvite>))]
        public virtual IActionResult GetTeamInvites([FromRoute] Guid teamid)
        {
            return new ObjectResult(mCore.TournamentsApi.GetTeamInvites(teamid));
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
        [SwaggerOperation("JoinTournament")]
        public virtual IActionResult JoinTournament([FromBody] JoinTournamentRequest joinRequest)
        {
            mLogger.Info("", Codes.PlayerJoined, "Tournament join attempt", mReferenceId, joinRequest);
            mCore.TournamentsApi.JoinTournament(joinRequest);
            mLogger.Info("", Codes.PlayerJoined, "Tournament join success", mReferenceId);
            return Ok();
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
            mLogger.Info("", Codes.InviteRecall, "Tournament join attempt", mReferenceId, new {tournamentId, inviteId});
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
        [SwaggerOperation("InvitePlayerOrTeam")]
        public virtual IActionResult InvitePlayerOrTeam([FromRoute] Guid tournamentId, [FromBody] TournamentInvite inviteData)
        {
            mLogger.Info("", Codes.PlayerOrTeamInvited, "Invitation attempt", mReferenceId, new {tournamentId, inviteData});
            inviteData.Tournament = tournamentId;
            mCore.TournamentsApi.InvitePlayerOrTeam(inviteData);
            mLogger.Info("", Codes.PlayerOrTeamInvited, "Invitation success", mReferenceId);
            return Ok();
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
            return new ObjectResult(mCore.TournamentsApi.GetTournamentParties(tournamentId));
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
        [Route("/tournament/{tournamentId}/grid")]
        [SwaggerOperation("GetTournamentGrid")]
        public virtual IActionResult GetTournamentGrid([FromRoute] Guid tournamentId)
        {
            return new ObjectResult(mCore.TournamentsApi.GetTournamentGrid(tournamentId));
        }

        /// <summary>
        /// Get tournament games.
        /// </summary>
        /// <remarks>During call will be created. </remarks>
        /// <param name="tournamentId">Id of tournament.</param>
        /// <param name="updatedGrid"></param>
        /// <response code="200">Data for make decisions on successfull user login.</response>
        /// <response code="0">Unexpected error</response>
        [HttpPost]
        [Route("/tournament/{tournamentId}/grid")]
        [SwaggerOperation("UpdateTournamentGrid")]
        public virtual IActionResult UpdateTournamentGrid([FromRoute] Guid tournamentId, [FromBody] TournamentGrid updatedGrid)
        {
            mLogger.Info("", Codes.TournamentGridUpdated, "Grid update attempt", mReferenceId, new { tournamentId, updatedGrid });
            mCore.TournamentsApi.UpdateTournamentGrid(tournamentId, updatedGrid);
            mLogger.Info("", Codes.TournamentGridUpdated, "Grid update success", mReferenceId);
            return Ok();
        }

        #endregion
    }
}
