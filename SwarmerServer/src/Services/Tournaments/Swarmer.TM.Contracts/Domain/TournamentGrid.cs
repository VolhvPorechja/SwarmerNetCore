using System.Collections.Generic;

namespace Swarmer.TM.Contracts.Domain
{
    /// <summary>
    /// TournamentId grid.
    /// </summary>
    public class TournamentGrid
    {
        /// <summary>
        /// Type of tournament grid.
        /// </summary>
        public TournamentGridType GridType { get; set; }

        /// <summary>
        /// Stages of tournament.
        /// </summary>
        public List<Stage> Stages { get; set; }
    }
}