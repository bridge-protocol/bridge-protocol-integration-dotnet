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
        [DataMember(Name = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets Passport Id
        /// </summary>
        [DataMember(Name = "passportId")]
        public string PassportId { get; set; }

        /// <summary>
        /// Gets or Sets Public Key
        /// </summary>
        [DataMember(Name = "publicKey")]
        public string PublicKey { get; set; }

        /// <summary>
        /// Gets or Sets CreatedOn
        /// </summary>
        [DataMember(Name = "createdOn")]
        public long CreatedOn { get; set; }

        /// <summary>
        /// Gets or Sets UpdatedOn
        /// </summary>
        [DataMember(Name = "updatedOn")]
        public long UpdatedOn { get; set; }

        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        [DataMember(Name = "status")]
        public string Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "verificationPartner")]
        public string VerificationPartner { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "url")]
        public string Url { get; set; }
    }
}
