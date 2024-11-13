using TableTree.Web.ViewModels.Favourite;

namespace TableTree.Services.Data.Interfaces
{
    public interface IFavouriteService
    {
        /*All, Add, Remove, Buy */
        Task<IEnumerable<ProductViewModel>> GetAllProductsInFavouritesAsync();
        Task AddProductAsync(string productId, string userId);
        Task RemoveProduct(string productId, string userId);
    }
}
