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
                .Where(p => p.IsDeleted == false)
                .Select(p => new ProductViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl,
                    TreeType = p.TreeType.Name,
                })
                .ToArrayAsync();

            return products;
        }

        public Task<IEnumerable<Category>> GetAllCategories()
        {
            return this.repository.GetAllCategories();
        }

        public Task<IEnumerable<TreeType>> GetAllTreeTypes()
        {
            return this.repository.GetAllTreeTypes();
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

        public async Task<DeleteProductViewModel> GetProductForDelete(Guid id)
        {
            var model = this.repository
                .GetAllAttached()
                .Select(p => new DeleteProductViewModel()
                {
                    Id = p.Id.ToString(),
                    Name = p.Name,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl,
                    Category = p.Category.Name,
                    TreeType = p.TreeType.Name,
                })
                .FirstOrDefault();

            return model;
        }

        public async Task SoftDelete(Guid id)
        {
            var item = await this.repository
                .GetByIdAsync(id);

            item.IsDeleted = true;
            await this.repository.SaveChangesAsync();
        }

        public Task<Product> GetProductById(Guid id)
        {
            var product = this.repository.GetByIdAsync(id);
            return product;
        }
    }
}
