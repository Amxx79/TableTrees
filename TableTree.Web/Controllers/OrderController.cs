using Microsoft.AspNetCore.Mvc;

namespace TableTree.Web.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
