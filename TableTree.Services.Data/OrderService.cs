using System.Data;
using TableTree.Data.Models;
using TableTree.Data.Repository.Interfaces;
using TableTree.Services.Data.Interfaces;
using TableTree.Web.ViewModels.Cart;
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

            Order newOrder = new Order()
            {
                ApplicationUserId = Guid.Parse(order.UserId),
                TotalPrice = Decimal.Parse(order.TotalPrice),
                OrderDate = DateTime.Parse(order.OrderDate),
                Items = productsInOrder,
            };

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
    }
}
