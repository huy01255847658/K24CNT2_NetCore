using Microsoft.AspNetCore.Mvc;

namespace HmhLesson06lab.Controllers
{
    public class HomeController : HmhHomeController
    {
        public HomeController(ILogger<HmhHomeController> logger) : base(logger)
        {
        }
    }
}
