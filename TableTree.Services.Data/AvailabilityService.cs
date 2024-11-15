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
                            .Any(cm => cm.Product.Id.ToString() == 
                            productId && cm.IsDeleted == false)
                    })
                    .ToListAsync()
            };

            return model;
        }

        public async Task AddProductToStoreAsync(AddProductToStoreViewModel model)
        {
            var productGuid = Guid.Parse(model.Id);

            Product? productToAdd = await this.productRepository
                .GetByIdAsync(productGuid);

            if (productToAdd == null)
            {
                return;
            }

            foreach (var item in model.Locations)
            {
                var storeId = Guid.Parse(item.Id);

                Store? store = await this.storeRepository
                    .GetByIdAsync(storeId);

                if (store == null)
                {
                    return;
                }

                ProductStore? productStore = this.productStoreRepository
                    .GetAllAttached()
                    .FirstOrDefault(ps => ps.Store.Id == storeId && ps.ProductId == productToAdd.Id);


                if (item.IsSelected)
                {
                    if (productStore == null) 
                    {
                        ProductStore newProductStore = new ProductStore()
                        {
                            StoreId = storeId,
                            Store = store,
                            ProductId = productToAdd.Id,
                            Product = productToAdd,
                        };

                        await this.productStoreRepository
                            .AddAsync(newProductStore);
                        await this.productStoreRepository
                            .SaveChangesAsync();
                    }

                    else
                    {
                        productStore.IsDeleted = false;
                        await this.productStoreRepository.SaveChangesAsync();
                    }
                }

                else
                {
                    if (productStore != null)
                    {
                        productStore.IsDeleted = true;
                        await this.productStoreRepository.SaveChangesAsync();
                    }
                }
            }
        }
    }
}
