using Newtonsoft.Json.Linq;

namespace Swarmer.TM.Contracts.Domain
{
    /// <summary>
    /// Party data.
    /// </summary>
    public class PartyData
    {
		/// <summary>
        /// Additional party data.
        /// </summary>
        public JObject AdditionalData { get; set; }
    }
}