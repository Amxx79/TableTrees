using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
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

		private List<FavouriteProduct>GetFavouriteProductsToReturns()
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

			return favouriteProducts;
		}

		private async Task<List<ProductViewModel>> GetFavouriteProductsToReturnsAsProductViewModel()
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

			return await Task.FromResult(products);
		}

	}
}
