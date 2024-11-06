using TableTree.Data.Models;
using TableTree.Web.ViewModels.Product;

namespace TableTree.Services.Data.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> GetAllProductsAsync();
        Task AddProductAsync(AddProductInputModel model);
        Task<ProductDetailsViewModel> GetProductDetailsByIdAsync(Guid id);
        Task<EditProductViewModel> GetProductForEditByIdAsync(Guid id);
        Task<bool> EditProductAsync(EditProductViewModel model);
        Task<Product> GetProductById(Guid id);
        Task<IEnumerable<Category>> GetAllCategories();
        Task<IEnumerable<TreeType>> GetAllTreeTypes();
        Task<DeleteProductViewModel> GetProductForDelete(Guid id);
        Task SoftDelete(Guid id);
    }
}
