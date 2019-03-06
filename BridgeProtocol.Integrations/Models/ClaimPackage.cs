using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BridgeProtocol.Integrations.Models
{
    [DataContract]
    public class ClaimPackage
    {
        [DataMember(Name = "typeId")]
        public long TypeId { get; set; }

        [DataMember(Name = "signedBy")]
        public string SignedBy { get; set; }

        [DataMember(Name = "claim")]
        public string Claim { get; set; }
    }
}
