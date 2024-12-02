using TableTree.Data.Models;
using TableTree.Web.ViewModels.Product;

namespace TableTree.Services.Data.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> GetAllProductsAsync();
        Task AddProductAsync(AddProductInputModel model);
        Task<ProductDetailsViewModel> GetProductDetailsByIdAsync(Guid id);
        Task<EditProductViewModel> GetProductForEditByIdAsync(Guid id); //DONE TESTING
        EditProductViewModel GetProductForEditById(Guid id); //DONE TESTING
        Task<bool> EditProductAsync(EditProductViewModel model);
        bool EditProduct(EditProductViewModel model);
        Task<Product> GetProductByIdAsync(Guid id); //DONE TESTING
		Product GetProductById(Guid id); //DONE TESTING
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<IEnumerable<TreeType>> GetAllTreeTypesAsync();
        IEnumerable<Category> GetAllCategories();
        IEnumerable<TreeType> GetAllTreeTypes();
        Task<DeleteProductViewModel> GetProductForDelete(Guid id);
        Task SoftDelete(Guid id);
    }
}
