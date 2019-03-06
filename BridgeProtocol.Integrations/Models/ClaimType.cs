using System.Runtime.Serialization;

namespace BridgeProtocol.Integrations.Models
{
    [DataContract]
    public class ClaimType
    {
        [DataMember(Name = "id")]
        public long Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "dataType")]
        public string DataType { get; set; }

        [DataMember(Name = "defaultExpirationDays")]
        public int DefaultExpirationDays { get; set; }
    }
}
