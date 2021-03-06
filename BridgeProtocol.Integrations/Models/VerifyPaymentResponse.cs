﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeProtocol.Integrations.Models
{
    public class VerifyPaymentResponse
    {
        [JsonProperty(PropertyName = "network")]
        public string Network { get; set; }

        [JsonProperty(PropertyName = "from")]
        public string From { get; set; }

        [JsonProperty(PropertyName = "amount")]
        public long Amount { get; set; }

        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }

        [JsonProperty(PropertyName = "identifier")]
        public string Identifier { get; set; }

        [JsonProperty(PropertyName = "transactionId")]
        public string TransactionId { get; set; }

        [JsonProperty(PropertyName = "passportId")]
        public string PassportId { get; set; }
    }
}
