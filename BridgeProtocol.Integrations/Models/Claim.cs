using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace BridgeProtocol.Integrations.Models
{
    public class Claim
    {
        [JsonProperty(PropertyName = "claimTypeId")]
        public long ClaimTypeId { get; set; }

        [JsonProperty(PropertyName = "claimValue")]
        public string ClaimValue { get; set; }

        [JsonProperty(PropertyName = "createdOn")]
        public long CreatedOn { get; set; }

        [JsonProperty(PropertyName = "expiresOn")]
        public long ExpiresOn { get; set; }
    }
}
