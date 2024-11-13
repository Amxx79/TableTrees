using Microsoft.EntityFrameworkCore;
using TableTree.Data.Models;
using TableTree.Data.Repository.Interfaces;
using TableTree.Services.Data.Interfaces;
using TableTree.Web.ViewModels.Cart;

namespace TableTree.Services.Data
{
    public class CartService : ICartService
    {
        private readonly IRepository<ShoppingCart> productClientRepository;
        private readonly IRepository<Product> productRepository;

        public CartService(IRepository<ShoppingCart> productClientRepository, IRepository<Product> productRepository)
        {
            this.productClientRepository = productClientRepository;
            this.productRepository = productRepository;
        }

        //public async Task AddProductAsync(string productId, string userId)
        //{
        //    Guid productIdentificator = Guid.Parse(productId);
        //    Guid userIdentificator = Guid.Parse(userId);

        //    Product? product = this.productRepository
        //        .GetById(productIdentificator);

        //    if (product == null)
        //    {
        //        return;
        //    }

        //    ProductClient? addedToCartAlready = this.productClientRepository.GetAll()
        //        .FirstOrDefault(pc => pc.ProductId == productIdentificator &&
        //        pc.ApplicationUserId == userIdentificator);

        //    if (addedToCartAlready == null)
        //    {
        //        ProductClient newProductInCartOfClient = new ProductClient()
        //        {
        //            ApplicationUserId = userIdentificator,
        //            ProductId = productIdentificator,
        //        };

        //        await productClientRepository.AddAsync(newProductInCartOfClient);
        //        await productClientRepository.SaveChangesAsync();
        //    }
        //}

        public Task AddProductAsync(string productId, string userId, int quantity)
        {
            Guid productIdentificator = Guid.Parse(productId);
            Guid userIdentificator = Guid.Parse(userId);

            Product? product = this.productRepository
                .GetById(productIdentificator);

            ShoppingCart? addedToCartAlready = this.productClientRepository.GetAll()
                .FirstOrDefault(pc => pc.ProductId == productIdentificator &&
                pc.ApplicationUserId == userIdentificator);

            if (addedToCartAlready == null)
            {
                ShoppingCart newProductInCartOfClient = new ShoppingCart()
                {
                    ApplicationUserId = userIdentificator,
                    ProductId = productIdentificator,
                    QuantityOfProducts = quantity,
                };

                productClientRepository.Add(newProductInCartOfClient);
                productClientRepository.SaveChanges();
            }
                return Task.CompletedTask;
        }

        public async Task RemoveProduct(string productId, string userId)
        {
            Guid productIdentificator = Guid.Parse(productId);
            Guid userIdentificator = Guid.Parse(userId);

            ShoppingCart? addedToCartAlready = this.productClientRepository.GetAll()
                .FirstOrDefault(pc => pc.ProductId == productIdentificator &&
                pc.ApplicationUserId == userIdentificator);

            if (addedToCartAlready != null)
            {
                this.productClientRepository.Delete(addedToCartAlready);
                await this.productClientRepository.SaveChangesAsync();
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
                    Quantity = pc.QuantityOfProducts,
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
