using System;
using System.Collections.Generic;
using System.Net.Http;

namespace EduSTAR.MC.API
{
    internal static class Constants
    {
        public static readonly FormUrlEncodedContent NO_POST_CONTENT =
            new FormUrlEncodedContent(new Dictionary<string, string>());

        public static readonly Uri EDUSTAR_DOMAIN_URI = new Uri("https://apps.edustar.vic.edu.au");
        public static readonly Uri EDUSTAR_MC_URI = new Uri(@"https://apps.edustar.vic.edu.au/edustarmc/api/MC");
        public static readonly string EDUSTAR_LOGIN_ENDPOINT = "https://apps.edustar.vic.edu.au/CookieAuth.dll?Logon";
        public static readonly string PC_PUBLIC = "0";
        public static readonly string PC_PRIVATE = "4";
    }
}