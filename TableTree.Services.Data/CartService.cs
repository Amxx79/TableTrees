using Microsoft.EntityFrameworkCore;
using TableTree.Data.Models;
using TableTree.Data.Repository.Interfaces;
using TableTree.Services.Data.Interfaces;
using TableTree.Web.ViewModels.Cart;

namespace TableTree.Services.Data
{
    public class CartService : ICartService
    {
        private readonly IRepository<ProductClient> productClientRepository;
        private readonly IRepository<Product> productRepository;

        public CartService(IRepository<ProductClient> productClientRepository, IRepository<Product> productRepository)
        {
            this.productClientRepository = productClientRepository;
            this.productRepository = productRepository;
        }

        public async Task AddProductAsync(string productId, string userId)
        {
            Guid productIdentificator = Guid.Parse(productId);
            Guid userIdentificator = Guid.Parse(userId);

            Product? product = this.productRepository
                .GetById(productIdentificator);

            if (product == null)
            {
                return;
            }

            ProductClient? addedToCartAlready = this.productClientRepository.GetAll()
                .FirstOrDefault(pc => pc.ProductId == productIdentificator &&
                pc.ApplicationUserId == userIdentificator);

            if (addedToCartAlready == null)
            {
                ProductClient newProductInCartOfClient = new ProductClient()
                {
                    ApplicationUserId = userIdentificator,
                    ProductId = productIdentificator,
                };

                await productClientRepository.AddAsync(newProductInCartOfClient);
                await productClientRepository.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ProductViewModel>> GetAllProductsInCartAsync()
        {
            IEnumerable<ProductViewModel> model = await this.productClientRepository
                .GetAllAttached()
                .Include(pc => pc.Product)
                .Select(pc => new ProductViewModel()
                {
                    Id = pc.ProductId,
                    ImageUrl = pc.Product.ImageUrl,
                    Name = pc.Product.Name,
                    Price = pc.Product.Price,
                    TreeType = pc.Product.TreeType.Name,
                })
                .ToListAsync();

            return model;
        }
    }
}
