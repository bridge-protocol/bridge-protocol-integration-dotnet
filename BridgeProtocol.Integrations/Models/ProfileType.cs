using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BridgeProtocol.Integrations.Models
{
    public class ProfileType
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets ClaimTypes
        /// </summary>
        [JsonProperty(PropertyName = "claimTypes")]
        public List<int> ClaimTypes { get; set; }
    }
}
