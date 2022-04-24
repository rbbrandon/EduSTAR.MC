using System.IO;
using System.Net;
using System.Net.Http;
using System.Xml.Serialization;
using EduSTAR.MC.API.Models;
using EduSTAR.MC.API.Validators;
using static EduSTAR.MC.API.Constants;

namespace EduSTAR.MC.API
{
    internal static class Globals
    {
        internal static HttpClient HttpClient { get; private set; }
        internal static CurrentUserData CurrentUserData { get; private set; }

        internal static void InitialiseHttpClient() {
            InitialiseHttpClient(null, null);
        }

        internal static void InitialiseHttpClient(string username, string password) {
            HttpClient httpClient;

            if (CredentialValidator.IsValidCredentials(username, password)) {
                var credentialCache = new CredentialCache {
                    {
                        EDUSTAR_DOMAIN_URI,
                        "NTLM",
                        new NetworkCredential(username, password)
                    }
                };

                var handler = new HttpClientHandler {
                    Credentials = credentialCache
                };

                httpClient = new HttpClient(handler);
            } else {
                httpClient = new HttpClient();
            }

            httpClient.BaseAddress = EDUSTAR_MC_URI;
            httpClient.DefaultRequestHeaders.Add("Accept", "text/xml");

            HttpClient = httpClient;
        }

        internal static void InitialiseUserDetails() {
            var responseTask = HttpClient.GetAsync($"{EDUSTAR_MC_URI.AbsoluteUri}/GetUser");
            var responseResult = responseTask.Result;

            if (responseResult.StatusCode != HttpStatusCode.OK) {
                throw new HttpRequestException($"Could not access \"{responseResult.Headers.Location.AbsoluteUri}\" ({responseResult.StatusCode}).");
            }

            var responseContent = responseResult.Content;
            var responseContentTask = responseContent.ReadAsStringAsync();
            var result = responseContentTask.Result;
            
            CurrentUserData = DeserialiseCurrentUserData(result);
        }

        private static CurrentUserData DeserialiseCurrentUserData(string xmlString) {
            var serializer = new XmlSerializer(typeof(CurrentUserData));

            using (var reader = new StringReader(xmlString)) {
                var deserialisedObject = serializer.Deserialize(reader);
                return deserialisedObject as CurrentUserData;
            }
        }
    }
}
