using Microsoft.AspNetCore.Mvc;

namespace HmhLesson13Layout.Controllers
{
    public class HmhProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Search(string keyword)
        {
            ViewData["keyword"] = keyword;
            return View();
        }

        public IActionResult Hots()
        {
            return View();
        }
    }
}
