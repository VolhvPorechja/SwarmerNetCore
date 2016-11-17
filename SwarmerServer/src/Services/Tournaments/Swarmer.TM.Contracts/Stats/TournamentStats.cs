using System;

namespace Swarmer.TM.Contracts.Stats
{
    /// <summary>
    /// Contract for tournament stats.
    /// </summary>
    public class TournamentStats
    {
        /// <summary>
        /// Id of best player of game.
        /// </summary>
        public Guid BestPlayer { get; set; }

        /// <summary>
        /// Total number of games played during tournament.
        /// </summary>
        public int GamesPlayed { get; set; }
    }
}