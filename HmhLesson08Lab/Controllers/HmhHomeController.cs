using System.Diagnostics;
using HmhLesson08Lab.Models;
using Microsoft.AspNetCore.Mvc;

namespace HmhLesson08Lab.Controllers
{
    public class HmhHomeController : Controller
    {
        private readonly ILogger<HmhHomeController> _logger;

        public HmhHomeController(ILogger<HmhHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult HmhIndex()
        {
            return View();
        }

        public IActionResult HmhPrivacy()
        {
            return View();
        }

        public IActionResult HmhAbout()
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
