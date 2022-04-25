using System;
using System.Net;
using System.Net.Http;
using EduSTAR.MC.API.Models;
using EduSTAR.MC.API.Utilities;
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
            CurrentUserData = Web.GetContentAsObject<CurrentUserData>($"{EDUSTAR_MC_URI}/GetUser");
        }
    }
}
