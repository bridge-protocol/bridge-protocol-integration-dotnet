using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BridgeProtocol.Integrations.Models
{
    public class ClaimPackage
    {
        [JsonProperty(PropertyName = "typeId")]
        public long TypeId { get; set; }

        [JsonProperty(PropertyName = "signedBy")]
        public string SignedBy { get; set; }

        [JsonProperty(PropertyName = "claim")]
        public string Claim { get; set; }
    }
}
