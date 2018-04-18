using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MyShop
{
	public partial class FoodListPage : ContentPage
	{
        List<string> Ethnicities;
		public FoodListPage ()
		{
			InitializeComponent();
            BindingContext = new FoodListViewModel(this);
            //ButtonAmerican.Clicked += OnButtonClicked;
            //ButtonChineese.Clicked += OnButtonClicked;
            //ButtonFrench.Clicked += OnButtonClicked;
            //ButtonGreek.Clicked += OnButtonClicked;
            //ButtonJapanese.Clicked += OnButtonClicked;
            //ButtonIndian.Clicked += OnButtonClicked;
            //ButtonItalian.Clicked += OnButtonClicked;
            //ButtonMediterranean.Clicked += OnButtonClicked;
            //ButtonMexican.Clicked += OnButtonClicked;
            //ButtonSpanish.Clicked += OnButtonClicked;
            //ButtonThai.Clicked += OnButtonClicked;

            Ethnicities = new List<string>(new string[] {
                "American",
                "Chinese",
                "French",
                "Greek",
                "Japanese",
                "Indian",
                "Italian",
                "Mediterraean",
                "Mexican",
                "Spanish",
                "Thai"
            });

            StackLayout stackLayout = this.FindByName<StackLayout>("AllergiesAndEthnicities");
            foreach (var ethnicity in Ethnicities)
            {
                Button newButton = new Button()
                {
                    BorderWidth = 2,
                    BorderColor = Color.Black,
                    Text= ethnicity,
                    TextColor= Color.Red,
                };

                newButton.Clicked += OnButtonClicked;

                stackLayout.Children.Add(newButton);
            }
        }
        /*
         * If you use the Text field of the button, provided it's not
         * internationalized, then this can be a completely generic 
         * OnEthnicityButtonClicked method, rather than being specific to
         * the American cuisine.
         */



        async void OnButtonClicked(object sender, EventArgs e)
        {
            if (sender is Xamarin.Forms.Button)
            {
                var senderButton = (Xamarin.Forms.Button)sender;

                var StoresPage = new StoresPage(senderButton.Text);

                await Navigation.PushAsync(StoresPage);
            }
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