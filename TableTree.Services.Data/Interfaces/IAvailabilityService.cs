using TableTree.Web.ViewModels.Product;

namespace TableTree.Services.Data.Interfaces
{
    public interface IAvailabilityService
    {
        Task<AddProductToStoreViewModel> GetAddProductToStoreAsync(string productId, string storeId);
        Task AddProductToStoreAsync(AddProductToStoreViewModel model);
        Task RemoveProductFromStore(string productId, string storeId);
    }
}
