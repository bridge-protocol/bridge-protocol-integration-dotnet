using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeProtocol.Integrations.Models
{
    public class VerifyPaymentTransactionResult
    {
        [JsonProperty(PropertyName = "complete")]
        public bool Complete { get; set; }

        [JsonProperty(PropertyName = "success")]
        public bool Success { get; set; }
    }
}
