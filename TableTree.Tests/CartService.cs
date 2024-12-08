using MockQueryable;
using Moq;
using NUnit.Framework;
using TableTree.Data.Models;
using TableTree.Data.Repository.Interfaces;
using CartServiceOperations = TableTree.Services.Data.CartService;

namespace TableTree.Services.Data.Testting
{
	[TestFixture]
	public class CartService
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public async Task CartServiceReturns_GetAllProducts()
		{
			var products = GetAllProductsInCart();

			var mockedRepository = new Mock<IRepository<ShoppingCart>>();

			mockedRepository.Setup(repo => repo.GetAllAttached())
				.Returns(products.AsQueryable().BuildMock());

			var service = new CartServiceOperations(mockedRepository.Object, null);

			var result = await service.GetAllProductsInCartAsync(Guid.Parse("25a177e9-1a65-4047-a9c6-b37997da311a").ToString());

			Assert.That(result, Is.Not.Null);
			Assert.That(result.Count, Is.EqualTo(3));
			Assert.That(result.First().Name, Is.EqualTo("Epoxy Resin"));
			Assert.That(result.Last().Id, Is.EqualTo(Guid.Parse("947cc1ff-a04e-45a9-9550-248c9b4ca8ad")));
		}

		[Test]
		public async Task CartServiceReturns_AddProductAsync()
		{
			var productsInCart = GetAllProductsInCart();
			var products = GetProducts();

			var mockedCartRepository = new Mock<IRepository<ShoppingCart>>();
			var mockedProductRepository = new Mock<IRepository<TableTree.Data.Models.Product>>();

			//This is for check it's already constist
			mockedCartRepository.Setup(repo => repo.GetAllAttached())
				.Returns(productsInCart.AsQueryable().BuildMock());

			mockedProductRepository.Setup(repo => repo.GetById(products.First().Id))
				.Returns(products.First());

			var service = new CartServiceOperations(mockedCartRepository.Object, mockedProductRepository.Object);

			ApplicationUser user = new ApplicationUser()
			{
				Id = Guid.Parse("25a177e9-1a65-4047-a9c6-b37997da311a"),
			};

			TableTree.Data.Models.Product newProduct = new()
			{
				Id = Guid.Parse("01e70ab5-bc96-4bfa-b520-0568d5364294"),
				CategoryId = Guid.NewGuid(),
				Description = "TestDescription",
				ImageUrl = "TestUrl",
				IsDeleted = false,
				Name = "New One",
				Price = 999_999m,
				TreeType = new TableTree.Data.Models.TreeType { Name = "Oak" },
			};

			await service.AddProductAsync(newProduct.Id.ToString(), user.Id.ToString(), 3);

			mockedCartRepository.Verify(repo => repo.AddAsync(It.Is<ShoppingCart>(sc =>
				sc.ApplicationUserId == user.Id &&
				sc.ProductId == newProduct.Id &&
				sc.QuantityOfProducts == 3
			)), Times.Once);
		}

		[Test]
		public async Task CartServiceReturns_RemoveProductAsync()
		{
			var productsInCart = GetAllProductsInCart();
			var products = GetProducts();

			var mockedCartRepository = new Mock<IRepository<ShoppingCart>>();
			var mockedProductRepository = new Mock<IRepository<TableTree.Data.Models.Product>>();

			//This is for check it's already constist
			mockedCartRepository.Setup(repo => repo.GetAll())
				.Returns(productsInCart);

			mockedProductRepository.Setup(repo => repo.GetById(products.First().Id))
				.Returns(products.First());

			var service = new CartServiceOperations(mockedCartRepository.Object, mockedProductRepository.Object);

			ApplicationUser user = new ApplicationUser()
			{
				Id = Guid.Parse("25a177e9-1a65-4047-a9c6-b37997da311a"),
			};

			await service.RemoveProduct(productsInCart.First().ProductId.ToString(), user.Id.ToString());


			mockedCartRepository.Verify(repo => repo.Delete(It.Is<ShoppingCart>(sc =>
				sc.ApplicationUserId == user.Id &&
				sc.ProductId == productsInCart.First().ProductId
			)), Times.Once, "The product should be removed from the cart repository.");
		}

		private List<ShoppingCart> GetAllProductsInCart()
		{
			List<TableTree.Data.Models.Product> products = new List<TableTree.Data.Models.Product>()
			{
				new()
				{
					Id = Guid.Parse("7aa955b4-b41c-4299-8717-3946415bd01a"),
					CategoryId = Guid.NewGuid(),
					Description = "TestDescription",
					ImageUrl = "TestUrl",
					IsDeleted = false,
					Name = "Epoxy Resin",
					Price = 1000m,
					TreeType = new TableTree.Data.Models.TreeType { Name = "Oak" },
				},
				new()
				{
					Id = Guid.Parse("066d5c50-3055-47e2-ba6d-f4a0c29ef11b"),
					CategoryId = Guid.NewGuid(),
					Description = "TestDescription",
					ImageUrl = "TestUrl",
					IsDeleted = false,
					Name = "Reclaimed Wood Counter Top",
					Price = 1000m,
					TreeType = new TableTree.Data.Models.TreeType { Name = "Beech" },
				},
				new()
				{
					Id = Guid.Parse("947cc1ff-a04e-45a9-9550-248c9b4ca8ad"),
					CategoryId = Guid.NewGuid(),
					Description = "TestDescription",
					ImageUrl = "TestUrl",
					IsDeleted = false,
					Name = "Eris Hackberry Blue Epoxy Resin Table",
					Price = 1000m,
					TreeType = new TableTree.Data.Models.TreeType { Name = "Oak" },
				},
			};

			var productsInCart = new List<ShoppingCart>()
			{
				new()
				{
					QuantityOfProducts = 1,
					ApplicationUserId = Guid.Parse("25a177e9-1a65-4047-a9c6-b37997da311a"),
					ApplicationUser = new ApplicationUser()
					{
						Id = Guid.Parse("25a177e9-1a65-4047-a9c6-b37997da311a"),
					},
					ProductId = Guid.Parse("7aa955b4-b41c-4299-8717-3946415bd01a"),
					Product = products.First(),
				},
				new()
				{
					QuantityOfProducts = 2,
					ApplicationUserId = Guid.Parse("25a177e9-1a65-4047-a9c6-b37997da311a"),
					ApplicationUser = new ApplicationUser()
					{
						Id = Guid.Parse("25a177e9-1a65-4047-a9c6-b37997da311a"),
					},
					ProductId = Guid.Parse("066d5c50-3055-47e2-ba6d-f4a0c29ef11b"),
					Product = products.Where(p => p.Name == "Reclaimed Wood Counter Top").First(),
				},
				new()
				{
					QuantityOfProducts = 3,
					ApplicationUserId = Guid.Parse("25a177e9-1a65-4047-a9c6-b37997da311a"),
					ApplicationUser = new ApplicationUser()
					{
						Id = Guid.Parse("25a177e9-1a65-4047-a9c6-b37997da311a"),
					},
					ProductId = Guid.Parse("947cc1ff-a04e-45a9-9550-248c9b4ca8ad"),
					Product = products.Last(),
				},
			};

			return productsInCart;
		}

		private List<TableTree.Data.Models.Product> GetProducts()
		{
			List<TableTree.Data.Models.Product> products = new List<TableTree.Data.Models.Product>()
			{
				new()
				{
					Id = Guid.Parse("7aa955b4-b41c-4299-8717-3946415bd01a"),
					CategoryId = Guid.NewGuid(),
					Description = "TestDescription",
					ImageUrl = "TestUrl",
					IsDeleted = false,
					Name = "Epoxy Resin",
					Price = 1000m,
					TreeType = new TableTree.Data.Models.TreeType { Name = "Oak" },
				},
				new()
				{
					Id = Guid.Parse("066d5c50-3055-47e2-ba6d-f4a0c29ef11b"),
					CategoryId = Guid.NewGuid(),
					Description = "TestDescription",
					ImageUrl = "TestUrl",
					IsDeleted = false,
					Name = "Reclaimed Wood Counter Top",
					Price = 1000m,
					TreeType = new TableTree.Data.Models.TreeType { Name = "Beech" },
				},
				new()
				{
					Id = Guid.Parse("947cc1ff-a04e-45a9-9550-248c9b4ca8ad"),
					CategoryId = Guid.NewGuid(),
					Description = "TestDescription",
					ImageUrl = "TestUrl",
					IsDeleted = false,
					Name = "Eris Hackberry Blue Epoxy Resin Table",
					Price = 1000m,
					TreeType = new TableTree.Data.Models.TreeType { Name = "Oak" },
				},
			};

			return products;

		}
	}
}
