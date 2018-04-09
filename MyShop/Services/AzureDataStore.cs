
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using System.Linq;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
using System.Diagnostics;
using System;
using Xamarin.Forms;

//Comment back in to use azure
using MyShop;
using Plugin.Connectivity;

//[assembly: Dependency(typeof(AzureDataStore))]
namespace MyShop
{
    public class AzureDataStore : IDataStore
    {
        public MobileServiceClient MobileService { get; set; }

        IMobileServiceSyncTable<Store> storeTable;
        IMobileServiceSyncTable<Review> reviewTable;
        bool initialized = false;

        public AzureDataStore()
        {
            // This is a sample read-only azure site for demo
            // Follow the readme.md in the GitHub repo on how to setup your own.
            MobileService = new MobileServiceClient(
            "http://myshoppe-demo.azurewebsites.net");
        }

        public async Task Init()
        {
            initialized = true;
            const string path = "syncstore.db";
            var store = new MobileServiceSQLiteStore(path);
            store.DefineTable<Store>();
            store.DefineTable<Review>();
            await MobileService.SyncContext.InitializeAsync(store, new MobileServiceSyncHandler());

            storeTable = MobileService.GetSyncTable<Store>();
            reviewTable = MobileService.GetSyncTable<Review>();
        }


        public async Task<Review> AddReviewAsync(Review review)
        {
            if (!initialized)
                await Init();


            await reviewTable.InsertAsync(review);
            await SyncReviewsAsync();
            return review;
        }

        public async Task<IEnumerable<Review>> GetReviewAsync()
        {

            if (!initialized)
                await Init();

            await reviewTable.PullAsync("allReviews", reviewTable.CreateQuery());

            return await reviewTable.ToEnumerableAsync();
        }

        public async Task<bool> RemoveReviewAsync(Review review)
        {
            if (!initialized)
                await Init();

            await reviewTable.DeleteAsync(review);
            await SyncReviewsAsync();
            return true;
        }

        public async Task<Store> AddStoreAsync(Store store)
        {
            if (!initialized)
                await Init();

            await storeTable.InsertAsync(store);
            await SyncStoresAsync();
            await MobileService.SyncContext.PushAsync();
            return store;
        }
        public async Task<bool> RemoveStoreAsync(Store store)
        {
            if (!initialized)
                await Init();

            await storeTable.DeleteAsync(store);
            await SyncStoresAsync();
            await MobileService.SyncContext.PushAsync();
            return true;
        }
        public async Task<Store> UpdateStoreAsync(Store store)
        {
            if (!initialized)
                await Init();

            await storeTable.UpdateAsync(store);
            await SyncStoresAsync();
            await MobileService.SyncContext.PushAsync();
            return store;
        }

        public async Task<IEnumerable<Store>> GetStoresAsync()
        {
            if (!initialized)
                await Init();

            await SyncStoresAsync();
            return await storeTable.ToEnumerableAsync();
        }

        public async Task SyncStoresAsync()
        {
            try
            {
                if (!CrossConnectivity.Current.IsConnected || !Settings.NeedsSync)
                    return;

                await storeTable.PullAsync("allStores", storeTable.CreateQuery());

                Settings.LastSync = DateTime.Now;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Sync Failed:" + ex.Message);
            }
        }

        public async Task SyncReviewsAsync()
        {
            try
            {
                Settings.NeedSyncReview = true;
                if (!CrossConnectivity.Current.IsConnected)
                    return;


                await MobileService.SyncContext.PushAsync();
                Settings.NeedSyncReview = false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Sync Failed:" + ex.Message);
            }
        }

        static readonly AzureDataStore instance = new AzureDataStore();
        /// <summary>
        /// Gets the instance of the Azure Web Service
        /// </summary>
        public static AzureDataStore Instance
        {
            get
            {
                return instance;
            }
        }

    }
}