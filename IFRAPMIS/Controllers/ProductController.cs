using Microsoft.AspNetCore.Mvc;

namespace IFRAPMIS.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
