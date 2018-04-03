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

        SelectMultipleBasePage<CheckItem> multiPage;
        async void OnClick(object sender, EventArgs ea)
        {
            var items = new List<CheckItem>();
            items.Add(new CheckItem { Name = "American" });
            items.Add(new CheckItem { Name = "Chinese" });
            items.Add(new CheckItem { Name = "Italian" });
            items.Add(new CheckItem { Name = "Japanese" });
            items.Add(new CheckItem { Name = "French" });
            items.Add(new CheckItem { Name = "Greek" });
            items.Add(new CheckItem { Name = "Thai" });
            items.Add(new CheckItem { Name = "Spanish" });
            items.Add(new CheckItem { Name = "Indian" });
            items.Add(new CheckItem { Name = "Mediterranean" });
            items.Add(new CheckItem { Name = "Mexican" });

            if (multiPage == null)
                multiPage = new SelectMultipleBasePage<CheckItem>(items) { Title = "Check all that apply" };

            await Navigation.PushAsync(multiPage);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (multiPage != null)
            {
                results.Text = "";
                var answers = multiPage.GetSelection();
                foreach (var a in answers)
                {
                    results.Text += a.Name + ", ";
                }
            }
            else
            {
                results.Text = "(none)";
            }
        }
    }
}