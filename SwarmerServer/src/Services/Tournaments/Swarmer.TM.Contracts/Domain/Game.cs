using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Swarmer.TM.Contracts.Domain
{
    /// <summary>
    /// Model for game in tournament.
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Date time when game starts.
        /// </summary>
        public DateTime Start { get; set; }

        /// <summary>
        /// Number of sets.
        /// </summary>
        public int BestOf { get; set; }

        /// <summary>
        /// Winner of game.
        /// </summary>
        public Guid Winner { get; set; }

        /// <summary>
        /// Party A of game.
        /// </summary>
        public Guid PartyA { get; set; }

        /// <summary>
        /// Party B of game.
        /// </summary>
        public Guid PartyB { get; set; }

        /// <summary>
        /// Stats of game.
        /// </summary>
        public JObject Stats { get; set; }

        /// <summary>
        /// Sets of game.
        /// </summary>
        public List<GameSet> Sets { get; set; }
    }
}