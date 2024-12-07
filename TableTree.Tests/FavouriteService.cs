using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Security.Claims;
using TableTree.Data.Models;
using TableTree.Data.Repository.Interfaces;
using TableTree.Web.Controllers;
using TableTree.Web.ViewModels.Favourite;

namespace TableTree.Services.Data.Testting
{
	[TestFixture]
	public class FavouriteService
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public async Task FavouriteServiceReturns_GetAllInFavourites()
		{
			var mockedService = new Mock<Data.FavouriteService>();

			mockedService.Setup(s => s.GetAllProductsInFavouritesAsync())
				.ReturnsAsync(GetFavouriteProductsToReturnsAsProductViewModel().Result.AsEnumerable());

			var controller = new FavouritesController(mockedService.Object);

			var result = await controller.Index();
			var viewResult = result as ViewResult;
			var model = viewResult.Model as IEnumerable<ProductViewModel>;

			Assert.That(result, Is.Not.Null);
			Assert.That(model.First().Name == "Epoxy Resing");
			Assert.That(model.Last().TreeType == "Beech");
		}

		[Test]
		public async Task FavouriteServiceReturns_AddProductAsync()
		{
			var userId = "95789b20-5ecf-47c0-9b77-64e54fabb4ec";
			var productId = Guid.Parse("8bb81bb4-64dd-4374-86ea-9f3a97585392");

			var mockedFavouriteRepository = new Mock<IRepository<FavouriteProduct>>();
			var mockedProductRepository = new Mock<IRepository<Product>>();

			var service = new Data.FavouriteService(mockedFavouriteRepository.Object, mockedProductRepository.Object);

			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.NameIdentifier, userId),
			};
			var identity = new ClaimsIdentity(claims, "TestAuth");
			var user = new ClaimsPrincipal(identity);

			var controllerContext = new ControllerContext
			{
				HttpContext = new DefaultHttpContext
				{
					User = user
				}
			};

			var controller = new FavouritesController(service);
			controller.ControllerContext = controllerContext;

			var result = await controller.AddToFavourites(productId);

			mockedFavouriteRepository.Verify(r => r.AddAsync(It.IsAny<FavouriteProduct>()), Times.Once);
		}

		[Test]
		public async Task FavouriteServiceReturns_RemoveProductFromFavourites()
		{
			var userId = "95789b20-5ecf-47c0-9b77-64e54fabb4ec";
			var productId = Guid.Parse("8bb81bb4-64dd-4374-86ea-9f3a97585392");

			var favouriteProduct = new FavouriteProduct
			{
				ProductId = productId,
				ApplicationUserId = Guid.Parse(userId),
			};

			var mockedFavouriteRepository = new Mock<IRepository<FavouriteProduct>>();
			var mockedProductRepository = new Mock<IRepository<Product>>();


			mockedFavouriteRepository.Setup(r => r.GetAll())
				.Returns(new List<FavouriteProduct> { favouriteProduct }.AsQueryable());

			var service = new Data.FavouriteService(mockedFavouriteRepository.Object, mockedProductRepository.Object);

			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.NameIdentifier, userId),
			};
			var identity = new ClaimsIdentity(claims, "TestAuth");
			var user = new ClaimsPrincipal(identity);

			var controllerContext = new ControllerContext
			{
				HttpContext = new DefaultHttpContext
				{
					User = user
				}
			};

			var controller = new FavouritesController(service);
			controller.ControllerContext = controllerContext;

			await controller.RemoveFromFavourites(productId);


			mockedFavouriteRepository.Verify(
				r => r.Delete(It.Is<FavouriteProduct>(
					fp => fp.ProductId == productId && fp.ApplicationUserId.ToString() == userId)),
				Times.Once);
			;
		}

		private async Task<List<FavouriteProduct>> GetFavouriteProductsToReturns()
		{
			var favouriteProducts = new List<FavouriteProduct>() 
			{
				new FavouriteProduct()
				{
					ApplicationUserId = Guid.NewGuid(),
					ProductId = Guid.NewGuid(),
				},
				new FavouriteProduct()
				{
					ApplicationUserId = Guid.NewGuid(),
					ProductId = Guid.NewGuid(),
				},
				new FavouriteProduct()
				{
					ApplicationUserId = Guid.NewGuid(),
					ProductId = Guid.NewGuid(),
				},
			};

			return await Task.FromResult(favouriteProducts);
		}

		private async Task<IEnumerable<ProductViewModel>> GetFavouriteProductsToReturnsAsProductViewModel()
		{
			var products = new List<ProductViewModel>()
			{
				new ProductViewModel()
				{
					Id = Guid.NewGuid(),
					Name = "Epoxy Resing",
					Price = 999m,
					ImageUrl = "",
					TreeType = "Oak",
				},
				new ProductViewModel()
				{
					Id = Guid.NewGuid(),
					Name = "Test test",
					Price = 111m,
					ImageUrl = "",
					TreeType = "Beech",
				},
			};

			return await Task.FromResult(products.AsEnumerable());
		}

	}
}
