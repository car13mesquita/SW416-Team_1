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
            items.Add(new CheckItem { Name = "Allergy - Dairy" });
            items.Add(new CheckItem { Name = "Allergy - Eggs" });
            items.Add(new CheckItem { Name = "Allergy - Fish" });
            items.Add(new CheckItem { Name = "Allergy - Peanuts" });
            items.Add(new CheckItem { Name = "Allergy - Shellfish" });
            items.Add(new CheckItem { Name = "Allergy - Soy" });
            items.Add(new CheckItem { Name = "Allergy - Tree Nuts" });
            items.Add(new CheckItem { Name = "Allergy - Wheat" });
            items.Add(new CheckItem { Name = "Diabetic" });
            items.Add(new CheckItem { Name = "Gluten Free" });
            items.Add(new CheckItem { Name = "Kosher" });
            items.Add(new CheckItem { Name = "Vegan" });
            items.Add(new CheckItem { Name = "Vegetarian" });

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