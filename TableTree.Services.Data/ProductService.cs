using Microsoft.EntityFrameworkCore;
using TableTree.Data.Models;
using TableTree.Data.Repository.Interfaces;
using TableTree.Services.Data.Interfaces;
using TableTree.Web.ViewModels.Product;

namespace TableTree.Services.Data
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> repository;

        public ProductService(IRepository<Product> repository)
        {
            this.repository = repository;
        }

        public async Task AddProductAsync(AddProductInputModel model)
        {
            Product product = new Product()
            {
                Name = model.Name,
                Price = model.Price,
                ImageUrl = model.ImageUrl,
                Description = model.Description,
                TreeTypeId = model.TreeType,
                CategoryId = model.Category,
            };

            await this.repository.AddAsync(product);
        }

        public async Task<bool> EditProductAsync(EditProductViewModel model)
        {
            Product product = new Product()
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                ImageUrl = model.ImageUrl,
            };

            bool result = await this.repository.UpdateAsync(product);
            return result;

        }
        public async Task<IEnumerable<ProductViewModel>> GetAllProductsAsync()
        {
            IEnumerable<ProductViewModel> products = await this.repository
                .GetAllAttached()
                .Select(p => new ProductViewModel()
                {
                    Name = p.Name,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl,
                    TreeType = p.TreeType.ToString(),
                })
                .ToArrayAsync();
                

            return products;
        }

        public async Task<ProductDetailsViewModel> GetProductDetailsByIdAsync(Guid id)
        {
            var product = this.repository
                .GetAllAttached()
                .Include(p => p.Category)
                .Include(p => p.TreeType)
                .FirstOrDefault(p => p.Id == id);

            ProductDetailsViewModel model = new ProductDetailsViewModel()
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                Category = product.Category,
                TreeType = product.TreeType
            };

            return model;
        }
        public async Task<EditProductViewModel> GetProductForEditByIdAsync(Guid id)
        {
            var model = this.repository
                .GetAllAttached()
                .Select(p => new EditProductViewModel()
                {
                    Id = p.Id.ToString(),
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl,
                })
                .FirstOrDefault(p => p.Id.ToLower() == id.ToString().ToLower());

            return model;
        }
    }
}
