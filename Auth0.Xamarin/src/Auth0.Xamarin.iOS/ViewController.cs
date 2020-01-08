using Auth0.OidcClient;
using Auth0.Xamarin.iOS.Model;
using IdentityModel.OidcClient.Browser;
using System;
using System.Threading.Tasks;
using UIKit;

namespace Auth0.Xamarin.iOS
{
    public partial class ViewController : UIViewController
    {
        private Auth0Client _auth0Client;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            LoginButton.BackgroundColor = UIColor.FromRGB(245, 126, 66);

            _auth0Client = new Auth0Client(new Auth0ClientOptions
            {
                Domain = "devisland.eu.auth0.com",
                ClientId = "6O0C8Od6U8tZrr8j0WhL5hq4prBkuQml"
            });
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        async partial void LoginButton_TouchUpInside(UIButton sender)
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

                UIStoryboard board = UIStoryboard.FromName("Main", null);
                UserProfileViewController userProfileViewController = (UserProfileViewController)board.InstantiateViewController("UserProfileViewController");

                userProfileViewController.UserProfile = userProfile;
                this.PresentViewController(userProfileViewController, true, null);

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