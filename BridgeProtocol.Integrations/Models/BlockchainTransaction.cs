using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeProtocol.Integrations.Models
{
    public partial class BlockchainTransaction
    {
        public string network { get; set; }

        public dynamic transactionParameters { get; set; }

        public string transaction { get; set; }

        public string hash { get; set; }
    }
}
