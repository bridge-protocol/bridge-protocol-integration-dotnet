using System.Runtime.Serialization;

namespace BridgeProtocol.Integrations.Models
{
    [DataContract]
    public class Claim
    {
        [DataMember(Name = "claimTypeId")]
        public long ClaimTypeId { get; set; }

        [DataMember(Name = "claimValue")]
        public string ClaimValue { get; set; }

        [DataMember(Name = "createdOn")]
        public long CreatedOn { get; set; }

        [DataMember(Name = "expiresOn")]
        public long ExpiresOn { get; set; }

        [DataMember(Name = "signedById")]
        public string SignedById { get; set; }
    }
}
