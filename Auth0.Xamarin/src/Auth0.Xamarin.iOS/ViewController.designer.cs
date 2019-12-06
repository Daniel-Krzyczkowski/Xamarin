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
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton LoginButton { get; set; }

        [Action ("LoginButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void LoginButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (LoginButton != null) {
                LoginButton.Dispose ();
                LoginButton = null;
            }
        }
    }
}