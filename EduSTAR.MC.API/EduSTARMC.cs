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
    public class EduSTARMC
    {
        /// <summary>
        /// Create an <c>EduSTARMC</c> object and connect using the provided credentials.
        /// </summary>
        /// <param name="credentials">eduPass credentials to use when connecting.</param>
        public EduSTARMC(NetworkCredential credentials) {
            Connect(credentials?.UserName, credentials?.Password);
        }

        /// <summary>
        /// Create an <c>EduSTARMC</c> object and connect using the provided credentials.
        /// </summary>
        /// <param name="username">eduPass username to use when connecting.</param>
        /// <param name="password">eduPass password to use when connecting.</param>
        public EduSTARMC(string username, string password) {
            Connect(username, password);
        }

        private static void Connect(string username, string password) {
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

        /// <summary>
        /// Sets a specified School as the default for any function calls in this object instance.
        /// </summary>
        /// <param name="school">The <c>School</c> object to set as the default for this <c>EduSTARMC</c> object.</param>
        /// <exception cref="ArgumentException">Thrown when the given school has a SchoolId that is not in the user's list of accessible schools.</exception>
        public void SetDefaultSchool(School school) {
            SetDefaultSchool(school.SchoolId);
        }

        /// <summary>
        /// Sets a specified School as the default for any function calls in this object instance.
        /// </summary>
        /// <param name="schoolId">The 4-digit school number of the desired school.</param>
        /// <exception cref="ArgumentException">Thrown when the given schoolId is not in the user's list of accessible schools.</exception>
        public void SetDefaultSchool(int schoolId) {
            SetDefaultSchool(schoolId.ToString());
        }

        /// <summary>
        /// Sets a specified School as the default for any function calls in this object instance.
        /// </summary>
        /// <param name="schoolId">The 4-digit school number of the desired school.</param>
        /// <exception cref="ArgumentException">Thrown when the given schoolId is not in the user's list of accessible schools.</exception>
        public void SetDefaultSchool(string schoolId) {
            Globals.SelectedSchoolId = schoolId;
        }

        /// <summary>
        /// Gets an array of <c>School</c> objects from the eduSTAR Management Centre containing basic information about those schools.
        /// </summary>
        /// <remarks>Only contains schools that the connection account has access to.</remarks>
        /// <returns>An array of <c>School</c> objects from the eduSTAR Management Centre that the user has access to.</returns>
        /// <exception cref="HttpRequestException">Thrown when there is an error in receiving the XML string from the eduSTAR Management Console.</exception>
        /// <exception cref="InvalidOperationException">Thrown when there is an error in deserialising the received XML.</exception>
        public School[] GetSchools() {
            var schoolArray = Web.GetContentAsObject<ArrayOfSchool>($"{EDUSTAR_MC_URI}/GetAllSchools");

            return schoolArray.Items;
        }

        /// <summary>
        /// Gets an array of School IDs for every school that is enabled in the eduSTAR Management Centre.
        /// </summary>
        /// <returns>A <c>string[]</c> containing the School IDs of all eduSTAR-enabled schools.</returns>
        /// <exception cref="HttpRequestException">Thrown when there is an error in receiving the XML string from the eduSTAR Management Console.</exception>
        /// <exception cref="InvalidOperationException">Thrown when there is an error in deserialising the received XML.</exception>
        public string[] GetAllEnabledSchoolIds() {
            var schoolArray = Web.GetContentAsObject<ArrayOfstring>($"{EDUSTAR_MC_URI}/GetAllEnabledSchools");

            return schoolArray.Items;
        }
    }
}