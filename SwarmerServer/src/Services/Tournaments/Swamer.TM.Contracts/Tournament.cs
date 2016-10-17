using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Swarmer.TM.Contracts
{
    /// <summary>
    /// Model of tournament.
    /// </summary>
    public class Tournament
    {
        /// <summary>
        /// Id of tournament.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Organizers of tournament.
        /// </summary>
        public List<TournamentOrganizer> Organizers { get; set; }
        
        /// <summary>
        /// Title of tournament.
        /// </summary>
        public string Title { get; set; }

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
