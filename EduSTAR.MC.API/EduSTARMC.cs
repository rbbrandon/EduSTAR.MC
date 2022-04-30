using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Security.Authentication;
using EduSTAR.MC.API.Models;
using EduSTAR.MC.API.Utilities;
using EduSTAR.MC.API.Validators;
using static EduSTAR.MC.API.Constants;

namespace EduSTAR.MC.API
{
    public static class EduSTARMC
    {
        public static void Connect(NetworkCredential credentials) {
            Connect(credentials?.UserName, credentials?.Password);
        }

        public static void Connect(string username, string password) {
            if (!CredentialValidator.IsValidCredentials(username, password)) {
                throw new InvalidCredentialException(
                    "Required credentials are missing. Please provide a valid username and password.");
            }

            Globals.InitialiseHttpClient();

            var connectionRequestBody = BuildConnectionRequestBody(username, password);

            if (TryLogin(connectionRequestBody)) {
                Globals.InitialiseUserDetails();
                return;
            }

            Globals.InitialiseHttpClient(username, password);

            if (TryLogin(connectionRequestBody)) {
                Globals.InitialiseUserDetails();
                return;
            }

            throw new InvalidCredentialException(
                "Connection failed. Please ensure that a valid username and password is specified.");
        }

        private static FormUrlEncodedContent BuildConnectionRequestBody(string username, string password) {
            var connectionRequestBody = new Dictionary<string, string> {
                { "curl", "Z2Fedustarmc" },
                { "flags", "0" },
                { "formdir", "3" },
                { "forcedownlevel", "0" },
                { "trusted", PC_PRIVATE },
                { "username", username },
                { "password", password }
            };

            return new FormUrlEncodedContent(connectionRequestBody);
        }

        private static bool TryLogin(HttpContent connectionRequestBody) {
            var response = Globals.HttpClient.PostAsync(EDUSTAR_LOGIN_ENDPOINT, connectionRequestBody);
            var responseResult = response.Result;

            return responseResult.StatusCode == HttpStatusCode.OK;
        }

        public static void SetDefaultSchool(SchoolItem schoolItem) {
            SetDefaultSchool(schoolItem.SchoolId);
        }

        public static void SetDefaultSchool(int schoolId) {
            SetDefaultSchool(schoolId.ToString());
        }

        public static void SetDefaultSchool(string schoolId) {
            Globals.SelectedSchoolId = schoolId;
        }

        public static SchoolArray GetSchoolArray() {
            return Web.GetContentAsObject<SchoolArray>($"{EDUSTAR_MC_URI}/GetAllSchools");
        }
    }
}