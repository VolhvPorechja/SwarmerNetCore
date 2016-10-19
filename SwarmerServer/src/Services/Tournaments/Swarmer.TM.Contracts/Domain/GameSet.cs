using System;
using Newtonsoft.Json.Linq;

namespace Swarmer.TM.Contracts.Domain
{
    /// <summary>
    /// Model for game set.
    /// </summary>
    public class GameSet
    {
        /// <summary>
        /// Winner of set.
        /// </summary>
        public Guid Winner { get; set; }

        /// <summary>
        /// Stats of game.
        /// </summary>
        public JObject Stats { get; set; }
    }
}