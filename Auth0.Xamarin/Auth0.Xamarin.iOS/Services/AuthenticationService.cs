using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auth0.OidcClient;
using Auth0.Xamarin.iOS.Services.Interfaces;
using IdentityModel.OidcClient;

namespace Auth0.Xamarin.iOS.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly Auth0Client _auth0Client;

        public AuthenticationService()
        {
            _auth0Client = new Auth0Client(new Auth0ClientOptions
            {
                Domain = "",
                ClientId = ""
            });
        }

        public async Task<LoginResult> LoginAsync()
        {
            var loginResult = await _auth0Client.LoginAsync();
            return loginResult;
        }
    }
}