using Microsoft.EntityFrameworkCore;
using System.Data;
using TableTree.Data.Models;
using TableTree.Data.Repository.Interfaces;
using TableTree.Services.Data.Interfaces;
using TableTree.Web.ViewModels.Order;

namespace TableTree.Services.Data
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> orderRepository;
        private readonly IRepository<Product> productRepository;

        public OrderService(IRepository<Order> orderRepository, IRepository<Product> productRepository)
        {
            this.orderRepository = orderRepository;
            this.productRepository = productRepository;
        }

        public async Task AddToOrders(OrderViewModel order)
        {
            var allProducts = this.productRepository.GetAll();

            var productsInOrder = order.Products
                .Select(pvm => allProducts.FirstOrDefault(p => p.Id == Guid.Parse(pvm.Id.ToString())))
                .Where(product => product != null)
                .ToList();

            List<OrderItemInfo> itemsInOrder = new List<OrderItemInfo>();

            Order newOrder = new Order()
            {
                SequenceNumber = order.SequenceNumber,
                ApplicationUserId = Guid.Parse(order.UserId),
                TotalPrice = Decimal.Parse(order.TotalPrice),
                OrderDate = DateTime.Parse(order.OrderDate),
            };

            foreach (var product in productsInOrder)
            {
                OrderItemInfo itemInfo = new OrderItemInfo()
                {
                    OrderId = newOrder.Id,
                    ProductId = product.Id,
                    Quantity = order.Products.FirstOrDefault(p => p.Id == product.Id).Quantity,
                };
                itemsInOrder.Add(itemInfo);
            }

            newOrder.Items = itemsInOrder.ToArray();

            await this.orderRepository.AddAsync(newOrder);
            await this.orderRepository.SaveChangesAsync();

            return;
        }

        public async Task<IEnumerable<OrderViewModel>> GetAllOrders()
        {
            IEnumerable<OrderViewModel> orders = this.orderRepository
                .GetAllAttached()
                .Select(o => new OrderViewModel()
                {
                    UserId = o.ApplicationUserId.ToString(),
                    OrderId = o.Id.ToString(),
                    OrderDate = o.OrderDate.ToString(),
                    SequenceNumber = o.SequenceNumber,
                    TotalPrice = o.TotalPrice.ToString(),
                });

            return orders;
        }

        public async Task<OrderDetailsViewModel> GetDetailsOfOrder(Guid orderId)
        {
            var orders = this.orderRepository.GetAll();

            var productInOrder = await this.orderRepository
                .GetAllAttached()
                .Where(o => o.Id == orderId)
                .Select(o => new OrderDetailsViewModel()
                {
                    SequenceNumber = o.SequenceNumber,
                    OrderDate = o.OrderDate,
                    TotalPrice = o.TotalPrice,
                    ProductsInOrder = o.Items
                        .Select(p => new ProductViewModel()
                        {
                            Id = p.Id,
                            Name = p.Product.Name,
                            Price = p.Product.Price,
                            ImageUrl = p.Product.ImageUrl,
                            TreeType = p.Product.TreeType.Name,
                        }).ToList()
                }).FirstAsync();

            return productInOrder;
        }

        public int GetLatestSequenceNumberAsync()
        {
            var latestOrder = this.orderRepository
                .GetAll()
                .OrderByDescending(o => o.SequenceNumber)
                .FirstOrDefault();

            return latestOrder?.SequenceNumber ?? 0;
        }
    }
}
