using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeProtocol.Integrations.Models
{
    public class BridgeIntegrationServiceSettings : IBridgeIntegrationServiceSettings
    {
        public string Location { get; set; }
        public string SecurityHeaderKey { get; set; }
        public string SecurityHeaderValue { get; set; }

        public BridgeIntegrationServiceSettings(IConfiguration configuration)
        {
            IConfigurationSection config = configuration.GetSection("Services").GetSection("BridgeIntegration");
            Location = config["Location"];
            SecurityHeaderKey = config["SecurityHeaderKey"];
            SecurityHeaderValue = config["SecurityHeaderValue"];
        }
    }
}
