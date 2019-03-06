using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;

namespace BridgeProtocol.Integrations.Utility
{
    /// <summary>
    /// 
    /// </summary>
    public enum ServiceAction
    {
        /// <summary>
        /// 
        /// </summary>
        GET,
        /// <summary>
        /// 
        /// </summary>
        POST
    }

    /// <summary>
    /// 
    /// </summary>
    public class ServicesUtility
    {
        public dynamic CallService(ServiceAction action, Dictionary<string, string> headerValues, string url, string jsonContent, bool handleError)
        {
            var res = CallService(action, headerValues, url, jsonContent);
            dynamic json = JsonConvert.DeserializeObject(res);

            //If we have a custom object returned from the called service that wants to pass us its internal errors, 
            //we want to throw that exception detail
            if (handleError && json.error != null && !String.IsNullOrEmpty((string)json.error))
            {
                throw new Exception("Error returned from service: " + (string)json.error);
            }

            return json;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <param name="apiKey"></param>
        /// <param name="url"></param>
        /// <param name="jsonContent"></param>
        /// <returns></returns>
        private dynamic CallService(ServiceAction action, Dictionary<string, string> headerValues, string url, string jsonContent)
        {
            string res = null;

            using (var client = new WebClient { Encoding = System.Text.Encoding.UTF8 })
            {
                //Set the content type header
                client.Headers[HttpRequestHeader.ContentType] = "application/json";

                foreach (var header in headerValues)
                {
                    client.Headers.Add(header.Key, header.Value);
                }

                if (action == ServiceAction.GET)
                {
                    res = client.DownloadString(url);
                }
                else if (action == ServiceAction.POST)
                {
                    if (jsonContent == null)
                        jsonContent = "{}";

                    res = client.UploadString(url, jsonContent);
                }
            }

            return res;
        }
    }
}
