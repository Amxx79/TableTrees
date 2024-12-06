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

        [Test]
        public async Task OrderServiceReturns_LatestNumberSequenceNumber()
        {
            var mockedOrderRepository = new Mock<IRepository<Order>>();

            mockedOrderRepository.Setup(repo => repo.GetAll())
                .Returns(GetAllOrders());

            var service = new OrderServiceOperations(mockedOrderRepository.Object, null, null, null);

            var result = service.GetLatestSequenceNumberAsync();

            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public async Task OrderServiceReturns_GetDetailsOfOrder()
        {
            var mockedOrderRepository = new Mock<IRepository<Order>>();
            var mockedOrderItemRepostiory = new Mock<IRepository<OrderItemInfo>>();

            mockedOrderItemRepostiory.Setup(repo => repo.GetAllAttached())
                .Returns(GetOrderItemList().AsQueryable());

            mockedOrderRepository.Setup(repo => repo.GetAllAttached())
                .Returns(GetAllOrders().AsQueryable());

            var service = new OrderServiceOperations(mockedOrderRepository.Object, null, mockedOrderItemRepostiory.Object, null);

            var result = await service.GetDetailsOfOrder(Guid.Parse("db9eb9ac-82ac-4442-9424-2361c35ff97c"));

            Assert.That(result.SequenceNumber, Is.EqualTo(1));
            Assert.That(result.TotalPrice, Is.EqualTo(999));
        }


        private List<Order> GetAllOrders()
        {
            var productList = GetProductList();

            var orders = new List<Order>();

            var orderItemList = new List<OrderItemInfo>()
            {
                new OrderItemInfo()
                {
                    Id = Guid.Parse("602234ba-91e9-4004-8130-9391f6507571"),
                    OrderId = Guid.Parse("db9eb9ac-82ac-4442-9424-2361c35ff97c"),
                    ProductId = Guid.Parse("7111cb4d-233a-4b2b-b4d3-a028bcc8c9cf"),
                    Product = productList.First(p => p.Id == Guid.Parse("7111cb4d-233a-4b2b-b4d3-a028bcc8c9cf")),
                    Quantity = 1,
                },
                new OrderItemInfo()
                {
                    Id = Guid.Parse("2ddac056-faa0-4d81-a885-f1618cc36fc3"),
                    OrderId = Guid.Parse("9564c4cb-dc9e-4b8c-84be-3d3f64fdd8c7"),
                    ProductId = Guid.Parse("d8cd5172-f7ab-4676-822f-6bf19b75a3e5"),
                    Product = productList.First(p => p.Id == Guid.Parse("d8cd5172-f7ab-4676-822f-6bf19b75a3e5")),
                    Quantity = 2,
                }
            };

            var user = new ApplicationUser()
            {
                Email = "test@gmail.com",
                Id = Guid.Parse("64125bb1-b787-4873-9487-a4f1edd0be6b"),
                UserName = "test@gmail.com",
            };

            orders = new List<Order>()
            {
                new Order()
                {
                    Id = Guid.Parse("db9eb9ac-82ac-4442-9424-2361c35ff97c"),
                    ApplicationUserId = user.Id,
                    SequenceNumber = 1,
                    OrderDate = DateTime.Now,
                    TotalPrice = 999m,
                    Items = orderItemList
                    .Where(oil => oil.Id == Guid.Parse("db9eb9ac-82ac-4442-9424-2361c35ff97c"))
                        .Select(o => new OrderItemInfo()
                        {
                            Id = o.Id,
                            OrderId = o.OrderId,
                            Order = orders.FirstOrDefault(o => o.Id == Guid.Parse("db9eb9ac-82ac-4442-9424-2361c35ff97c")),
                            ProductId = o.ProductId,
                            Product = o.Product,
                            Quantity = o.Quantity,
                        })
                },
                new Order()
                {
                    Id = Guid.Parse("9564c4cb-dc9e-4b8c-84be-3d3f64fdd8c7"),
                    ApplicationUserId = user.Id,
                    SequenceNumber = 2,
                    OrderDate = DateTime.Now,
                    TotalPrice = 100m,
                    Items = orderItemList
                    .Where(oil => oil.Id == Guid.Parse("9564c4cb-dc9e-4b8c-84be-3d3f64fdd8c7"))
                        .Select(o => new OrderItemInfo()
                        {
                            Id = o.Id,
                            OrderId = o.OrderId,
                            Order = orders.FirstOrDefault(o => o.Id == Guid.Parse("9564c4cb-dc9e-4b8c-84be-3d3f64fdd8c7")),
                            ProductId = o.ProductId,
                            Product = o.Product,
                            Quantity = o.Quantity,
                        })
                },
                new Order()
                {

                    Id = Guid.Parse("d712398e-aa42-4b58-abed-62fc0f20d72d"),
                    ApplicationUserId = user.Id,
                    SequenceNumber = 3,
                    OrderDate = DateTime.Now,
                    TotalPrice = 2000m,
                    Items = orderItemList
                        .Select(o => new OrderItemInfo()
                        {
                            Id = o.Id,
                            OrderId = o.OrderId,
                            Order = orders.FirstOrDefault(o => o.Id == Guid.Parse("d712398e-aa42-4b58-abed-62fc0f20d72d")),
                            ProductId = o.ProductId,
                            Product = o.Product,
                            Quantity = o.Quantity,
                        })
                },
            };

            return orders;
        }
        private List<Product> GetProductList()
        {
            var category = new Category { Id = Guid.Parse("61BC3294-73CA-441B-9B53-0D4F26B673F3"), Name = "Wood" };
            var treeType = new TreeType { Id = Guid.Parse("401DD5CD-C271-4960-84CE-0B364C96F039"), Name = "Oak" };
            var firstId = Guid.Parse("7111cb4d-233a-4b2b-b4d3-a028bcc8c9cf");
            var secondId = Guid.Parse("d8cd5172-f7ab-4676-822f-6bf19b75a3e5");

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

        private List<OrderItemInfo> GetOrderItemList()
        {
            var productList = GetProductList();

            var orderItemList = new List<OrderItemInfo>()
            {
                new OrderItemInfo()
                {
                    Id = Guid.Parse("602234ba-91e9-4004-8130-9391f6507571"),
                    OrderId = Guid.Parse("db9eb9ac-82ac-4442-9424-2361c35ff97c"),
                    ProductId = Guid.Parse("7111cb4d-233a-4b2b-b4d3-a028bcc8c9cf"),
                    Product = productList.First(p => p.Id == Guid.Parse("7111cb4d-233a-4b2b-b4d3-a028bcc8c9cf")),
                    Quantity = 1,
                },
                new OrderItemInfo()
                {
                    Id = Guid.Parse("2ddac056-faa0-4d81-a885-f1618cc36fc3"),
                    OrderId = Guid.Parse("9564c4cb-dc9e-4b8c-84be-3d3f64fdd8c7"),
                    ProductId = Guid.Parse("d8cd5172-f7ab-4676-822f-6bf19b75a3e5"),
                    Product = productList.First(p => p.Id == Guid.Parse("d8cd5172-f7ab-4676-822f-6bf19b75a3e5")),
                    Quantity = 2,
                }
            };

            return orderItemList;
        }
    }
}