using Moq;
using NUnit.Framework;
using TableTree.Data.Models;
using TableTree.Data.Repository.Interfaces;

namespace TableTree.Services.Data.Testing
{
    [TestFixture]
    public class ProductTests
    {
        [Test]
        public void Setup() 
        {
        }

        [Test]
        public async Task ProductServiceShouldNotBeNull()
        {
            var productRepository = new Mock<IRepository<Product>>();
            var id = Guid.NewGuid();

            productRepository.Setup(repo => repo.GetById(id))
                  .Returns(new Product { Id = id, Name = "Sample",
                      Description = "Test description"});

            var service = new ProductService(productRepository.Object);

            var result = service.GetProductById(id);

            //productRepository.Setup(r => r.GetById(id))
            //    .Returns()
            Assert.That(productRepository, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(id));

        }
    }
}
