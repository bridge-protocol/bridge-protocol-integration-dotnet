using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace BridgeProtocol.Integrations.Models
{
    public class Claim
    {
        [JsonProperty(PropertyName = "claimTypeId")]
        public string ClaimTypeId { get; set; }

        [JsonProperty(PropertyName = "claimValue")]
        public string ClaimValue { get; set; }

        [JsonProperty(PropertyName = "createdOn")]
        public long CreatedOn { get; set; }

        [JsonProperty(PropertyName = "expiresOn")]
        public long ExpiresOn { get; set; }

        [JsonProperty(PropertyName = "signedByKey")]
        public string SignedByKey { get; set; }

        [JsonProperty(PropertyName = "signedById")]
        public string SignedById { get; set; }

        [JsonProperty(PropertyName = "signatureValid")]
        public bool SignatureValid { get; set; }

        [JsonProperty(PropertyName = "signedByPartner")]
        public bool SignedByPartner { get; set; }


    }
}
