using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IdentityModel.OidcClient;
using IdentityModel.OidcClient.Browser;

namespace Auth0.Xamarin.iOS.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<LoginResult> LoginAsync();
        Task<BrowserResultType> LogoutAsync();
    }
}