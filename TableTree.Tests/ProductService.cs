using Moq;
using NUnit.Framework;
using TableTree.Data.Models;
using TableTree.Data.Repository.Interfaces;
using TableTree.Services.Data;
using TableTree.Services.Data.Interfaces;
using TableTree.Web.Controllers;
using TableTree.Web.ViewModels.Product;

namespace TableTree.Tests
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task ProductServiceReturnsObject()
        {
            var productRepository = new Mock<IRepository<Product>>();
            var id = Guid.NewGuid();

            productRepository.Setup(repo => repo.GetById(id))
                  .Returns(new Product
                  {
                      Id = id,
                      Name = "Sample",
                      Description = "Test description"
                  });

            var service = new ProductService(productRepository.Object);

            var result = service.GetProductById(id);

            Assert.That(productRepository, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(id));
        }

        [Test]
        public void ProductServiceReturns_ModelForEdit()
        {
            var mockedRepository = new Mock<IRepository<Product>>();
            var firstId = Guid.NewGuid();
            var secondId = Guid.NewGuid();

			var category = new Category { Id = Guid.Parse("61BC3294-73CA-441B-9B53-0D4F26B673F3"), Name = "Wood" };
			var treeType = new TreeType { Id = Guid.Parse("401DD5CD-C271-4960-84CE-0B364C96F039"), Name = "Oak" };


            var productsToReturn = new List<Product>
            {
                new Product
                {
                    Id = firstId,
                    Name = "Sample",
                    Description = "Test description",
                    Price = 999m,
                    ImageUrl = "/images/table-1.jpeg",
                    IsDeleted = false,
                    Category = category,
					CategoryId = category.Id,
                    TreeType = treeType,
					TreeTypeId = treeType.Id,
				},
	            new Product
	            {
		            Id = secondId,
		            Name = "Another Sample",
		            Description = "Another description",
		            Price = 1999m,
					ImageUrl = "/images/table-1.jpeg",
					IsDeleted = false,
					Category = category,
					CategoryId = category.Id,
					TreeType = treeType,
					TreeTypeId = treeType.Id,
				}
            };

            mockedRepository.Setup(repo => repo.GetAll())
                .Returns(productsToReturn);

			var service = new ProductService(mockedRepository.Object);

            var result = service.GetProductForEditById(firstId);

            Assert.That(result.Id, Is.EqualTo(firstId));
			Assert.That(result.Name, Is.EqualTo("Sample"));
			Assert.That(result.Price, Is.EqualTo(999)); // Validate category is set correctly
			Assert.That(result.ImageUrl, Is.EqualTo("/images/table-1.jpeg"));
		}

	}
}
