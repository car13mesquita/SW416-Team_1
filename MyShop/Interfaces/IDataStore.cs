using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MyShop
{
    public interface IDataStore
    {
        Task Init();
        Task<IEnumerable<Store>> GetStoresAsync();
        Task<Store> AddStoreAsync(Store store);
        Task<bool> RemoveStoreAsync(Store store);
        Task<Store> UpdateStoreAsync(Store store);
        Task<Review> AddReviewAsync(Review review);
        Task<IEnumerable<Review>> GetReviewAsync();
        Task<bool> RemoveReviewAsync(Review review);
        Task SyncStoresAsync();
        Task SyncReviewsAsync();
    }
}

