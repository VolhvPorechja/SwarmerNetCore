using System;
using Microsoft.AspNetCore.Mvc;
using Swarmer.TM.Contracts.Contracts;
using Swarmer.TM.Contracts.Domain;
using Swashbuckle.SwaggerGen.Annotations;

namespace Swarmer.TM.Service.Controllers
{
    public class PartiesApi : Controller
    {
        #region Party

        /// <summary>
        /// Get tournament.
        /// </summary>
        /// <remarks>During call will be created. </remarks>
        /// <param name="request"></param>
        /// <response code="200">Data for make decisions on successfull user login.</response>
        /// <response code="0">Unexpected error</response>
        [HttpPost]
        [Route("/party")]
        [SwaggerOperation("CreateTournamentParty")]
        public virtual IActionResult CreateParty([FromBody] PartyCreationRequest request)
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
        [Route("/party/{partyId}")]
        [SwaggerOperation("GetTournamentParty")]
        public virtual IActionResult GetParty([FromRoute] Guid tournamentId, [FromRoute] Guid partyId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update tournament party data.
        /// </summary>
        /// <remarks>During call will be created. </remarks>
        /// <param name="tournamentId">Id of tournament.</param>
        /// <param name="partyId">Id of getting party.</param>
        /// <param name="updatedPartyData">Updated party data.</param>
        /// <response code="200">Data for make decisions on successfull user login.</response>
        /// <response code="0">Unexpected error</response>
        [HttpPost]
        [Route("/party/{partyId}")]
        [SwaggerOperation("GetTournamentParty")]
        public virtual IActionResult UpdatePartyData([FromRoute] Guid tournamentId, [FromRoute] Guid partyId, [FromBody] PartyUpdateDataRequest updatedPartyData)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Invite

        /// <summary>
        /// Update tournament party data.
        /// </summary>
        /// <remarks>During call will be created. </remarks>
        /// <param name="partyId">Id of getting party.</param>
        /// <response code="200">Data for make decisions on successfull user login.</response>
        /// <response code="0">Unexpected error</response>
        [HttpGet]
        [Route("/party/{partyId}/invite")]
        [SwaggerOperation("GetPartyInvites")]
        public virtual IActionResult GetPartyInvites([FromRoute] Guid partyId)
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
        [HttpPost]
        [Route("/party/{partyId}/invite")]
        [SwaggerOperation("GetPartyInvites")]
        public virtual IActionResult InvitePlayer([FromBody] PartyInviteRequest partyId)
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
        [SwaggerOperation("GetTournamentParty")]
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
        [SwaggerOperation("GetTournamentParty")]
        public virtual IActionResult ParticipateInParty([FromRoute] Guid partyId, [FromRoute] Guid playerId)
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
        [SwaggerOperation("GetTournamentParty")]
        public virtual IActionResult LeaveParty([FromRoute] Guid partyId, [FromRoute] Guid playerId)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}