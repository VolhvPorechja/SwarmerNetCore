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
        /// Organizers of tournament.
        /// </summary>
        public List<TournamentOrganizer> Organizers { get; set; }

        /// <summary>
        /// Stats of tournament.
        /// </summary>
        public JObject TournamentStats { get; set; }

        /// <summary>
        /// Parties that take part in tournament.
        /// </summary>
        public List<Party> Parties { get; set; }

        /// <summary>
        /// Grid of tournament.
        /// </summary>
        public TournamentGrid Grid { get; set; }
    }
}
