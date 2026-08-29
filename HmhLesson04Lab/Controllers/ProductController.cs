using Microsoft.AspNetCore.Mvc;

namespace HmhLesson04Lab.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index", "HmhProduct");
        }
    }
}
