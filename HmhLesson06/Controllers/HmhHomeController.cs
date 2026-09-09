using System.Diagnostics;
using HmhLesson06.Models;
using Microsoft.AspNetCore.Mvc;

namespace HmhLesson06.Controllers
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
            return View();
        }

        public IActionResult About()
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
