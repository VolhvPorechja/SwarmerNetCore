using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Swarmer.Common.Models;

namespace Swarmer.TM.Contracts.Domain
{
    /// <summary>
    /// Party for tournament.
    /// </summary>
    public class Party: SysObject
    {
        /// <summary>
        /// Name of party.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Id of tournament.
        /// </summary>
        public Guid TournamentId { get; set; }

        /// <summary>
        /// Id of party creator.
        /// </summary>
        public Guid Creator { get; set; }
        
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