using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BridgeProtocol.Integrations.Models
{
    [DataContract]
    public class VerifyPassportLoginChallengeResponse
    {
        [DataMember(Name = "tokenVerified")]
        public bool TokenVerified { get; set; }

        [DataMember(Name = "claims")]
        public List<Claim> Claims { get; set; }

        [DataMember(Name ="missingClaimTypes")]
        public List<long> MissingClaimTypes { get; set; }

        [DataMember(Name = "passportDetails")]
        public PassportDetails PassportDetails { get; set; }
    }
}
