using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
            var userIdentiticator = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var model = await this.orderService
                .GetAllOrders(userIdentiticator);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> GetInformation(IEnumerable<ViewModels.Order.ProductViewModel> products)
		{
			var user = User.FindFirstValue(ClaimTypes.NameIdentifier);

			int highestOrderSequenceNumber = this.orderService.GetLatestSequenceNumberAsync();

			OrderViewModel order = new OrderViewModel()
			{
				UserId = user,
				OrderDate = DateTime.Now.ToString(),
				SequenceNumber = highestOrderSequenceNumber + 1,
				TotalPrice = products.Sum(p => p.Price * p.Quantity).ToString(),
				Products = products,
			};

            TempData["Products"] = JsonConvert.SerializeObject(order.Products);
			return this.View("OrderInformation", order);
        }

        [HttpPost]
        public async Task<IActionResult> AddToOrders(OrderViewModel model)
        {
			var user = User.FindFirstValue(ClaimTypes.NameIdentifier);

			int highestOrderSequenceNumber = this.orderService.GetLatestSequenceNumberAsync();

            var products = JsonConvert.DeserializeObject<IEnumerable<ViewModels.Order.ProductViewModel>>(TempData["Products"].ToString());

            model.UserId = user;
            model.OrderDate = DateTime.Now.ToString();
			model.SequenceNumber = highestOrderSequenceNumber + 1;
            model.TotalPrice = products.Sum(p => p.Price * p.Quantity).ToString();
			model.Products = products;

			await this.orderService
                .AddToOrders(model);

            return this.RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid orderId)
        {
            OrderDetailsViewModel model = await this.orderService
                .GetDetailsOfOrder(orderId);

            return View(model);
        }

    }
}
