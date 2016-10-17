using System;
using Newtonsoft.Json.Linq;

namespace Swarmer.TM.Contracts
{
    /// <summary>
    /// Model for tournament player.
    /// </summary>
    public class TournamentPlayer
    {
        /// <summary>
        /// Id of player.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Stats of player during tournament.
        /// </summary>
        public JObject Stats { get; set; }
    }
}