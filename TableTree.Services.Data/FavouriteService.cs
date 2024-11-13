using Microsoft.EntityFrameworkCore;
using TableTree.Data.Models;
using TableTree.Data.Repository.Interfaces;
using TableTree.Services.Data.Interfaces;
using TableTree.Web.ViewModels.Favourite;

namespace TableTree.Services.Data
{
    public class FavouriteService : IFavouriteService
    {
        private readonly IRepository<FavouriteProduct> favouriteProductRepository;
        private readonly IRepository<Product> productRepository;

        public FavouriteService(IRepository<FavouriteProduct> favouriteProductrepository, IRepository<Product> productRepository)
        {
            this.favouriteProductRepository = favouriteProductrepository;
            this.productRepository = productRepository;
        }

        public async Task AddProductAsync(string productId, string userId)
        {
            var productIdentificator = Guid.Parse(productId);
            var userIdentificator = Guid.Parse(userId);

            Product? productToAdd = await this.productRepository
                .GetByIdAsync(productIdentificator);

            FavouriteProduct? addedToFavouritesAlready = this.favouriteProductRepository
                .GetAllAttached()
                .FirstOrDefault(fp => fp.ProductId == productIdentificator && fp.ApplicationUserId == userIdentificator);
                
            if (addedToFavouritesAlready == null)
            {
                FavouriteProduct newFavouriteProduct = new FavouriteProduct()
                {
                    ApplicationUserId = userIdentificator,
                    ProductId = productIdentificator,
                };

                await this.favouriteProductRepository.AddAsync(newFavouriteProduct);
                await this.favouriteProductRepository.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ProductViewModel>> GetAllProductsInFavouritesAsync()
        {
            IEnumerable<ProductViewModel> model = await this.favouriteProductRepository
                .GetAllAttached()
                .Include(fp => fp.Product)
                .Select(fp => new ProductViewModel()
                {
                    Id = fp.ProductId,
                    ImageUrl = fp.Product.ImageUrl,
                    Name = fp.Product.Name,
                    Price = fp.Product.Price,
                    TreeType = fp.Product.TreeType.Name,
                })
                .ToListAsync();

            return model;
        }

        public async Task RemoveProduct(string productId, string userId)
        {
            Guid productIdentificator = Guid.Parse(productId);
            Guid userIdentificator = Guid.Parse(userId);

            FavouriteProduct? favouriteProduct = this.favouriteProductRepository
                .GetAll()
                .FirstOrDefault(fp => fp.ProductId == productIdentificator && fp.ApplicationUserId == userIdentificator);

            if (favouriteProduct != null)
            {
                this.favouriteProductRepository.Delete(favouriteProduct);
                await this.favouriteProductRepository.SaveChangesAsync();
            }
        }
    }
}
