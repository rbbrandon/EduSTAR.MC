using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace EduSTAR.MC.API.Validators
{
    internal static class CredentialValidator
    {
        internal static bool IsValidCredentials(NetworkCredential credentials) {
            return credentials != null && IsValidCredentials(credentials.UserName, credentials.Password);
        }

        internal static bool IsValidCredentials(string username, string password) {
            return (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password));
        }
    }
}
