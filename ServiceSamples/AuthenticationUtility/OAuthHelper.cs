using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationUtility
{
    public class OAuthHelper
    {
        private static string _authorizationHeader;
        private static AuthenticationResult _authResult { get; set; }
        /// <summary>
        /// The header to use for OAuth.
        /// </summary>
        public const string OAuthHeader = "Authorization";
        /// <summary>
        /// Retrieves an authentication header from the service.
        /// </summary>
        /// <returns>The authentication header for the Web API call.</returns>
        public static async Task<string> AuthorizationHeader()
        {
            string aadTenant = ClientConfiguration.Default.ActiveDirectoryTenant;
            string aadClientAppId = ClientConfiguration.Default.ActiveDirectoryClientAppId;
            string aadResource = ClientConfiguration.Default.ActiveDirectoryResource;
            // Added following two
            string azureEndPoint = ClientConfiguration.Default.AzureAuthEndPoint;
            string aadClientSecret = ClientConfiguration.Default.AADClientSecret;
            try
            {
                if (!string.IsNullOrEmpty(_authorizationHeader) &&
                DateTime.UtcNow.AddSeconds(180) < _authResult.ExpiresOn) return _authorizationHeader;
                var uri = new UriBuilder(azureEndPoint) { Path = aadTenant };
                var authContext = new AuthenticationContext(uri.ToString());
                var credentials = new ClientCredential(aadClientAppId, aadClientSecret);
                bool validateAuthority = authContext.ValidateAuthority;
                _authResult = await authContext.AcquireTokenAsync(aadResource, credentials);
                _authorizationHeader = _authResult.CreateAuthorizationHeader();
                return _authorizationHeader;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
    }
}
