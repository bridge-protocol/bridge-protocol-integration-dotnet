using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BridgeProtocol.Integrations.Models
{
    [DataContract]
    public class PassportDetails
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id")]
        public string Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "isBlacklisted")]
        public bool IsBlacklisted { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "blackistReason")]
        public string BlacklistReason { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "isNetworkPartner")]
        public bool IsNetworkPartner { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "isVerificationPartner")]
        public bool IsVerificationPartner { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "partnerName")]
        public string PartnerName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "partnerAddresses")]
        public List<string> PartnerAddresses { get; set; }
    }
}
