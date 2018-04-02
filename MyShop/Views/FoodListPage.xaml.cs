using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MyShop
{
	public partial class FoodListPage : ContentPage
	{
		public FoodListPage ()
		{
			InitializeComponent();
            BindingContext = new FoodListViewModel(this);
		}
	}
}