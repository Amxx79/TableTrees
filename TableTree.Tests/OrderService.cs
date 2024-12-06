using Moq;
using NUnit.Framework;
using TableTree.Data.Models;
using TableTree.Data.Repository.Interfaces;
using TableTree.Web.ViewModels.Order;
using OrderServiceOperations = TableTree.Services.Data.OrderService;

namespace TableTree.Services.Data.Testting
{
    [TestFixture]
    public class OrderService
    {
        [SetUp]
        public void Setup()
        {
            var orders = GetAllOrders();
        }

        [Test]
        public async Task OrderServiceReturns_AllOrders()
        {
            var orders = GetAllOrders();

            var mockedRepository = new Mock<IRepository<Order>>();

            var user = new ApplicationUser()
            {
                Email = "test@gmail.com",
                Id = Guid.Parse("64125bb1-b787-4873-9487-a4f1edd0be6b"),
                UserName = "test@gmail.com",
            };

            mockedRepository.Setup(repo => repo.GetAllAttached())
                .Returns(orders.AsQueryable());

            var service = new OrderServiceOperations(mockedRepository.Object, null, null, null);

            var result = await service.GetAllOrders(user.Id.ToString());

            Assert.That(result, Is.Not.Null);
            Assert.That(result.First().TotalPrice, Is.EqualTo("999"));
            Assert.That(result.FirstOrDefault(o => o.SequenceNumber == 2)?.TotalPrice, Is.EqualTo("100"));
            Assert.That(result.Last().TotalPrice, Is.EqualTo("2000"));
        }

        [Test]
        public async Task OrderServiceReturns_AddToOrders()
        {
            var mockedOrderRepository = new Mock<IRepository<Order>>();
            var mockedProductRepository = new Mock<IRepository<Product>>();

            var orders = GetAllOrders();

            var user = new ApplicationUser()
            {
                Email = "test@gmail.com",
                Id = Guid.Parse("64125bb1-b787-4873-9487-a4f1edd0be6b"),
                UserName = "test@gmail.com",
            };

            mockedOrderRepository.Setup(repo => repo.AddAsync(orders.First()))
                .ReturnsAsync(true);
            mockedProductRepository.Setup(repo => repo.GetAll())
                .Returns(GetProductList());

            OrderViewModel orderModel = new OrderViewModel()
            {
                UserId = user.Id.ToString(),
                OrderId = orders.First().Id.ToString(),
                OrderDate = orders.First().OrderDate.ToString(),
                TotalPrice = orders.First().TotalPrice.ToString(),
            };

            var service = new OrderServiceOperations(mockedOrderRepository.Object, mockedProductRepository.Object, null, null);

            var result = service.AddToOrders(orderModel);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.IsCompleted, Is.EqualTo(true));
        }


        private List<Order> GetAllOrders()
        {
            var orders = new List<Order>()
            {
                new Order()
                {
                    Id = Guid.NewGuid(),
                    ApplicationUserId = Guid.Parse("64125bb1-b787-4873-9487-a4f1edd0be6b"),
                    SequenceNumber = 1,
                    OrderDate = DateTime.Now,
                    TotalPrice = 999m,
                },
                new Order()
                {
                    Id = Guid.NewGuid(),
                    ApplicationUserId = Guid.Parse("64125bb1-b787-4873-9487-a4f1edd0be6b"),
                    SequenceNumber = 2,
                    OrderDate = DateTime.Now,
                    TotalPrice = 100m,
                },
                new Order()
                {

                    Id = Guid.NewGuid(),
                    ApplicationUserId = Guid.Parse("64125bb1-b787-4873-9487-a4f1edd0be6b"),
                    SequenceNumber = 3,
                    OrderDate = DateTime.Now,
                    TotalPrice = 2000m,
                },
            };

            return orders;
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
    }

}
