using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MyShop
{
    public partial class UserPage : ContentPage
    {
        UserViewModel viewModel;
        public UserPage(User user)
        {
           

        }
        //Xamarin.Forms.Maps.Map MyMap;
        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    if (MyMap == null)
        //        return;
        //    var position = new Position(viewModel.Store.Latitude, viewModel.Store.Longitude); // Latitude, Longitude
        //    var pin = new Pin
        //    {
        //        Type = PinType.Place,
        //        Position = position,
        //        Label = viewModel.Store.Name,
        //        Address = viewModel.Store.StreetAddress
        //    };
        //    MyMap.Pins.Add(pin);

        //    MyMap.MoveToRegion(
        //        MapSpan.FromCenterAndRadius(
        //            position, Distance.FromMiles(.2)));
        //}
    }
}

