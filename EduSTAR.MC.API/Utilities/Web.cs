using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using static EduSTAR.MC.API.Constants;

namespace EduSTAR.MC.API.Utilities
{
    internal static class Web
    {
        internal static T GetContentAsObject<T>(string fullUrl) where T : class {
            var result = GetContentAsString(fullUrl);

            return Convert.XmlStringToObject<T>(result);
        }

        internal static string GetContentAsString(string fullUrl) {
            var responseResult = SendGetRequest(fullUrl);

            var responseContent = responseResult.Content;
            var responseContentTask = responseContent.ReadAsStringAsync();
            
            return responseContentTask.Result;
        }

        private static HttpResponseMessage SendGetRequest(string fullUrl) {
            var responseTask = Globals.HttpClient.GetAsync(fullUrl);
            var responseResult = responseTask.Result;

            if (responseResult.StatusCode != HttpStatusCode.OK) {
                throw new HttpRequestException($"Could not access \"{fullUrl}\" ({responseResult.StatusCode}).");
            }

            return responseResult;
        }
    }
}
