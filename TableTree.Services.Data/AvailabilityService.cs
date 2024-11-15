using Microsoft.EntityFrameworkCore;
using TableTree.Data.Models;
using TableTree.Data.Repository.Interfaces;
using TableTree.Services.Data.Interfaces;
using TableTree.Web.ViewModels.Product;
using TableTree.Web.ViewModels.Store;

namespace TableTree.Services.Data
{
    public class AvailabilityService : IAvailabilityService
    {
        private readonly IRepository<ProductStore> productStoreRepository;
        private readonly IRepository<Product> productRepository;
        private readonly IRepository<Store> storeRepository;

        public AvailabilityService(IRepository<ProductStore> productStoreRepository, IRepository<Product> productRepository,
            IRepository<Store> storeRepository)
        {
            this.productStoreRepository = productStoreRepository;
            this.productRepository = productRepository;
            this.storeRepository = storeRepository;
        }

        public async Task<AddProductToStoreViewModel> GetAddProductToStoreAsync(string productId, string storeId)
        {
            Guid productIdentificator = Guid.Parse(productId);
            Guid storeIdentificator = Guid.Parse(storeId);


            Product? productToAdd = await this.productRepository
                .GetByIdAsync(productIdentificator);

            AddProductToStoreViewModel model = new AddProductToStoreViewModel()
            {
                Id = productId,
                ProductName = productToAdd.Name,
                Locations = await this.storeRepository
                    .GetAllAttached()
                    .Include(s => s.StoreProducts)
                    .ThenInclude(sp => sp.Product)
                    .Select(s => new CheckboxInputModel()
                    {
                        Id = s.Id.ToString(),
                        Location = s.Address,
                        IsSelected = s.StoreProducts
                            .Any(cm => cm.Product.Id.ToString() == productId)
                    })
                    .ToListAsync()
            };

            return model;


            //ProductStore? productStore = new ProductStore()
            //{
            //    ProductId = productIdentificator,
            //    StoreId = storeIdentificator,
            //};

            //await this.repository
            //    .AddAsync(productStore);
        }

        public Task AddProductToStoreAsync(AddProductToStoreViewModel model)
        {
            var productGuid = Guid.Parse(model.Id);

            ProductStore productStore = new ProductStore()
            {
                ProductId = productGuid,
            };

            foreach (var item in model.Locations)
            {
                var storeId = Guid.Parse(item.Id);

                productStore.StoreId = storeId;
            }


            throw new NotImplementedException();
        }

        public Task RemoveProductFromStore(string productId, string userId)
        {
            throw new NotImplementedException();
        }
    }
}
