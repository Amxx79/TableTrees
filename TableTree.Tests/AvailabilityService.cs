using MockQueryable;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableTree.Data.Models;
using TableTree.Data.Repository.Interfaces;
using TableTree.Web.ViewModels.Product;
using TableTree.Web.ViewModels.Store;
using AvailabilityServiceOperations = TableTree.Services.Data.AvailabilityService;

namespace TableTree.Services.Data.Testting
{
	public class AvailabilityService
	{
		[SetUp]
		public void Setup() 
		{ 
		}

		[Test]
		public async Task AvailabilityServiceReturns_AddProductToStore()
		{
			var productId = Guid.Parse("e54a980e-0558-495f-b36f-cc7e3e93b0ab");
			var storeId = Guid.Parse("52665dd8-e6ec-4184-8fbb-d812c3dce935");

			AddProductToStoreViewModel model = new()
			{
				Id = productId.ToString(),
				ProductName = "Resin Table",
				Locations = new List<CheckboxInputModel>()
				{
					new()
					{
						Id = storeId.ToString(),
						Location = "Bulgaria, Druzhba",
						IsSelected = true,
					},
					new()
					{
						Id = Guid.NewGuid().ToString(),
						Location = "Plovdiv, Trakia",
						IsSelected = true,
					},
				}
			};

			Product product = new Product()
			{
				Id = productId,
				Name = "Resin Table",
				Description = "Test Descrpt.",
				Price = 1999m,
				ImageUrl = "TestImageUrl",
				IsDeleted = false,
			};

			Store store = new Store()
			{
				Id = storeId,
				Address = "Bulgaria, Druzhba",
			};

			var productRepository = new Mock<IRepository<Product>>();
			var storeRepository = new Mock<IRepository<Store>>();
			var productStoreRepository = new Mock<IRepository<ProductStore>>();

			productRepository.Setup(repo => repo.GetByIdAsync(productId))
				.ReturnsAsync(product);
			storeRepository.Setup(repo => repo.GetByIdAsync(storeId))
				.ReturnsAsync(store);

			var service = new AvailabilityServiceOperations(productStoreRepository.Object, productRepository.Object, storeRepository.Object);

			await service.AddProductToStoreAsync(model);

			productStoreRepository.Verify(repo => repo.AddAsync(It.Is<ProductStore>(ps =>
				ps.ProductId == productId &&
				ps.StoreId == storeId
			)), Times.Once);

			productStoreRepository.Verify(repo => repo.SaveChangesAsync(), Times.Once);
		}

		[Test]
		public async Task AvailabilityServiceReturns_AddProductToStoreDeleteStore()
		{
			var productId = Guid.Parse("e54a980e-0558-495f-b36f-cc7e3e93b0ab");
			var storeId = Guid.Parse("52665dd8-e6ec-4184-8fbb-d812c3dce935");

			AddProductToStoreViewModel model = new()
			{
				Id = productId.ToString(),
				ProductName = "Resin Table",
				Locations = new List<CheckboxInputModel>()
				{
					new()
					{
						Id = storeId.ToString(),
						Location = "Bulgaria, Druzhba",
						IsSelected = false,
					},
				}
			};

			Product product = new Product()
			{
				Id = productId,
				Name = "Resin Table",
				Description = "Test Descrpt.",
				Price = 1999m,
				ImageUrl = "TestImageUrl",
				IsDeleted = false,
			};

			Store store = new Store()
			{
				Id = storeId,
				Address = "Bulgaria, Druzhba",
			};


			List<ProductStore> productStores = new()
			{
				new ProductStore()
				{
					ProductId = productId,
					Product = product,
					StoreId = storeId,
					Store = store,
				},
			};

			var productRepository = new Mock<IRepository<Product>>();
			var storeRepository = new Mock<IRepository<Store>>();
			var productStoreRepository = new Mock<IRepository<ProductStore>>();

			productRepository.Setup(repo => repo.GetByIdAsync(productId))
				.ReturnsAsync(product);
			storeRepository.Setup(repo => repo.GetByIdAsync(storeId))
				.ReturnsAsync(store);
			productStoreRepository.Setup(repo => repo.GetAllAttached())
				.Returns(productStores.AsQueryable());

			var service = new AvailabilityServiceOperations(productStoreRepository.Object, productRepository.Object, storeRepository.Object);

			await service.AddProductToStoreAsync(model);

			productRepository.Verify(repo => repo.GetByIdAsync(productId), Times.Once);
			productStoreRepository.Verify(repo => repo.GetAllAttached(), Times.Once);
			productStoreRepository.Verify(repo => repo.SaveChangesAsync(), Times.Once);
			Assert.That(productStores.First().IsDeleted, Is.EqualTo(true));
		}

		[Test]
		public async Task AvailabilityServiceReturns_GetAddProductToStore()
		{
			var productId = Guid.Parse("e54a980e-0558-495f-b36f-cc7e3e93b0ab");
			var storeId = Guid.Parse("52665dd8-e6ec-4184-8fbb-d812c3dce935");


			Product product = new Product()
			{
				Id = productId,
				Name = "Resin Table",
				Description = "Test Descrpt.",
				Price = 1999m,
				ImageUrl = "TestImageUrl",
				IsDeleted = false,
			};

			List<Store> stores = new()
			{
				new Store()
				{
					Id = storeId,
					Address = "Bulgaria, Druzhba",
				},
			};

			var productRepository = new Mock<IRepository<Product>>();
			var storeRepository = new Mock<IRepository<Store>>();

			productRepository.Setup(repo => repo.GetByIdAsync(productId))
				.ReturnsAsync(product);
			storeRepository.Setup(repo => repo.GetAllAttached())
				.Returns(stores.AsQueryable().BuildMock());

			var service = new AvailabilityServiceOperations(null, productRepository.Object, storeRepository.Object);

			var result = await service.GetAddProductToStoreAsync(productId.ToString(), storeId.ToString());

			productRepository.Verify(repo => repo.GetByIdAsync(productId), Times.Once);
			storeRepository.Verify(repo => repo.GetAllAttached(), Times.Once);

			Assert.That(result, Is.Not.Null);
			Assert.That(result.Id, Is.EqualTo(product.Id.ToString()));
			Assert.That(result.ProductName, Is.EqualTo("Resin Table"));
			Assert.That(result.Locations.Count(), Is.EqualTo(1));
			Assert.That(result.Locations.First().Id, Is.EqualTo(storeId.ToString()));
			Assert.That(result.Locations.First().Location, Is.EqualTo("Bulgaria, Druzhba"));
		}
	}
}
