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

        public ServiceWrapper(string serviceUrl, string securityHeaderKey, string securityHeaderValue)
        {
            _servicesUtility = new ServicesUtility();
            _serviceBaseUrl = serviceUrl;
            _securityHeaders = new Dictionary<string, string>() { { securityHeaderKey, securityHeaderValue } };
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
            return res.response;
        }

        public string GetServerPublicKey()
        {
            dynamic res = _servicesUtility.CallService(ServiceAction.GET, _securityHeaders, _serviceBaseUrl + "/passport/publickey", null, true);
            return res.response;
        }

        public string GetPassportIdFromKey(string publicKey)
        {
            var obj = new { publicKey };

            var res = _servicesUtility.CallService(ServiceAction.POST, _securityHeaders, _serviceBaseUrl + "/passport/idfromkey", JsonConvert.SerializeObject(obj), true);
            return res.response;
        }

        public PassportDetails GetPassportDetails(string passportId)
        {
            var obj = new { passportId };
            var res = _servicesUtility.CallService(ServiceAction.POST, _securityHeaders, _serviceBaseUrl + "/passport/details", JsonConvert.SerializeObject(obj), true);
            var serialized = JsonConvert.SerializeObject(res.response);

            return JsonConvert.DeserializeObject<PassportDetails>(serialized);
        }

        public string SignMessage(string message)
        {
            var obj = new { message };

            var res = _servicesUtility.CallService(ServiceAction.POST, _securityHeaders, _serviceBaseUrl + "/passport/sign", JsonConvert.SerializeObject(obj), true);
            return res.response;
        }

        public bool VerifyMessageSignature(string signature, string publicKey)
        {
            return !string.IsNullOrWhiteSpace(GetSignedMessage(signature, publicKey));
        }

        public bool VerifyHash(string message, string hash)
        {
            var obj = new { message, hash };
            var res = _servicesUtility.CallService(ServiceAction.POST, _securityHeaders, _serviceBaseUrl + "/passport/verifyhash", JsonConvert.SerializeObject(obj), true);
            return (bool)res.response;
        }

        public string GetSignedMessage(string signature, string publicKey)
        {
            var obj = new
            {
                signature,
                publicKey
            };

            var res = _servicesUtility.CallService(ServiceAction.POST, _securityHeaders, _serviceBaseUrl + "/passport/verify", JsonConvert.SerializeObject(obj), true);
            return (string)res.response;
        }

        public string EncryptMessage(string message, string publicKey)
        {
            var obj = new
            {
                message,
                publicKey
            };

            var res = _servicesUtility.CallService(ServiceAction.POST, _securityHeaders, _serviceBaseUrl + "/passport/encrypt", JsonConvert.SerializeObject(obj), true);
            return res.response;
        }

        public string DecryptMessage(string encrypted)
        {
            var obj = new { encrypted };

            var res = _servicesUtility.CallService(ServiceAction.POST, _securityHeaders, _serviceBaseUrl + "/passport/decrypt", JsonConvert.SerializeObject(obj), true);
            return res.response;
        }

        public string CreateAuthRequest(string token, List<string> claimTypes, List<string> networks)
        {
            var obj = new
            {
                token,
                claimTypes,
                networks
            };

            dynamic res = _servicesUtility.CallService(ServiceAction.POST, _securityHeaders, _serviceBaseUrl + "/passport/requestauth", JsonConvert.SerializeObject(obj), true);
            return res.response;
        }

        public VerifyAuthResponse VerifyAuthResponse(string response, string token)
        {
            var obj = new
            {
                response,
                token
            };

            dynamic res = _servicesUtility.CallService(ServiceAction.POST, _securityHeaders, _serviceBaseUrl + "/passport/verifyauth", JsonConvert.SerializeObject(obj), true);
            var serialized = JsonConvert.SerializeObject(res.response);

            return JsonConvert.DeserializeObject<VerifyAuthResponse>(serialized);
        }

        public string CreatePaymentRequest(string network, decimal amount, string address, string identifier)
        {
            var obj = new
            {
                network,
                amount,
                address,
                identifier
            };

            dynamic res = _servicesUtility.CallService(ServiceAction.POST, _securityHeaders, _serviceBaseUrl + "/passport/requestpayment", JsonConvert.SerializeObject(obj), true);
            return res.response;
        }

        public VerifyPaymentResponse VerifyPaymentResponse(string response)
        {
            var obj = new
            {
                response
            };

            dynamic res = _servicesUtility.CallService(ServiceAction.POST, _securityHeaders, _serviceBaseUrl + "/passport/verifypayment", JsonConvert.SerializeObject(obj), true);
            var serialized = JsonConvert.SerializeObject(res.response);

            return JsonConvert.DeserializeObject<VerifyPaymentResponse>(serialized);
        }

        public string CreateClaimsImportRequest(string publicKey, List<Claim> claims)
        {
            var obj = new
            {
                publicKey,
                claims
            };

            dynamic res = _servicesUtility.CallService(ServiceAction.POST, _securityHeaders, _serviceBaseUrl + "/passport/requestclaimsimport", JsonConvert.SerializeObject(obj), true);
            return res.response;
        }

        public VerifyPaymentTransactionResult VerifyPayment(string network, string txid, string from, string to, int amount, string identifier)
        {
            var obj = new
            {
                txid,
                from,
                to,
                amount,
                identifier
            };

            var res = _servicesUtility.CallService(ServiceAction.POST, _securityHeaders, _serviceBaseUrl + "/blockchain/verifypayment", JsonConvert.SerializeObject(obj), true);
            var serialized = JsonConvert.SerializeObject(res);
            return JsonConvert.DeserializeObject<VerifyPaymentTransactionResult>(serialized);
        }

        public dynamic ApproveClaimPublish(string network, string passportId, string address, dynamic claim, bool hashOnly)
        {
            var obj = new
            {
                network,
                passportId,
                address,
                claim,
                hashOnly
            };

            var res = _servicesUtility.CallService(ServiceAction.POST, _securityHeaders, _serviceBaseUrl + "/blockchain/approveclaimpublish", JsonConvert.SerializeObject(obj), true);
            return res.response;
        }
    }
}
