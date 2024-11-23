using TableTree.Web.ViewModels.Cart;
namespace TableTree.Services.Data.Interfaces
{
    public interface ICartService
    {
        /*All, Add, Remove, Buy */
        Task<IEnumerable<ProductViewModel>> GetAllProductsInCartAsync(string userId);
        Task AddProductAsync(string productId, string userId, int quantity);
        Task RemoveProduct(string productId, string userId);
    }
}
