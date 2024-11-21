using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TableTree.Services.Data.Interfaces;
using TableTree.Web.ViewModels.Cart;
using TableTree.Web.ViewModels.Order;

namespace TableTree.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await this.orderService
                .GetAllOrders();

            return View(model);
        }

        public async Task<IActionResult> AddToOrders(IEnumerable<ViewModels.Order.ProductViewModel> products)
        {
            var orders = await this.orderService
                .GetAllOrders();

            OrderViewModel orderr = new OrderViewModel()
            {
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                OrderDate = DateTime.Now.ToString(),
                OrderId = orders.Last().SequenceNumber.ToString() + 1,
                Products = products,
            };

            await this.orderService
                .AddToOrders(orderr);

            return default;
        }
    }
}
