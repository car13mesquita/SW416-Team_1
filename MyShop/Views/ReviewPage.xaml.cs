using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MyShop
{

    //Based on https://github.com/jamesmontemagno/MediaPlugin License info below.

    public partial class ReviewPage : ContentPage
    {
        ReviewViewModel viewModel;
        public ReviewPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ReviewViewModel(this);

            ButtonTakePhoto.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new CaptureMediaPage());
            };

            PickerRating.SelectedIndex = 10;
            PickerServiceType.SelectedIndex = 0;

            PickerStore.SelectedIndexChanged += (sender, e) =>
            {
                viewModel.StoreName = PickerStore.Items[PickerStore.SelectedIndex];
            };

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var showAlert = false;
            try
            {
                var stores = await viewModel.GetStoreAsync();
                foreach (var store in stores)
                    PickerStore.Items.Add(store.Name);
            }
            catch (Exception ex)
            {

                showAlert = true;
            }
            if (showAlert)
                await DisplayAlert("Uh oh :(", "Unable to get locations, don't worry you can still submit review.", "OK");


        }
    }
}

//
//  Copyright 2011-2013, Xamarin Inc.
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//
//        http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
//