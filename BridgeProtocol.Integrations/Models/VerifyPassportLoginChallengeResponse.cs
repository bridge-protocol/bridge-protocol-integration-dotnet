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
        public List<string> MissingClaimTypes { get; set; }

        [JsonProperty(PropertyName = "unknownSignerClaimTypes")]
        public List<string> UnknownSignerClaimTypes { get; set; }

        [JsonProperty(PropertyName = "passportId")]
        public string PassportId { get; set; }

        [JsonProperty(PropertyName = "publicKey")]
        public string PublicKey { get; set; }

        [JsonProperty(PropertyName = "passportDetails")]
        public PassportDetails PassportDetails { get; set; }

        [JsonProperty(PropertyName = "blockchainAddresses")]
        public List<BlockchainAddress> BlockchainAddresses { get; set; }
    }
}
