using System;

namespace Swarmer.TM.Contracts.Contracts
{
    /// <summary>
    /// Request for joining tournament.
    /// </summary>
    public class JoinTournamentRequest
    {
        /// <summary>
        /// Id of tournament to which user will join.
        /// </summary>
        public Guid TournamentId { get; set; }

        /// <summary>
        /// Id of joining user.
        /// </summary>
        public Guid UserId { get; set; }
    }
}