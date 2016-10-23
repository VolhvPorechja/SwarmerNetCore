using System;

namespace Swarmer.TM.Contracts.Contracts
{
    /// <summary>
    /// Request for player party invitation.
    /// </summary>
    public class PartyInviteRequest
    {
        /// <summary>
        /// Id of player that will be invited.
        /// </summary>
        public Guid PlayerId { get; set; }
    }
}