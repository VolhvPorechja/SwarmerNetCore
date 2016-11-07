using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Swarmer.Common.Models;

namespace Swarmer.TM.Contracts.Domain
{
    /// <summary>
    /// Model of tournament.
    /// </summary>
    public class Tournament : SysObject
    {
        /// <summary>
        /// Date time of tournament begin.
        /// </summary>
        public DateTime Begin { get; set; }

        /// <summary>
        /// Owner of tournament.
        /// </summary>
        public Guid Owner { get; set; }

        /// <summary>
        /// State of tournament.
        /// </summary>
        public int State { get; set; }
        
        /// <summary>
        /// Title of tournament.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Short name for tournament.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of tournament.
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// Flag that indicates that tournament is open.
        /// </summary>
        public bool IsOpen { get; set; }

        /// <summary>
        /// Stats of tournament.
        /// </summary>
        public JObject TournamentStats { get; set; }

        /// <summary>
        /// Tournament data.
        /// </summary>
        public TournamentData Data { get; set; }

        /// <summary>
        /// Parties that take part in tournament.
        /// </summary>
        public List<Party> Parties { get; set; }
    }
}
