using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BridgeProtocol.Integrations.Models
{
    public class PassportDetails
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "isBlacklisted")]
        public bool IsBlacklisted { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "blackistReason")]
        public string BlacklistReason { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "isNetworkPartner")]
        public bool IsNetworkPartner { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "isVerificationPartner")]
        public bool IsVerificationPartner { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "partnerName")]
        public string PartnerName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "partnerAddresses")]
        public List<string> PartnerAddresses { get; set; }
    }
}
