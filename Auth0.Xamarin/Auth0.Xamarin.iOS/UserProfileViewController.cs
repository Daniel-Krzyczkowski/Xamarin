using System;
using Auth0.Xamarin.iOS.Model;
using Foundation;
using UIKit;

namespace Auth0.Xamarin.iOS
{
    public partial class UserProfileViewController : UIViewController
    {
        public UserProfile UserProfile { get; set; }

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
                UsernameLabel.Text = UserProfile.Name;
                UserEmailLabel.Text = UserProfile.Email;

                using (var url = new NSUrl(UserProfile.ProfilePictureUrl))
                {
                   var data = NSData.FromUrl(url);
                    UserImageView.Image = UIImage.LoadFromData(data);
                }
        }
    }
}

