using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Swarmer.Common
{
    /// <summary>
    /// Class for message in log.
    /// </summary>
    public class LogMessage
    {
        [JsonProperty("initiator")]
        public string Initiator { get; set; }

        [JsonProperty("referenceId")]
        public string ReferenceId { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public JObject Data { get; set; }

        [JsonProperty("system")]
        public string System { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        public string ToJString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
