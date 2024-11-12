using TableTree.Web.ViewModels.Cart;
namespace TableTree.Services.Data.Interfaces
{
    public interface ICartService
    {
        /*All, Add, Remove, Buy */
        Task<IEnumerable<ProductViewModel>> GetAllProductsInCartAsync();
        Task AddProductAsync(string productId, string userId);
        Task RemoveProduct(string productId, string userId);


    }
}
