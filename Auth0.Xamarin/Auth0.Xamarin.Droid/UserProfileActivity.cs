using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
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
        private LoginResult _loginResult;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_user_profile);

            GetLoginResult(savedInstanceState);

            DisplayProfileInfo();
        }

        private void GetLoginResult(Bundle savedInstanceState)
        {
            string loginResultAsJson = Intent.GetStringExtra("LoginResult") ?? string.Empty;
            _loginResult = JsonConvert.DeserializeObject<LoginResult>(loginResultAsJson);
        }

        private void DisplayProfileInfo()
        {
            if (!_loginResult.IsError)
            {
                var name = _loginResult.User.FindFirst(c => c.Type == "name")?.Value;
                var email = _loginResult.User.FindFirst(c => c.Type == "email")?.Value;
                var image = _loginResult.User.FindFirst(c => c.Type == "picture")?.Value;

                FindViewById<TextView>(Resource.Id.userProfileNameTextView).Text = name;
                FindViewById<TextView>(Resource.Id.userProfileEmailTextView).Text = email;

                var imageBitmap = GetImageBitmapFromUrl(image);
                FindViewById<ImageView>(Resource.Id.userProfileImageView).SetImageBitmap(imageBitmap);

            }
        }


        private Bitmap GetImageBitmapFromUrl(string url)
        {
            Bitmap imageBitmap = null;

            using (var webClient = new WebClient())
            {
                var imageBytes = webClient.DownloadData(url);
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }

            return imageBitmap;
        }
    }
}