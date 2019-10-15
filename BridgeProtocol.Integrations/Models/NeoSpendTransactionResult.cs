using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeProtocol.Integrations.Models
{
    public class NeoSpendTransactionResult
    {
        [JsonProperty(PropertyName = "verified")]
        public bool Verified { get; set; }

        [JsonProperty(PropertyName = "complete")]
        public bool Complete { get; set; }
    }
}
