using Moq;
using NUnit.Framework;
using TableTree.Data.Models;
using TableTree.Data.Repository.Interfaces;
using TableTree.Services.Data;

namespace TableTree.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task ProductServiceShouldNotBeNull()
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
    }
}