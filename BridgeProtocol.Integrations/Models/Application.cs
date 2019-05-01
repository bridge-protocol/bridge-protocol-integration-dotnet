using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BridgeProtocol.Integrations.Models
{
    public class Application
    {
        public Application()
        {

        }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets Passport Id
        /// </summary>
        [JsonProperty(PropertyName = "passportId")]
        public string PassportId { get; set; }

        /// <summary>
        /// Gets or Sets Public Key
        /// </summary>
        [JsonProperty(PropertyName = "publicKey")]
        public string PublicKey { get; set; }

        /// <summary>
        /// Gets or Sets CreatedOn
        /// </summary>
        [JsonProperty(PropertyName = "createdOn")]
        public long CreatedOn { get; set; }

        /// <summary>
        /// Gets or Sets UpdatedOn
        /// </summary>
        [JsonProperty(PropertyName = "updatedOn")]
        public long UpdatedOn { get; set; }

        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "verificationPartner")]
        public string VerificationPartner { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
    }
}
