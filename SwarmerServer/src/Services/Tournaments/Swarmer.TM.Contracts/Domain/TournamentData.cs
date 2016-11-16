using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Swarmer.TM.Contracts.Domain
{
    /// <summary>
    /// Tournament data.
    /// </summary>
    public class TournamentData
    {
        /// <summary>
        /// Organizers of tournament.
        /// </summary>
        public List<TournamentOrganizer> Organizers { get; set; }

        /// <summary>
        /// Additional tounament data.
        /// </summary>
        public JObject AdditionalData { get; set; }


        /// <summary>
        /// Grid of tournament.
        /// </summary>
        public TournamentGrid Grid { get; set; }
    }
}