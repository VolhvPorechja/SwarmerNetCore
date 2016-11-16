using System;

namespace Swarmer.TM.Contracts.Contracts
{
    /// <summary>
    /// Contract for tournament invitation.
    /// </summary>
    public class InviteRequest
    {
        public Guid TournamentId { get; set; }
        public Guid? PlayerId { get; set; }
        public Guid? TeamId { get; set; }
    }
}