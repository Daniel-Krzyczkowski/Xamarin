using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using IdentityModel.OidcClient;
using Newtonsoft.Json;

namespace Auth0.Xamarin.Droid
{
    [Activity(Label = "UserProfileActivity")]
    public class UserProfileActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_user_profile);

           var loginResult = GetLoginResult(savedInstanceState);
        }

        private LoginResult GetLoginResult(Bundle savedInstanceState)
        {
            string loginResultAsJson = Intent.GetStringExtra("LoginResult") ?? string.Empty;
            var loginResult = JsonConvert.DeserializeObject<LoginResult>(loginResultAsJson);
            return loginResult;
        }
    }
}