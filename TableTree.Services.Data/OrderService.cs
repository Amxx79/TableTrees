using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security.Claims;
using TableTree.Data.Models;
using TableTree.Data.Repository.Interfaces;
using TableTree.Services.Data.Interfaces;
using TableTree.Web.ViewModels.Order;
using static TableTree.Common.EntityValidationContants;

namespace TableTree.Services.Data
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> orderRepository;
        private readonly IRepository<TableTree.Data.Models.Product> productRepository;
        private readonly IRepository<OrderItemInfo> orderItemsRepository;
        private readonly ICartService cartService;

        public OrderService(IRepository<Order> orderRepository,
            IRepository<TableTree.Data.Models.Product> productRepository,
            IRepository<OrderItemInfo> orderItemsRepository,
            ICartService cartService)
        {
            this.orderRepository = orderRepository;
            this.productRepository = productRepository;
            this.orderItemsRepository = orderItemsRepository;
            this.cartService = cartService;
        }

        public async Task AddToOrders(OrderViewModel order)
        {
            var allProducts = this.productRepository.GetAll();

            foreach (var product in order.Products)
            {
                await this.cartService.RemoveProduct(product.Id.ToString(), order.UserId);
            }

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
                    Id = Guid.NewGuid(),
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

        public async Task<IEnumerable<OrderViewModel>> GetAllOrders(string userIdentificator)
        {
            IEnumerable<OrderViewModel> orders = this.orderRepository
                .GetAllAttached()
                .Where(o => o.ApplicationUserId == Guid.Parse(userIdentificator))
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
            var orderItems = this.orderItemsRepository.GetAllAttached().Include(oi => oi.Product).Where(oi => oi.OrderId == orderId);

            var productInOrder = this.orderRepository
                .GetAllAttached()
                .Where(o => o.Id == orderId).ToList();

            var productInOrderToReturn = productInOrder
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
                            Quantity = orderItems.FirstOrDefault(oi => oi.ProductId == p.ProductId).Quantity,
                        }).ToList()
                }).First();

            return productInOrderToReturn;
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
