using BridgeProtocol.Integrations.Models;
using BridgeProtocol.Integrations.Utility;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeProtocol.Integrations.Services
{
    public class ServiceWrapper
    {
        string _serviceBaseUrl;
        Dictionary<string, string> _securityHeaders;
        ServicesUtility _servicesUtility;

        public string ServiceBaseUrl
        {
            get
            {
                return _serviceBaseUrl;
            }
        }

        public Dictionary<string, string> SecurityHeaders
        {
            get
            {
                return _securityHeaders;
            }
        }

        public ServicesUtility ServicesUtility
        {
            get
            {
                return _servicesUtility;
            }
        }

        public ServiceWrapper(IConfiguration configuration)
        {
            _servicesUtility = new ServicesUtility();

            //Get the configuration
            var serviceConfig = configuration.GetSection("Service");

            //Get the env vars
            var host = Environment.GetEnvironmentVariable("SERVICE_INTEGRATION_HOST");
            var port = Environment.GetEnvironmentVariable("SERVICE_INTEGRATION_PORT");

            if (!String.IsNullOrEmpty(host) && !String.IsNullOrEmpty(port))
            {
                _serviceBaseUrl = string.Concat(host, ":", port);
            }
            else
            {
                _serviceBaseUrl = serviceConfig["Location"];
            }

            _securityHeaders = new Dictionary<string, string>() { { serviceConfig["SecurityHeaderKey"], serviceConfig["SecurityHeaderValue"] } };
        }

        public List<ClaimType> GetClaimTypes()
        {
            dynamic res = _servicesUtility.CallService(ServiceAction.GET, _securityHeaders, _serviceBaseUrl + "/claim/types", null, true);
            var serialized = JsonConvert.SerializeObject(res.claimTypes);

            return JsonConvert.DeserializeObject<List<ClaimType>>(serialized);
        }

        public List<ProfileType> GetProfileTypes()
        {
            dynamic res = _servicesUtility.CallService(ServiceAction.GET, _securityHeaders, _serviceBaseUrl + "/profile/types", null, true);
            var serialized = JsonConvert.SerializeObject(res.profileTypes);

            return JsonConvert.DeserializeObject<List<ProfileType>>(serialized);
        }

        public string GetServerPassportId()
        {
            dynamic res = _servicesUtility.CallService(ServiceAction.GET, _securityHeaders, _serviceBaseUrl + "/passport/id", null, true);
            return res.passportId;
        }

        public string GetServerPublicKey()
        {
            dynamic res = _servicesUtility.CallService(ServiceAction.GET, _securityHeaders, _serviceBaseUrl + "/passport/publickey", null, true);
            return res.publicKey;
        }

        public string CreatePassportLoginChallengeRequest(string signingToken, int? profileTypeId, List<int> claimTypes)
        {
            var obj = new
            {
                signingToken,
                profileTypeId,
                claimTypes
            };

            dynamic res = _servicesUtility.CallService(ServiceAction.POST, _securityHeaders, _serviceBaseUrl + "/passport/requestlogin", JsonConvert.SerializeObject(obj), true);
            return res.request;
        }

        public VerifyPassportLoginChallengeResponse VerifyPassportLoginChallengeResponse(string response, string token, List<int> claimTypes)
        {
            var obj = new
            {
                response,
                token,
                claimTypes
            };

            dynamic res = _servicesUtility.CallService(ServiceAction.POST, _securityHeaders, _serviceBaseUrl + "/passport/verifylogin", JsonConvert.SerializeObject(obj), true);
            var serialized = JsonConvert.SerializeObject(res.verify);

            return JsonConvert.DeserializeObject<VerifyPassportLoginChallengeResponse>(serialized);
        }

        public string CreatePassportPaymentRequest(string network, decimal amount, string address, string identifier)
        {
            var obj = new
            {
                network,
                amount,
                address,
                identifier
            };

            dynamic res = _servicesUtility.CallService(ServiceAction.POST, _securityHeaders, _serviceBaseUrl + "/passport/requestpayment", JsonConvert.SerializeObject(obj), true);
            return res.request;
        }

        public VerifyPassportPaymentResponse VerifyPassportPaymentResponse(string response)
        {
            var obj = new
            {
                response,
            };

            dynamic res = _servicesUtility.CallService(ServiceAction.POST, _securityHeaders, _serviceBaseUrl + "/passport/verifypayment", JsonConvert.SerializeObject(obj), true);
            var serialized = JsonConvert.SerializeObject(res.verify.paymentResponse);

            return JsonConvert.DeserializeObject<VerifyPassportPaymentResponse>(serialized);
        }

        public bool CheckBlockchainTransactionComplete(string network, string transactionId)
        {
            bool complete = false;

            var obj = new
            {
                network,
                transactionId
            };

            try
            {
                dynamic res = ServicesUtility.CallService(ServiceAction.POST, SecurityHeaders, ServiceBaseUrl + "/blockchain/transactioncomplete", JsonConvert.SerializeObject(obj), true);
                complete = res.complete;
            }
            catch (Exception ex)
            {
                //TODO: Log
            }

            return complete;
        }

        public dynamic GetBlockchainTransactionDetails(string network, string transactionId)
        {
            dynamic info = null;

            var obj = new
            {
                network,
                transactionId
            };

       
            try
            {
                dynamic res = ServicesUtility.CallService(ServiceAction.POST, SecurityHeaders, ServiceBaseUrl + "/blockchain/transactiondetails", JsonConvert.SerializeObject(obj), true);
                info = res.info;
            }
            catch(Exception ex)
            {
                //TODO: Log
            }

            return info;
        }
    }
}
