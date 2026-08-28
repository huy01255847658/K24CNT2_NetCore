using HmhLesson03.Models;
using Microsoft.AspNetCore.Mvc;

namespace HmhLesson03.Controllers
{
    [Route("/danh-sach-san-pham")]
    public class HmhProductController : Controller
    {
        //Mock data
        private readonly List<HmhProduct> _products = new()
        {
            new HmhProduct
    {
        HmhProductId = "HMH-MB-001",
        HmhProductName = "iPhone 15 Pro Max 256GB",
        HmhYearRelease = 2023,
        HmhPrice = 29990000m
    },
    new HmhProduct
    {
        HmhProductId = "HMH-MB-002",
        HmhProductName = "Samsung Galaxy S24 Ultra 512GB",
        HmhYearRelease = 2024,
        HmhPrice = 31490000m
    },
    new HmhProduct
    {
        HmhProductId = "HMH-MB-003",
        HmhProductName = "Xiaomi 14 Ultra 5G",
        HmhYearRelease = 2024,
        HmhPrice = 27990000m
    },
    new HmhProduct
    {
        HmhProductId = "HMH-MB-004",
        HmhProductName = "iPad Pro M4 11 inch Wi-Fi",
        HmhYearRelease = 2024,
        HmhPrice = 28990000m
    },
    new HmhProduct
    {
        HmhProductId = "HMH-MB-005",
        HmhProductName = "OPPO Find N3 Flip 256GB",
        HmhYearRelease = 2023,
        HmhPrice = 22990000m
    },
    new HmhProduct
    {
        HmhProductId = "HMH-MB-006",
        HmhProductName = "Samsung Galaxy Z Fold5 512GB",
        HmhYearRelease = 2023,
        HmhPrice = 34990000m
    },
    new HmhProduct
    {
        HmhProductId = "HMH-MB-007",
        HmhProductName = "iPhone 13 128GB",
        HmhYearRelease = 2021,
        HmhPrice = 13990000m
    },
    new HmhProduct
    {
        HmhProductId = "HMH-MB-008",
        HmhProductName = "Samsung Galaxy A55 5G 128GB",
        HmhYearRelease = 2024,
        HmhPrice = 9990000m
    },
    new HmhProduct
    {
        HmhProductId = "HMH-MB-009",
        HmhProductName = "Xiaomi Redmi Note 13 128GB",
        HmhYearRelease = 2024,
        HmhPrice = 4790000m
    },
    new HmhProduct
    {
        HmhProductId = "HMH-MB-010",
        HmhProductName = "iPad Air 5 M1 Wi-Fi 64GB",
        HmhYearRelease = 2022,
        HmhPrice = 14290000m
    }
        };
        public IActionResult Index()
        {
            return Json(_products);
        }

        //collection => view
        [Route("all")]
        public IActionResult HmhGetAllProduct()
        {
            ViewData["Products"] = _products;
            return View();
        }
    }
}
