using System;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using static System.DateTime;

namespace MyShop
{
    public class ReviewViewModel : ViewModelBase
    {
        IDataStore dataStore;
        public ReviewViewModel(Page page) : base(page)
        {
            dataStore = DependencyService.Get<IDataStore>();
            Title = "Leave Review";
        }

        public async Task<IEnumerable<Store>> GetStoreAsync()
        {
            if (IsBusy)
                return new List<Store>();

            IsBusy = true;
            try
            {
                return await dataStore.GetStoresAsync() ?? new List<Store>();

            }
            catch (Exception ex)
            {
                await page.DisplayAlert("Uh Oh :(", "Unable to gather stores.", "OK");
            }
            finally
            {
                IsBusy = false;
            }

            return new List<Store>();
        }

        Command saveReviewCommand;
        public Command SaveReviewCommand
        {
            get
            {
                return saveReviewCommand ??
                    (saveReviewCommand = new Command(async () => await ExecuteSaveReviewCommand(), () => { return !IsBusy; }));
            }
        }

        async Task ExecuteSaveReviewCommand()
        {
            if (IsBusy)
                return;

            if (string.IsNullOrWhiteSpace(Text))
            {
                await page.DisplayAlert("Enter Review", "Please enter some review for our team.", "OK");
                return;
            }

            Message = "Submitting review...";
            IsBusy = true;
            saveReviewCommand?.ChangeCanExecute();

            try
            {
                await dataStore.AddReviewAsync(new Review
                {
                    Text = this.Text,
                    ReviewDate = UtcNow,
                    VisitDate = Date,
                    Rating = Rating,
                    ServiceType = ServiceType,
                    StoreName = StoreName,
                    Name = Name,
                    PhoneNumber = PhoneNumber,
                    RequiresCall = RequiresCall,
                });
            }
            catch (Exception ex)
            {
                await page.DisplayAlert("Uh Oh :(", "Unable to save review, please try again.", "OK");
            }
            finally
            {
                IsBusy = false;
                saveReviewCommand?.ChangeCanExecute();
            }

            await page.Navigation.PopAsync();

        }

        bool requiresCall = false;
        public bool RequiresCall
        {
            get { return requiresCall; }
            set { SetProperty(ref requiresCall, value); }
        }


        string phone = string.Empty;
        public string PhoneNumber
        {
            get { return phone; }
            set { SetProperty(ref phone, value); }
        }

        string name = string.Empty;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        string message = "Loading...";
        public string Message
        {
            get { return message; }
            set { SetProperty(ref message, value); }
        }

        string text = string.Empty;
        public string Text
        {
            get { return text; }
            set { SetProperty(ref text, value); }
        }

        int serviceType = 4;
        public int ServiceType
        {
            get { return serviceType; }
            set
            {
                SetProperty(ref serviceType, value);
            }
        }

        int rating = 10;
        public int Rating
        {
            get { return rating; }
            set
            {
                SetProperty(ref rating, value);
            }
        }

        DateTime date = Today;
        public DateTime Date
        {
            get { return date; }
            set
            {
                SetProperty(ref date, value);
            }
        }

        public string StoreName { get; set; } = string.Empty;

    }
}

