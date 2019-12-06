using System;
namespace Auth0.Xamarin.Droid.Model
{
    public class UserProfile
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string ProfilePictureUrl { get; set; }


        public UserProfile()
        {
        }
    }
}
