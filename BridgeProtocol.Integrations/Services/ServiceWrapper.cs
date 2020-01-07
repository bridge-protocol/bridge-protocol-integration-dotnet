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
            return res.passportId;
        }

        public string GetServerPublicKey()
        {
            dynamic res = _servicesUtility.CallService(ServiceAction.GET, _securityHeaders, _serviceBaseUrl + "/passport/publickey", null, true);
            return res.publicKey;
        }

        public string CreatePassportLoginChallengeRequest(string signingToken, int? profileTypeId, List<string> claimTypes)
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

        public VerifyPassportLoginChallengeResponse VerifyPassportLoginChallengeResponse(string response, string token, List<string> claimTypes)
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
                response
            };

            dynamic res = _servicesUtility.CallService(ServiceAction.POST, _securityHeaders, _serviceBaseUrl + "/passport/verifypayment", JsonConvert.SerializeObject(obj), true);
            var serialized = JsonConvert.SerializeObject(res.verify);

            return JsonConvert.DeserializeObject<VerifyPassportPaymentResponse>(serialized);
        }

        public string CreateClaimsImportRequest(string publicKey, List<Claim> claims)
        {
            var obj = new
            {
                publicKey,
                claims
            };

            dynamic res = _servicesUtility.CallService(ServiceAction.POST, _securityHeaders, _serviceBaseUrl + "/passport/requestclaimsimport", JsonConvert.SerializeObject(obj), true);
            return res.request;
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

        public string GetPassportIdFromKey(string publicKeyHex)
        {
            var obj = new { publicKeyHex };

            var res = _servicesUtility.CallService(ServiceAction.POST, _securityHeaders, _serviceBaseUrl + "/passport/idfromkey", JsonConvert.SerializeObject(obj), true);
            return res.passportId;
        }

        public string SignMessage(string messageText)
        {
            var obj = new { messageText };

            var res = _servicesUtility.CallService(ServiceAction.POST, _securityHeaders, _serviceBaseUrl + "/passport/sign", JsonConvert.SerializeObject(obj), true);
            return res.signedMessage;
        }

        public bool VerifyMessageSignature(string messageSignature, string publicKeyHex)
        {
            return !string.IsNullOrWhiteSpace(GetSignedMessage(messageSignature, publicKeyHex));
        }

        public bool VerifyHash(string str, string hash)
        {
            var obj = new { str, hash };
            var res = _servicesUtility.CallService(ServiceAction.POST, _securityHeaders, _serviceBaseUrl + "/passport/verifyhash", JsonConvert.SerializeObject(obj), true);
            return (bool)res.verified;
        }

        public string GetSignedMessage(string messageSignature, string publicKeyHex)
        {
            var obj = new
            {
                messageSignature,
                publicKeyHex
            };

            var res = _servicesUtility.CallService(ServiceAction.POST, _securityHeaders, _serviceBaseUrl + "/passport/verify", JsonConvert.SerializeObject(obj), true);
            return (string)res.verified;
        }

        public string EncryptMessage(string messageText, string decryptPublicKeyHex)
        {
            var obj = new
            {
                messageText,
                decryptPublicKeyHex
            };

            var res = _servicesUtility.CallService(ServiceAction.POST, _securityHeaders, _serviceBaseUrl + "/passport/encrypt", JsonConvert.SerializeObject(obj), true);
            return res.encryptedMessage;
        }

        public string DecryptMessage(string encryptedMessage)
        {
            var obj = new { encryptedMessage };

            var res = _servicesUtility.CallService(ServiceAction.POST, _securityHeaders, _serviceBaseUrl + "/passport/decrypt", JsonConvert.SerializeObject(obj), true);
            return res.decryptedMessage;
        }

        public dynamic NeoGetClaimAddTransaction(dynamic claim, string passportId, string address, bool hashOnly)
        {
            var obj = new
            {
                claim,
                passportId,
                address,
                hashOnly
            };

            var res = _servicesUtility.CallService(ServiceAction.POST, _securityHeaders, _serviceBaseUrl + "/neo/claimaddtransaction", JsonConvert.SerializeObject(obj), true);
            return res.transaction;
        }

        public NeoSpendTransactionResult NeoVerifySpendTransaction(string transactionId, decimal amount, string recipient, string identifier)
        {
            var obj = new
            {
                txid = transactionId,
                amount,
                recipient,
                identifier
            };

            var res = _servicesUtility.CallService(ServiceAction.POST, _securityHeaders, _serviceBaseUrl + "/neo/verifyspendtransaction", JsonConvert.SerializeObject(obj), true);
            var serialized = JsonConvert.SerializeObject(res);
            return JsonConvert.DeserializeObject<NeoSpendTransactionResult>(serialized);
        }
    }
}
