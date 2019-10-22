using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeProtocol.Integrations.Models
{
    public partial class BlockchainTransaction
    {
        public string network { get; set; }

        public string transaction { get; set; }
    }
}
