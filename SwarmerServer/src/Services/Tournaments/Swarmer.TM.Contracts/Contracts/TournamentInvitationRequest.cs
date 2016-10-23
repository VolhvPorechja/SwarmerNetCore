using System;

namespace Swarmer.TM.Contracts.Contracts
{
    /// <summary>
    /// Request of tournament invitation.
    /// </summary>
    public class TournamentInvitationRequest
    {
        /// <summary>
        /// Id of player that should be invited.
        /// </summary>
        public Guid? PlayerId { get; set; }

        /// <summary>
        /// Id of team that should be invited.
        /// </summary>
        public Guid? TeamId { get; set; }
    }
}