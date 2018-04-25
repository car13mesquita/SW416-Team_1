using Plugin.Messaging;
using MyShop.Services;
using Newtonsoft.Json;
using PCLStorage;
using Plugin.EmbeddedResource;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(OfflineDataStore))]
namespace MyShop.Services
{
    public class OfflineDataStore : IDataStore
    {

        public async Task<IEnumerable<Store>> GetStoresAsync()
        {
            var json = ResourceLoader.GetEmbeddedResourceString(Assembly.Load(new AssemblyName("MyShop")), "stores.json");
            return await Task.Run(() => JsonConvert.DeserializeObject<List<Store>>(json));
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            var json = ResourceLoader.GetEmbeddedResourceString(Assembly.Load(new AssemblyName("MyShop")), "users.json");
            return await Task.Run(() => JsonConvert.DeserializeObject<List<User>>(json));
        }

        public async Task<Review> AddReviewAsync(Review review)
        {
            var emailTask = CrossMessaging.Current.EmailMessenger;
            if (emailTask.CanSendEmail)
            {
                emailTask.SendEmail("", "My Shop Review", review.ToString());
            }

            return await Task.Run(() => { return review; });
        }

        public Task<Store> AddStoreAsync(Store store)
        {
            return Task.FromResult(store);
        }

        public async Task<IEnumerable<Review>> GetReviewAsync()
        {
            return await Task.Run(() => { return new List<Review>(); });
        }


        public Task Init()
        {
            return Task.Run(() => { });
        }

        public Task<bool> RemoveReviewAsync(Review review)
        {
            return Task.FromResult(true);
        }

        public Task<bool> RemoveStoreAsync(Store store)
        {
            return Task.FromResult(true);
        }

        public Task SyncReviewsAsync()
        {
            return Task.Run(() => { });
        }

        public Task SyncStoresAsync()
        {
            return Task.Run(() => { });
        }

        public Task SyncUsersAsync()
        {
            return Task.Run(() => { });
        }

        public Task<Store> UpdateStoreAsync(Store store)
        {
            return Task.FromResult(store);
        }
    }
}
