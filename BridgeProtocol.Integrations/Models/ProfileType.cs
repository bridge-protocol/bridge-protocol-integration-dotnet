using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BridgeProtocol.Integrations.Models
{
    [DataContract]
    public class ProfileType
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [DataMember(Name = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets ClaimTypes
        /// </summary>
        [DataMember(Name = "claimTypes")]
        public List<int> ClaimTypes { get; set; }
    }
}
