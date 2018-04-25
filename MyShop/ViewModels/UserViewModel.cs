using System;
using Xamarin.Forms;
using Plugin.ExternalMaps;
using Plugin.Messaging;
using MyShop.Helpers;

namespace MyShop
{
    public class UserViewModel : ViewModelBase
    {
        public User User { get; set; }
        public string FirstName { get { return User.FirstName; } }

      
        public UserViewModel(User user, Page page) : base(page)
        {
            this.User = user;
        }


    }
}

