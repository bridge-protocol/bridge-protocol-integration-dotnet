using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace BridgeProtocol.Integrations.Models
{
    public class ClaimType
    {
        [JsonProperty(PropertyName = "id")]
        public long Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "dataType")]
        public string DataType { get; set; }

        [JsonProperty(PropertyName = "defaultExpirationDays")]
        public int DefaultExpirationDays { get; set; }
    }
}
