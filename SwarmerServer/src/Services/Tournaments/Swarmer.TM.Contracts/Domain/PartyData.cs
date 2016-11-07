using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Swarmer.TM.Contracts.Domain
{
    /// <summary>
    /// Party data.
    /// </summary>
    public class PartyData
    {
        /// <summary>
        /// Players that takes part in tournamet.
        /// </summary>
        public List<TournamentPlayer> Players { get; set; }

        /// <summary>
        /// Additional party data.
        /// </summary>
        public JObject AdditionalData { get; set; }
    }
}