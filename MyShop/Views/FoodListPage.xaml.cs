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
            ButtonAmerican.Clicked += OnButtonAmericanClicked;
            ButtonChineese.Clicked += OnButtonChineeseClicked;
            ButtonFrench.Clicked += OnButtonFrenchClicked;
            ButtonGreek.Clicked += OnButtonGreekClicked;
            ButtonJapanese.Clicked += OnButtonJapaneseClicked;
            ButtonIndian.Clicked += OnButtonIndianClicked;
            ButtonItalian.Clicked += OnButtonItalianClicked;
            ButtonMediterranean.Clicked += OnButtonMediterraneanClicked;
            ButtonMexican.Clicked += OnButtonMexicanClicked;
            ButtonSpanish.Clicked += OnButtonSpanishClicked;
            ButtonThai.Clicked += OnButtonThaiClicked;
           


        }
        /**
         * If you use the Text field of the button, provided it's not
         * internationalized, then this can be a completely generic 
         * OnEthnicityButtonClicked method, rather than being specific to
         * the American cuisine.
         */


        async void OnButtonAmericanClicked (object sender, EventArgs e)
        {
            if (sender is Xamarin.Forms.Button)
            {
                var senderButton = (Xamarin.Forms.Button)sender;

                var StoresPage = new StoresPage(senderButton.Text);

                await Navigation.PushAsync(StoresPage);
            }
        }

        async void OnButtonChineeseClicked(object sender, EventArgs e)
        {
            if (sender is Xamarin.Forms.Button)
            {
                var senderButton = (Xamarin.Forms.Button)sender;

                var StoresPage = new StoresPage(senderButton.Text);

                await Navigation.PushAsync(StoresPage);
            }
        }


        async void OnButtonFrenchClicked(object sender, EventArgs e)
        {
            if (sender is Xamarin.Forms.Button)
            {
                var senderButton = (Xamarin.Forms.Button)sender;

                var StoresPage = new StoresPage(senderButton.Text);

                await Navigation.PushAsync(StoresPage);
            }
        }


        async void OnButtonGreekClicked(object sender, EventArgs e)
        {
            if (sender is Xamarin.Forms.Button)
            {
                var senderButton = (Xamarin.Forms.Button)sender;

                var StoresPage = new StoresPage(senderButton.Text);

                await Navigation.PushAsync(StoresPage);
            }
        }



        async void OnButtonJapaneseClicked(object sender, EventArgs e)
        {
            if (sender is Xamarin.Forms.Button)
            {
                var senderButton = (Xamarin.Forms.Button)sender;

                var StoresPage = new StoresPage(senderButton.Text);

                await Navigation.PushAsync(StoresPage);
            }
        }


        async void OnButtonIndianClicked(object sender, EventArgs e)
        {
            if (sender is Xamarin.Forms.Button)
            {
                var senderButton = (Xamarin.Forms.Button)sender;

                var StoresPage = new StoresPage(senderButton.Text);

                await Navigation.PushAsync(StoresPage);
            }
        }


        async void OnButtonItalianClicked(object sender, EventArgs e)
        {
            if (sender is Xamarin.Forms.Button)
            {
                var senderButton = (Xamarin.Forms.Button)sender;

                var StoresPage = new StoresPage(senderButton.Text);

                await Navigation.PushAsync(StoresPage);
            }
        }


        async void OnButtonMediterraneanClicked(object sender, EventArgs e)
        {
            if (sender is Xamarin.Forms.Button)
            {
                var senderButton = (Xamarin.Forms.Button)sender;

                var StoresPage = new StoresPage(senderButton.Text);

                await Navigation.PushAsync(StoresPage);
            }
        }


        async void OnButtonMexicanClicked(object sender, EventArgs e)
        {
            if (sender is Xamarin.Forms.Button)
            {
                var senderButton = (Xamarin.Forms.Button)sender;

                var StoresPage = new StoresPage(senderButton.Text);

                await Navigation.PushAsync(StoresPage);
            }
        }

        async void OnButtonSpanishClicked(object sender, EventArgs e)
        {
            if (sender is Xamarin.Forms.Button)
            {
                var senderButton = (Xamarin.Forms.Button)sender;

                var StoresPage = new StoresPage(senderButton.Text);

                await Navigation.PushAsync(StoresPage);
            }
        }

        async void OnButtonThaiClicked(object sender, EventArgs e)
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