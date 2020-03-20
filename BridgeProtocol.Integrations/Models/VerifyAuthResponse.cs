using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BridgeProtocol.Integrations.Models
{
    public class VerifyAuthResponse
    {
        [JsonProperty(PropertyName = "passportId")]
        public string PassportId { get; set; }

        [JsonProperty(PropertyName = "publicKey")]
        public string PublicKey { get; set; }

        [JsonProperty(PropertyName = "tokenVerified")]
        public bool TokenVerified { get; set; }

        [JsonProperty(PropertyName = "claims")]
        public List<Claim> Claims { get; set; }

        [JsonProperty(PropertyName = "blockchainAddresses")]
        public List<BlockchainAddress> BlockchainAddresses { get; set; }
    }
}
