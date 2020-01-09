using Android.App;
using Android.OS;
using Android.Widget;
using Xamarin.Essentials;
using Auth0.OidcClient;
using Android.Content.PM;
using Android.Content;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Auth0.Xamarin.Droid.Model;
using System;
using IdentityModel.OidcClient.Browser;

namespace Auth0.Xamarin.Droid
{
    [Activity(Label = "@string/app_name", MainLauncher = true,
    LaunchMode = LaunchMode.SingleTask)]
    [IntentFilter(
    new[] { Intent.ActionView },
    Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable },
    DataScheme = "com.auth0.xamarin.droid",
    DataHost = "devisland.eu.auth0.com",
    DataPathPrefix = "/android/com.auth0.xamarin.droid/callback")]
    public class MainActivity : Auth0ClientActivity
    {
        private Auth0Client _auth0Client;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Platform.Init(this, savedInstanceState);

            _auth0Client = new Auth0Client(new Auth0ClientOptions
            {
                Domain = "",
                ClientId = ""
            });

            SetContentView(Resource.Layout.activity_main);
            var loginButton = FindViewById<Button>(Resource.Id.loginButton);
            loginButton.Click += LoginButton_Click;
        }

        private async void LoginButton_Click(object sender, System.EventArgs e)
        {
            await LoginAsync();
        }

        private async Task LoginAsync()
        {
            var loginResult = await _auth0Client.LoginAsync(new { audience = "devisland" });

            if (!loginResult.IsError)
            {
                var name = loginResult.User.FindFirst(c => c.Type == "name")?.Value;
                var email = loginResult.User.FindFirst(c => c.Type == "email")?.Value;
                var image = loginResult.User.FindFirst(c => c.Type == "picture")?.Value;

                var userProfile = new UserProfile
                {
                    Email = email,
                    Name = name,
                    ProfilePictureUrl = image
                };

                var intent = new Intent(this, typeof(UserProfileActivity));
                var serializedLoginResponse = JsonConvert.SerializeObject(userProfile);
                intent.PutExtra("LoginResult", serializedLoginResponse);
                StartActivity(intent);

            }

            else
            {
                Console.WriteLine($"An error occurred during login: {loginResult.Error}");
            }
        }

        private async Task<BrowserResultType> LogoutAsync()
        {
            return await _auth0Client.LogoutAsync();
        }
    }
}
