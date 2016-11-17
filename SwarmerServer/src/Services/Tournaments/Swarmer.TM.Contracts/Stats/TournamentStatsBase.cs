namespace Swarmer.TM.Contracts.Stats
{
    /// <summary>
    /// Base class for tournament stats.
    /// </summary>
    public abstract class TournamentStatsBase
    {
        /// <summary>
        /// Type of stats
        /// </summary>
        public string StatsType { get; set; }

        /// <summary>
        /// Version of tournament schema.
        /// </summary>
        public string Version { get; set; }
    }
}