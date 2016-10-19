using System.Collections.Generic;

namespace Swarmer.TM.Contracts.Domain
{
    /// <summary>
    /// Stage of tournament.
    /// </summary>
    public class Stage
    {
        /// <summary>
        /// Name of stage.
        /// </summary>
        public string StageName { get; set; }

        /// <summary>
        /// Game of stage.
        /// </summary>
        public Game Game { get; set; }

        /// <summary>
        /// Previous stage.
        /// </summary>
        public List<Stage> PreviousStages { get; set; }
    }
}