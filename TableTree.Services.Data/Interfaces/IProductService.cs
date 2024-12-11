using TableTree.Data.Models;
using TableTree.Web.ViewModels.Product;

namespace TableTree.Services.Data.Interfaces
{
    public interface IProductService
    {
        Task<AllProductsSearchFilterViewModel> GetAllProductsAsync(AllProductsSearchFilterViewModel? filters);
        Task AddProductAsync(AddProductInputModel model); //DONE TESTING
        Task<ProductDetailsViewModel> GetProductDetailsByIdAsync(Guid id);
        Task<EditProductViewModel> GetProductForEditByIdAsync(Guid id);
        EditProductViewModel GetProductForEditById(Guid id);
        Task<bool> EditProductAsync(EditProductViewModel model);
        bool EditProduct(EditProductViewModel model);
        Task<Product> GetProductByIdAsync(Guid id);
		Product GetProductById(Guid id);
        Task AddCommentToProduct(CommentInputModel model);
		Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<IEnumerable<TreeType>> GetAllTreeTypesAsync();
        IEnumerable<Category> GetAllCategories();
        IEnumerable<TreeType> GetAllTreeTypes();
        Task<DeleteProductViewModel> GetProductForDelete(Guid id);
        Task SoftDelete(Guid id);
    }
}
