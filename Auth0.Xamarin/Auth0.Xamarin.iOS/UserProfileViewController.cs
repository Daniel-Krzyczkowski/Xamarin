using System;
using Foundation;
using IdentityModel.OidcClient;
using UIKit;

namespace Auth0.Xamarin.iOS
{
    public partial class UserProfileViewController : UIViewController
    {
        public LoginResult LoginResult { get; set; }

        public UserProfileViewController() : base("UserProfileViewController", null)
        {
        }

        public UserProfileViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            DisplayProfileInfo();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        private void DisplayProfileInfo()
        {
            if (!LoginResult.IsError)
            {
                var name = LoginResult.User.FindFirst(c => c.Type == "name")?.Value;
                var email = LoginResult.User.FindFirst(c => c.Type == "email")?.Value;
                var image = LoginResult.User.FindFirst(c => c.Type == "picture")?.Value;

                UsernameLabel.Text = name;
                UserEmailLabel.Text = email;

                using (var url = new NSUrl(image))
                {
                   var data = NSData.FromUrl(url);
                    UserImageView.Image = UIImage.LoadFromData(data);
                }
            }
        }
    }
}

