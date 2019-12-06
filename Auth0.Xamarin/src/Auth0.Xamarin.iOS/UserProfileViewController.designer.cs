// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Auth0.Xamarin.iOS
{
    [Register ("UserProfileViewController")]
    partial class UserProfileViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel UserEmailLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView UserImageView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel UsernameLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (UserEmailLabel != null) {
                UserEmailLabel.Dispose ();
                UserEmailLabel = null;
            }

            if (UserImageView != null) {
                UserImageView.Dispose ();
                UserImageView = null;
            }

            if (UsernameLabel != null) {
                UsernameLabel.Dispose ();
                UsernameLabel = null;
            }
        }
    }
}