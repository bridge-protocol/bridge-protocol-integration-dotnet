using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BridgeProtocol.Integrations.Models
{
    public class VerifyPassportLoginChallengeResponse
    {
        [JsonProperty(PropertyName = "tokenVerified")]
        public bool TokenVerified { get; set; }

        [JsonProperty(PropertyName = "claims")]
        public List<Claim> Claims { get; set; }

        [JsonProperty(PropertyName ="missingClaimTypes")]
        public List<long> MissingClaimTypes { get; set; }

        [JsonProperty(PropertyName = "unknownSignerClaimTypes")]
        public List<long> UnknownSignerClaimTypes { get; set; }

        [JsonProperty(PropertyName = "passportDetails")]
        public PassportDetails PassportDetails { get; set; }
    }
}
