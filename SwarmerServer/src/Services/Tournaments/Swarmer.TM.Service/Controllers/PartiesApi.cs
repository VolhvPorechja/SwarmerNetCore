using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Swarmer.TM.Contracts.Contracts;
using Swarmer.TM.Contracts.Domain;
using Swashbuckle.SwaggerGen.Annotations;

namespace Swarmer.TM.Service.Controllers
{
    public class PartiesApi : Controller
    {
        #region Party

        /// <summary>
        /// Create new part on tournament.
        /// </summary>
        /// <remarks>New party for given tournament.</remarks>
        /// <param name="request">Request for party creation.</param>
        /// <response code="200">Created party.</response>
        /// <response code="0">Unexpected error</response>
        [HttpPost]
        [Route("/party")]
        [SwaggerOperation("CreateTournamentParty")]
        [SwaggerResponse(200, type: typeof(Party))]
        public virtual IActionResult CreateTournamentParty([FromBody] PartyCreationRequest request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get party.
        /// </summary>
        /// <remarks>Get party by id.</remarks>
        /// <param name="partyId">Id of party.</param>
        /// <response code="200">Requested party.</response>
        /// <response code="0">Unexpected error</response>
        [HttpGet]
        [Route("/party/{partyId}")]
        [SwaggerOperation("GetParty")]
        [SwaggerResponse(200, type: typeof(Party))]
        public virtual IActionResult GetParty([FromRoute] Guid partyId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update party data.
        /// </summary>
        /// <remarks>Update allowed party data.</remarks>
        /// <param name="partyId">Id of getting party.</param>
        /// <param name="updatedPartyData">Updated party data.</param>
        /// <response code="200">Data for make decisions on successfull user login.</response>
        /// <response code="0">Unexpected error</response>
        [HttpPost]
        [Route("/party/{partyId}")]
        [SwaggerOperation("UpdatePartyData")]
        public virtual IActionResult UpdatePartyData([FromRoute] Guid partyId, [FromBody] PartyUpdateDataRequest updatedPartyData)
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// Update tournament party data.
        /// </summary>
        /// <remarks>During call will be created. </remarks>
        /// <param name="partyId">Id of getting party.</param>
        /// <response code="200">Data for make decisions on successfull user login.</response>
        /// <response code="0">Unexpected error</response>
        [HttpDelete]
        [Route("/party/{partyId}")]
        [SwaggerOperation("DeleteParty")]
        public virtual IActionResult DeleteParty([FromRoute] Guid partyId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update party stats.
        /// </summary>
        /// <remarks>Update aggregated stats of tournament.</remarks>
        /// <param name="partyId">Id of party.</param>
        /// <param name="stats">Tournament party aggregated stats.</param>
        /// <response code="200">Data for make decisions on successfull user login.</response>
        /// <response code="0">Unexpected error</response>
        [HttpPost]
        [Route("/party/{partyId}/stats")]
        [SwaggerOperation("UpdatePartyStats")]
        public virtual IActionResult UpdatePartyStats([FromRoute] Guid partyId, [FromBody] JObject stats)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Invites

        /// <summary>
        /// Update tournament party data.
        /// </summary>
        /// <remarks>During call will be created. </remarks>
        /// <param name="partyId">Id of getting party.</param>
        /// <response code="200">Data for make decisions on successfull user login.</response>
        /// <response code="0">Unexpected error</response>
        [HttpGet]
        [Route("/party/{partyId}/invites")]
        [SwaggerOperation("GetPartyInvites")]
        [SwaggerResponse(200, type: typeof(List<PartyInvite>))]
        public virtual IActionResult GetPartyInvites([FromRoute] Guid partyId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update tournament party data.
        /// </summary>
        /// <remarks>During call will be created. </remarks>
        /// <param name="tournamentId"></param>
        /// <param name="userId">Id of getting party.</param>
        /// <response code="200">Data for make decisions on successfull user login.</response>
        /// <response code="0">Unexpected error</response>
        [HttpGet]
        [Route("/party/tournament/{tournamentId}/invites/user/{userId}")]
        [SwaggerOperation("GetUserTournamentPartyInvites")]
        [SwaggerResponse(200, type: typeof(List<PartyInvite>))]
        public virtual IActionResult GetUserTournamentPartyInvites([FromRoute] Guid tournamentId, [FromRoute] Guid userId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update tournament party data.
        /// </summary>
        /// <remarks>During call will be created. </remarks>
        /// <param name="partyId">Id of getting party.</param>
        /// <param name="request"></param>
        /// <response code="200">Data for make decisions on successfull user login.</response>
        /// <response code="0">Unexpected error</response>
        [HttpPost]
        [Route("/party/{partyId}/invite")]
        [SwaggerOperation("InvitePlayer")]
        public virtual IActionResult InvitePlayer([FromRoute] Guid partyId, [FromBody] PartyInviteRequest request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update tournament party data.
        /// </summary>
        /// <remarks>During call will be created. </remarks>
        /// <param name="partyId">Id of getting party.</param>
        /// <param name="inviteId"></param>
        /// <response code="200">Data for make decisions on successfull user login.</response>
        /// <response code="0">Unexpected error</response>
        [HttpDelete]
        [Route("/party/{partyId}/invite/{inviteId}")]
        [SwaggerOperation("RecallInvite")]
        public virtual IActionResult RecallInvite([FromRoute] Guid partyId, [FromRoute] Guid inviteId)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Participation

        /// <summary>
        /// Update tournament party data.
        /// </summary>
        /// <remarks>During call will be created. </remarks>
        /// <param name="partyId">Id of getting party.</param>
        /// <param name="playerId"></param>
        /// <response code="200">Data for make decisions on successfull user login.</response>
        /// <response code="0">Unexpected error</response>
        [HttpPost]
        [Route("/party/{partyId}/player/{playerId}")]
        [SwaggerOperation("JoinParty")]
        public virtual IActionResult JoinParty([FromRoute] Guid partyId, [FromRoute] Guid playerId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update tournament party data.
        /// </summary>
        /// <remarks>During call will be created. </remarks>
        /// <param name="partyId">Id of getting party.</param>
        /// <param name="playerId"></param>
        /// <response code="200">Data for make decisions on successfull user login.</response>
        /// <response code="0">Unexpected error</response>
        [HttpDelete]
        [Route("/party/{partyId}/player/{playerId}")]
        [SwaggerOperation("LeaveParty")]
        public virtual IActionResult LeaveParty([FromRoute] Guid partyId, [FromRoute] Guid playerId)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}