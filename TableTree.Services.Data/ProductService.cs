using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using TableTree.Data.Models;
using TableTree.Data.Repository.Interfaces;
using TableTree.Services.Data.Interfaces;
using TableTree.Web.ViewModels.Product;

namespace TableTree.Services.Data
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> productRepository;
        private readonly IRepository<Comment> commentRepository;

		public ProductService(IRepository<Product> productRepository, IRepository<Comment>? commentRepository)
        {
            this.productRepository = productRepository;
            this.commentRepository = commentRepository;
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

            await this.productRepository.AddAsync(product);
        }

        public async Task<bool> EditProductAsync(EditProductViewModel model)
        {
            Product product = await this.GetProductByIdAsync(model.Id);

            product.Name = model.Name;
            product.Price = model.Price;
            product.ImageUrl = model.ImageUrl;
            product.Description = model.Description;
            product.TreeTypeId = model.TreeType;
            product.CategoryId = model.Category;

            bool result = await this.productRepository.UpdateAsync(product);
            await this.productRepository.SaveChangesAsync();
            return result;
        }

        public bool EditProduct(EditProductViewModel model)
        {
            Product product = this.GetProductById(model.Id);

            product.Name = model.Name;
            product.Price = model.Price;
            product.ImageUrl = model.ImageUrl;
            product.Description = model.Description;
            product.TreeTypeId = model.TreeType;
            product.CategoryId = model.Category;

            bool result = this.productRepository.Update(product);
            this.productRepository.SaveChanges();
            return result;
        }

        public async Task<IEnumerable<ProductViewModel>> GetAllProductsAsync()
        {
            IEnumerable<ProductViewModel> products = await this.productRepository
                .GetAllAttached()
                .Where(p => p.IsDeleted == false)
                .AsNoTracking()
                .Select(p => new ProductViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl,
                    TreeType = p.TreeType.Name,
                })
                .ToListAsync();

            return products;
        }
        public Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return this.productRepository.GetAllCategoriesAsync();
        }
        public IEnumerable<Category> GetAllCategories()
        {
            return this.productRepository.GetAllCategories();
        }

        public Task<IEnumerable<TreeType>> GetAllTreeTypesAsync()
        {
            return this.productRepository.GetAllTreeTypesAsync();
        }

        public IEnumerable<TreeType> GetAllTreeTypes()
        {
            return this.productRepository.GetAllTreeTypes();
        }

        public async Task<ProductDetailsViewModel> GetProductDetailsByIdAsync(Guid id)
        {
            var product = this.productRepository
				.GetAllAttached()
                .Include(p => p.Category)
                .Include(p => p.TreeType)
                .Include(p => p.Comments)
                .ThenInclude(c => c.ApplicationUser)
                .Include(p => p.ProductStores.Where(ps => ps.IsDeleted == false))
                .ThenInclude(ps => ps.Store)
                .FirstOrDefault(p => p.Id == id);

            ProductDetailsViewModel model = new ProductDetailsViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                Category = product.Category,
                TreeType = product.TreeType,
                ProductStores = product.ProductStores,
                Comments = product.Comments,
            };

            return model;
        }
        public async Task<EditProductViewModel> GetProductForEditByIdAsync(Guid id)
        {
            var model = this.productRepository
				.GetAllAttached()
                .Select(p => new EditProductViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl,
                    Category = p.Category.Id,
                    TreeType = p.TreeType.Id,
                })
                .FirstOrDefault(p => p.Id.ToString().ToLower() == id.ToString().ToLower());

            return model;
        }

        public EditProductViewModel GetProductForEditById(Guid id)
        {
            EditProductViewModel? model = new EditProductViewModel();

            model.Categories = this.productRepository.GetAllCategories();
            model.TreeTypes = this.productRepository.GetAllTreeTypes();
            
            model = this.productRepository
				.GetAll()
                .Select(p => new EditProductViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl,
                    Category = p.Category.Id,
                    TreeType = p.TreeType.Id,
                })
                .FirstOrDefault(p => p.Id.ToString().ToLower() == id.ToString().ToLower());

            return model;
        }

        public async Task<DeleteProductViewModel> GetProductForDelete(Guid id)
        {
            var model = this.productRepository
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
        public async Task AddCommentToProduct(CommentInputModel model)
        {
            var allComents = await commentRepository.GetAllAsync();

            var applicationUser = model.ApplicationUser;

			Comment comment = new Comment()
			{
				Id = Guid.NewGuid(),
				ApplicationUserId = model.ApplicationUserId,
				ApplicationUser = model.ApplicationUser,
				CommentDescription = model.CommentDescription,
				PostedOn = DateTime.Now,
				ProductId = model.ProductId,
				Product = model.Product,
			};

			await this.commentRepository.AddAsync(comment);
        }

        public async Task SoftDelete(Guid id)
        {
            var item = await this.productRepository
				.GetByIdAsync(id);

            item.IsDeleted = true;
            await this.productRepository.SaveChangesAsync();
        }

        public Task<Product> GetProductByIdAsync(Guid id)
        {
            var product = this.productRepository.GetByIdAsync(id);
            return product;
        }

        public Product GetProductById(Guid id)
        {
            var product = this.productRepository.GetById(id);
            return product;
        }
    }
}
