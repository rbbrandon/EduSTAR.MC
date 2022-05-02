using System.Net.Http;

namespace EduSTAR.MC.API.Utilities
{
    internal static class Web
    {
        internal static T GetContentAsObject<T>(string fullUrl) where T : class
        {
            var result = GetContentAsString(fullUrl);

            return Convert.XmlStringToObject<T>(result);
        }

        internal static string GetContentAsString(string fullUrl)
        {
            using (var responseResult = SendGetRequest(fullUrl))
            using (var responseContent = responseResult.Content)
            using (var responseContentTask = responseContent.ReadAsStringAsync())
            {
                return responseContentTask.Result;
            }
        }

        private static HttpResponseMessage SendGetRequest(string fullUrl)
        {
            using (var responseTask = Globals.HttpClient.GetAsync(fullUrl))
            using (var responseResult = responseTask.Result)
            {
                if (!responseResult.IsSuccessStatusCode)
                    throw new HttpRequestException(
                        $"Could not access \"{fullUrl}\" ({responseResult.StatusCode}).");

                return responseResult;
            }
        }
    }
}