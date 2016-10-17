using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Swarmer.TM.Contracts
{
    /// <summary>
    /// Party for tournament.
    /// </summary>
    public class Party
    {
        /// <summary>
        /// Id of party.
        /// </summary>
        public Guid Id { get; set; }
        
        /// <summary>
        /// Id of team for party if player teammates.
        /// </summary>
        public Guid? Team { get; set; }

        /// <summary>
        /// Stats of party during tournament.
        /// </summary>
        public JObject Stats { get; set; }

        /// <summary>
        /// Players that takes part in tournamet.
        /// </summary>
        public List<TournamentPlayer> Players { get; set; }
    }
}