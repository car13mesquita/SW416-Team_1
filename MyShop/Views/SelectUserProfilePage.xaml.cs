using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MyShop
{
    public partial class SelectUserProfilePage : ContentPage
    {
        SelectUserProfileViewModel viewModel;
        public Action<User> ItemSelected
        {
            get { return viewModel.ItemSelected; }
            set { viewModel.ItemSelected = value; }
        }
        public SelectUserProfilePage(string firstname)
        {
            InitializeComponent();
            BindingContext = viewModel = new SelectUserProfileViewModel(this);

            viewModel.FirstName = firstname;

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (viewModel.Users.Count > 0 || viewModel.IsBusy)
                return;

            viewModel.GetUsersCommand.Execute(null);
        }
    }
}

