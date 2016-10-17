using System;
using Newtonsoft.Json.Linq;

namespace Swarmer.TM.Contracts
{
    /// <summary>
    /// Model for tournament organizer.
    /// </summary>
    public class TournamentOrganizer
    {
        /// <summary>
        /// Id of user organizer.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Role of organizer.
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// Additional info about organizer.
        /// </summary>
        public JObject AdditionalInfo { get; set; }
    }
}