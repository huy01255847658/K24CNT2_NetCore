using Hmhlesson02Theory.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hmhlesson02Theory.Controllers
{
    public class HmhProductController : Controller
    {
        public IActionResult HmhIndex()
        {
            //dữ liệu lưu trong đối tượng ViewBag, ViewData, TempData
            ViewBag.Name = "Hoàng Mạnh Huy";
            ViewData["productVD"] = "LapTop Dell Vostro";
            TempData["UNI"] = "Trường Đại Học Nguyễn Trãi - NTU";

            return View();
        }

        public IActionResult GetProduct()
        {
            //Tạo mock data  product
            HmhProduct hmhProduct = new HmhProduct()
            {
                ProductID = "2410900040",
                ProductName = "Hoàng Mạnh Huy",
                YearRelease = 1979,
                Price = 1000
            };

            ViewBag.Product = hmhProduct;
            ViewData["Product"] = hmhProduct;

            return View("Product");
        }
    }
}
