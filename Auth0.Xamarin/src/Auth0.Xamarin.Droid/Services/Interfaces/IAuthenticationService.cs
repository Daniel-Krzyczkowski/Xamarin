using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using IdentityModel.OidcClient;
using IdentityModel.OidcClient.Browser;

namespace Auth0.Xamarin.Droid.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<LoginResult> LoginAsync();
        Task<BrowserResultType> LogoutAsync();
    }
}