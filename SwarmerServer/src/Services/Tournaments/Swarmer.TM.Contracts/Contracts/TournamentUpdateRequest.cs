using System;
using Swarmer.TM.Contracts.Domain;

namespace Swarmer.TM.Contracts.Contracts
{
    /// <summary>
    /// Request of tournament update.
    /// </summary>
    public class TournamentUpdateRequest
    {
        /// <summary>
        /// Title of tounament.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Date time of tournament begin.
        /// </summary>
        public DateTime? Begin { get; set; }

        /// <summary>
        /// Description of tournament.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Name of tournament.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Updated TournamentId Grid.
        /// </summary>
        public TournamentGrid Grid { get; set; }
    }
}