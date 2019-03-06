using System.Runtime.Serialization;

namespace BridgeProtocol.Integrations.Models
{
    [DataContract]
    public class VerificationPartner
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets PublicKey
        /// </summary>
        [DataMember(Name = "publicKey")]
        public string PublicKey { get; set; }
    }
}
