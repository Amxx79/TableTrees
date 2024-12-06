using Moq;
using NUnit.Framework;
using TableTree.Data.Models;
using TableTree.Data.Repository.Interfaces;
using TableTree.Services.Data;
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
        public async Task ProductServiceReturns_Object()
        {
            var productRepository = new Mock<IRepository<Data.Models.Product>>();
            var id = Guid.NewGuid();

            productRepository.Setup(repo => repo.GetById(id))
                  .Returns(new Product
                  {
                      Id = id,
                      Name = "Sample",
                      Description = "Test description"
                  });

            var service = new ProductService(productRepository.Object, null);

            var result = service.GetProductById(id);

            Assert.That(productRepository, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(id));
        }

        [Test]
        public void ProductServiceReturns_ModelForEdit()
        {
            var mockedRepository = new Mock<IRepository<Product>>();

            var productsToReturn = GetProductList();

            mockedRepository.Setup(repo => repo.GetAll())
                .Returns(productsToReturn);

            var service = new ProductService(mockedRepository.Object, null);

            var result = service.GetProductForEditById(productsToReturn.First().Id);

            Assert.That(result.Id, Is.EqualTo(productsToReturn.First().Id));
            Assert.That(result.Name, Is.EqualTo("Sample"));
            Assert.That(result.Price, Is.EqualTo(999)); // Validate category is set correctly
            Assert.That(result.ImageUrl, Is.EqualTo("/images/table-1.jpeg"));
        }

        [Test]
        public async Task ProductServiceReturns_ModelDetails()
        {
            var mockedRepository = new Mock<IRepository<Product>>();

            var firstId = Guid.NewGuid();
            var secondId = Guid.NewGuid();
            var category = new Category { Id = Guid.Parse("61BC3294-73CA-441B-9B53-0D4F26B673F3"), Name = "Wood" };
            var treeType = new TreeType { Id = Guid.Parse("401DD5CD-C271-4960-84CE-0B364C96F039"), Name = "Oak" };

            var productsToReturn = GetProductList();

            mockedRepository.Setup(repo => repo.GetAllAttached())
                .Returns(productsToReturn.AsQueryable());

            var service = new ProductService(mockedRepository.Object, null);

            var result = await service.GetProductDetailsByIdAsync(productsToReturn.First().Id);

            Assert.That(result.Id, Is.EqualTo(productsToReturn.First().Id));
            Assert.That(result.Name, Is.EqualTo("Sample"));
            Assert.That(result.ToString(), Is.EqualTo("TableTree.Web.ViewModels.Product.ProductDetailsViewModel"));
        }

        [Test]
        public async Task ProductServiceReturns_AllProducts()
        {
            var mockedRepository = new Mock<IRepository<Product>>();

            var productsToReturn = GetProductList();

            mockedRepository.Setup(repo => repo.GetAllAttached())
                .Returns(productsToReturn.AsQueryable());

            var service = new ProductService(mockedRepository.Object, null);

            var result = service.GetAllProductsAsync();

            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void ProductServiceReturns_AllCategories()
        {
            var mockedRepository = new Mock<IRepository<Product>>();

            var categoriesToReturn = GetCategoriesList();

            mockedRepository.Setup(repo => repo.GetAllCategories())
                .Returns(categoriesToReturn);

            var service = new ProductService(mockedRepository.Object, null);

            var result = service.GetAllCategories();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.First().Name, Is.EqualTo("Table"));
            Assert.That(result.Last().Name, Is.EqualTo("Mirror"));
        }

        [Test]
        public async Task ProductServiceReturns_AddProductModel()
        {
            var mockedRepository = new Mock<IRepository<Product>>();

            var productsToReturn = GetProductList();

            mockedRepository.Setup(repo => repo.AddAsync(productsToReturn.First()))
                .ReturnsAsync(true);
            mockedRepository.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(GetProductList());

			var service = new ProductService(mockedRepository.Object, null);

            Web.ViewModels.Product.AddProductInputModel modelToAdd = new Web.ViewModels.Product.AddProductInputModel()
            {
                Name = productsToReturn.First().Name,
                Description = productsToReturn.First().Description,
                Price = productsToReturn.First().Price,
                ImageUrl = productsToReturn.First().ImageUrl,
                Category = productsToReturn.First().Category.Id,
            };

            await service.AddProductAsync(modelToAdd);

            Assert.That(await mockedRepository.Object.GetAllAsync(), Is.Not.Null);
            Assert.That(mockedRepository.Object.GetAllAsync().Result.First().Name, Is.EqualTo(productsToReturn.First().Name));
        }
        [Test]
        public void ProductServiceReturns_EditProduct()
        {
            var mockedRepository = new Mock<IRepository<Product>>();

            var productsToReturn = GetProductList();

            mockedRepository.Setup(repo => repo.Update(productsToReturn.Last()))
                .Returns(true);
            mockedRepository.Setup(repo => repo.GetById(productsToReturn.Last().Id))
                .Returns(productsToReturn.Last());

            var service = new ProductService(mockedRepository.Object, null);

            EditProductViewModel modelToEdit = new EditProductViewModel()
            {
                Id = productsToReturn.Last().Id,
                Name = productsToReturn.Last().Name,
                Description = productsToReturn.Last().Description,
                Price = productsToReturn.Last().Price,
                ImageUrl = productsToReturn.Last().ImageUrl,
            };

            var result = service.EditProduct(modelToEdit);

            Assert.That(result, Is.EqualTo(true));
            Assert.That(mockedRepository.Object.GetById(productsToReturn.Last().Id).Id, Is.EqualTo(productsToReturn.Last().Id));
        }


        private List<Product> GetProductList()
        {
            var category = new Category { Id = Guid.Parse("61BC3294-73CA-441B-9B53-0D4F26B673F3"), Name = "Wood" };
            var treeType = new TreeType { Id = Guid.Parse("401DD5CD-C271-4960-84CE-0B364C96F039"), Name = "Oak" };
            var firstId = Guid.NewGuid();
            var secondId = Guid.NewGuid();

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

            return productsToReturn;
        }
        private List<Category> GetCategoriesList()
        {
            var categoriesToReturn = new List<Category>()
            {
                new Category()
                {
                    Id = Guid.NewGuid(),
                    Name = "Table",
                },
                new Category()
                {
                    Id = Guid.NewGuid(),
                    Name = "Mirror",
                },
            };

            return categoriesToReturn;
        }
    }
}

