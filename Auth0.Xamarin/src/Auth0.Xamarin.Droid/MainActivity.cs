using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Xamarin.Essentials;
using Auth0.OidcClient;
using Android.Content.PM;
using Android.Content;
using Auth0.Xamarin.Droid.Services.Interfaces;
using Auth0.Xamarin.Droid.Services;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Auth0.Xamarin.Droid.Model;

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
    public class MainActivity : AppCompatActivity
    {
        private IAuthenticationService _authenticationService;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Platform.Init(this, savedInstanceState);
            _authenticationService = new AuthenticationService();

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
            var loginResult = await _authenticationService.LoginAsync();

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
        }

        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);

            ActivityMediator.Instance.Send(intent.DataString);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}