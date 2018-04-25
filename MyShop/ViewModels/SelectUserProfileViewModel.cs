using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Linq;
using MvvmHelpers;

namespace MyShop
{
    public class SelectUserProfileViewModel : ViewModelBase
    {
        readonly IDataStore dataStore;
        public ObservableRangeCollection<User> Users { get; set; }
        public ObservableRangeCollection<Grouping<string, User>> UsersGrouped { get; set; }
        public bool ForceSync { get; set; }
        public string FirstName { get; set; }

        public SelectUserProfileViewModel(Page page) : base(page)
        {
            Title = "User Profiles";
            dataStore = DependencyService.Get<IDataStore>();
            Users = new ObservableRangeCollection<User>();
            UsersGrouped = new ObservableRangeCollection<Grouping<string, User>>();
            FirstName = null;
        }

        public Action<User> ItemSelected { get; set; }

        User selectUser;
        public User SelectUser
        {
            get { return selectUser; }
            set
            {
                selectUser = value;
                OnPropertyChanged("SelectedUser");
                if (selectUser == null)
                    return;

                if (ItemSelected == null)
                {
                    /*page.Navigation.PushAsync(new UserPage(selectUser));*/
                    SelectUser = null;
                }
                else
                {
                    ItemSelected?.Invoke(selectUser);
                }
            }
        }

        private Command forceRefreshCommand;
        public Command ForceRefreshCommand
        {
            get
            {
                return forceRefreshCommand ??
                    (forceRefreshCommand = new Command(async () =>
                    {
                        ForceSync = true;
                        await ExecuteGetUsersCommand();
                    }));
            }
        }

        private Command getUsersCommand;
        public Command GetUsersCommand
        {
            get
            {
                return getUsersCommand ??
                    (getUsersCommand = new Command(async () => await ExecuteGetUsersCommand(), () => { return !IsBusy; }));
            }
        }

        private async Task ExecuteGetUsersCommand()
        {
            if (IsBusy)
                return;

            if (ForceSync)
                Settings.LastSync = DateTime.Now.AddDays(-30);

            IsBusy = true;
            GetUsersCommand.ChangeCanExecute();
            var showAlert = false;
            try
            {
                Users.Clear();

                var users = await dataStore.GetUsersAsync();

                Users.ReplaceRange(users);
            }
            catch (Exception)
            {
                showAlert = true;

            }
            finally
            {
                IsBusy = false;
                GetUsersCommand.ChangeCanExecute();
            }

            if (showAlert)
                await page.DisplayAlert("Uh Oh :(", "Unable to gather stores.", "OK");


        }

        /* Sorts all the stores by ethincty alphabetically */
        /*
        private void Filter()
        {

            UsersGrouped.Clear();

            var sorted = from user in Users

                         orderby user.Country, store.City
                         group store by store.Ethnicity into storeGroup
                         select new Grouping<string, Store>(storeGroup.Key, storeGroup);


            UsersGrouped.ReplaceRange(sorted);
        }
        */
       
    }

}

