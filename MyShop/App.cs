﻿using MyShop.Services;
using System;
using System.Linq;
using Xamarin.Forms;

namespace MyShop
{
    public static class ViewModelLocator
    {
	static bool UseDesignTime => false;

        static ReviewViewModel reviewVM;

        public static ReviewViewModel ReviewViewModel
        => reviewVM ?? (reviewVM = new ReviewViewModel(null));


        static StoresViewModel storesViewModel;

        public static StoresViewModel StoresViewModel
        {
            get
            {
		    if(!UseDesignTime)
			    return null;
		    
                if (storesViewModel != null)
                    return storesViewModel;
                              
                storesViewModel = new StoresViewModel(null);
                storesViewModel.GetStoresCommand.Execute(null);
                return storesViewModel;
            }
        }

        static SelectUserProfileViewModel selectuserprofileViewModel;

        public static SelectUserProfileViewModel SelectUserProfileViewModel
        {
            get
            {
                if (!UseDesignTime)
                    return null;

                if (storesViewModel != null)
                    return selectuserprofileViewModel;

                selectuserprofileViewModel = new SelectUserProfileViewModel(null);
                selectuserprofileViewModel.GetUsersCommand.Execute(null);
                return selectuserprofileViewModel;
            }
        }

        static StoreViewModel storeViewModel;

        public static StoreViewModel StoreViewModel
        { 
            get
            {
		    
		    if(!UseDesignTime)
			    return null;
		    
                if (storeViewModel != null)
                    return storeViewModel;

                var offline = new OfflineDataStore();
                var task = offline.GetStoresAsync();
                task.Wait();
                var store = task.Result.First();
                storeViewModel = new StoreViewModel(store, null);
                return storeViewModel;
            }
        }

    }
    public class App : Application
	{
		public App ()
		{
			// The root page of your application
			MainPage = new NavigationPage(new HomePage())
			{
				BarTextColor = Color.White,
                BarBackgroundColor = Color.FromHex("#89F4B4")
			};
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

