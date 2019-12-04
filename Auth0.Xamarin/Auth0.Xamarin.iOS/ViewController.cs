using Auth0.Xamarin.iOS.Services;
using Auth0.Xamarin.iOS.Services.Interfaces;
using Foundation;
using System;
using System.Threading.Tasks;
using UIKit;

namespace Auth0.Xamarin.iOS
{
    public partial class ViewController : UIViewController
    {
        private IAuthenticationService _authenticationService;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            _authenticationService = new AuthenticationService();
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
            var loginResult = await _authenticationService.LoginAsync();

            UserProfileViewController controller = new UserProfileViewController();
            controller.LoginResult = loginResult;
            this.PresentViewController(controller, true, null);
        }
    }
}