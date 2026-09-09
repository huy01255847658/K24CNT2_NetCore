using System.Diagnostics;
using HmhLesson06lab.Data;
using HmhLesson06lab.Models;
using Microsoft.AspNetCore.Mvc;

namespace HmhLesson06lab.Controllers
{
    public class HmhHomeController : Controller
    {
        private readonly ILogger<HmhHomeController> _logger;

        public HmhHomeController(ILogger<HmhHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var newProducts = HmhDataStore.GetNewProducts();
            return View(newProducts);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
