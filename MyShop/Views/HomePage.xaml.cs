﻿using MyShop.Views.Tablet;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MyShop
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            BindingContext = new HomeViewModel(this);
            ButtonSearchEateries.Clicked += async (sender, e) =>
            {
                if (Device.Idiom == TargetIdiom.Tablet || Device.Idiom == TargetIdiom.Desktop)
                    await Navigation.PushAsync(new StoresTabletPage());
                else
                    await Navigation.PushAsync(new StoresPage(null));
            };

            ButtonFoodList.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new FoodListPage());
            };

            ButtonProfile.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new SelectUserProfilePage(null));
            };
        }
    }
}

