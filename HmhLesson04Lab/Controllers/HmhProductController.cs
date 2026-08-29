using HmhLesson04Lab.Models;
using Microsoft.AspNetCore.Mvc;

namespace HmhLesson04Lab.Controllers
{
    [Route("san-pham")]
    [Route("hmh-san-pham")]
    public class HmhProductController : Controller
    {
        private static readonly List<HmhCategory> Categories = new List<HmhCategory>
        {
            new HmhCategory { Id = 1, Name = "Quần Áo" },
            new HmhCategory { Id = 2, Name = "Túi xách" },
            new HmhCategory { Id = 3, Name = "Đồng hồ" },
            new HmhCategory { Id = 4, Name = "Ti vi" },
            new HmhCategory { Id = 5, Name = "Tủ lạnh" },
            new HmhCategory { Id = 6, Name = "Máy bơm" },
            new HmhCategory { Id = 7, Name = "Quạt điện" },
            new HmhCategory { Id = 8, Name = "Lò sưởi" }
        };

        private static readonly List<HmhProduct> Products = new List<HmhProduct>
        {
            new HmhProduct
            {
                Id = 1,
                Name = "Bộ đồ bơi cho trẻ em nam",
                Image = "/images/bo-do-boi-tre-em-nam.jpg",
                Price = 50000,
                SalePrice = 35000,
                CategoryId = 1,
                Description = "Bộ đồ bơi trẻ em nam chất liệu thun co giãn 4 chiều cực mát, chống tia UV hiệu quả, giữ ấm khi dưới nước.",
                Status = true,
                CreatedAt = new DateTime(2021, 7, 15, 0, 0, 0)
            },
            new HmhProduct
            {
                Id = 2,
                Name = "Bộ đồ bơi cho trẻ em nữ",
                Image = "/images/bo-do-boi-tre-em-nu.jpg",
                Price = 50000,
                SalePrice = 35000,
                CategoryId = 1,
                Description = "Bộ đồ bơi bé gái họa tiết vô cùng đáng yêu, kiểu dáng xinh xắn, chất liệu mềm mại an toàn cho da bé.",
                Status = true,
                CreatedAt = new DateTime(2021, 7, 15, 0, 0, 0)
            },
            new HmhProduct
            {
                Id = 3,
                Name = "Bộ đồ bơi cho trẻ em từ 3-5 tuổi",
                Image = "/images/bo-do-boi-3-5-tuoi.jpg",
                Price = 50000,
                SalePrice = 35000,
                CategoryId = 1,
                Description = "Đồ bơi dành riêng cho độ tuổi từ 3 đến 5 tuổi, thiết kế ôm vừa vặn giúp bé thoải mái vận động dưới bãi biển.",
                Status = true,
                CreatedAt = new DateTime(2021, 7, 15, 0, 0, 0)
            },
            new HmhProduct
            {
                Id = 4,
                Name = "Bộ đồ bơi cho trẻ em thời trang",
                Image = "/images/bo-do-boi-thoi-trang.jpg",
                Price = 50000,
                SalePrice = 35000,
                CategoryId = 1,
                Description = "Mẫu đồ bơi hot trend hè 2021, phối màu hiện đại sắc nét.",
                Status = true,
                CreatedAt = new DateTime(2021, 7, 15, 0, 0, 0)
            },
            new HmhProduct
            {
                Id = 5,
                Name = "Túi thời trang mẫu mới 2021",
                Image = "/images/tui-thoi-trang-mau-moi-2021.jpg",
                Price = 150000,
                SalePrice = 120000,
                CategoryId = 2,
                Description = "Túi xách thời trang cao cấp phong cách trẻ trung năng động, thiết kế nhiều ngăn tiện lợi.",
                Status = true,
                CreatedAt = new DateTime(2021, 7, 15, 0, 0, 0)
            },
            new HmhProduct
            {
                Id = 6,
                Name = "Túi thời trang da cá sấu",
                Image = "/images/tui-thoi-trang-da-ca-sau.jpg",
                Price = 450000,
                SalePrice = 380000,
                CategoryId = 2,
                Description = "Túi xách nữ làm bằng chất liệu da nhân tạo dập vân cá sấu sang trọng và bền bỉ.",
                Status = true,
                CreatedAt = new DateTime(2021, 7, 15, 0, 0, 0)
            },
            new HmhProduct
            {
                Id = 7,
                Name = "Đồng hồ nam cao cấp",
                Image = "/images/dong-ho-nam-cao-cap.jpg",
                Price = 1500000,
                SalePrice = 1200000,
                CategoryId = 3,
                Description = "Đồng hồ nam dây da sang trọng, chống nước tiêu chuẩn 5ATM, mặt kính khoáng chống xước.",
                Status = true,
                CreatedAt = new DateTime(2021, 7, 15, 0, 0, 0)
            },
            new HmhProduct
            {
                Id = 8,
                Name = "Smart TV 4K Ultra HD 55 inch",
                Image = "/images/smart-tv-4k-55-inch.jpg",
                Price = 12000000,
                SalePrice = 9900000,
                CategoryId = 4,
                Description = "Smart TV độ phân giải 4K sắc nét, hỗ trợ kết nối Wifi, Bluetooth và giọng nói tiếng Việt.",
                Status = true,
                CreatedAt = new DateTime(2021, 7, 15, 0, 0, 0)
            },
            new HmhProduct
            {
                Id = 9,
                Name = "Tủ lạnh Inverter 300L",
                Image = "/images/tu-lanh-inverter-300l.jpg",
                Price = 8500000,
                SalePrice = 7200000,
                CategoryId = 5,
                Description = "Tủ lạnh công nghệ Inverter siêu tiết kiệm điện, hệ thống làm lạnh kép duy trì độ ẩm tối ưu.",
                Status = true,
                CreatedAt = new DateTime(2021, 7, 15, 0, 0, 0)
            },
            new HmhProduct
            {
                Id = 10,
                Name = "Máy bơm nước gia đình",
                Image = "/images/may-bom-nuoc-gia-dinh.jpg",
                Price = 1200000,
                SalePrice = 950000,
                CategoryId = 6,
                Description = "Máy bơm nước đẩy cao cho nhà tầng, động cơ dây đồng 100% bền bỉ và mạnh mẽ.",
                Status = true,
                CreatedAt = new DateTime(2021, 7, 15, 0, 0, 0)
            },
            new HmhProduct
            {
                Id = 11,
                Name = "Quạt điện đứng Panasonic",
                Image = "/images/quat-dien-dung-panasonic.jpg",
                Price = 800000,
                SalePrice = 650000,
                CategoryId = 7,
                Description = "Quạt điện đứng có điều khiển từ xa, thiết kế chân đế vững chắc, công suất tạo gió mát diện rộng.",
                Status = true,
                CreatedAt = new DateTime(2021, 7, 15, 0, 0, 0)
            },
            new HmhProduct
            {
                Id = 12,
                Name = "Lò sưởi gốm mùa đông",
                Image = "/images/lo-suoi-gom-mua-dong.jpg",
                Price = 1500000,
                SalePrice = 1100000,
                CategoryId = 8,
                Description = "Lò sưởi gốm ấm áp an toàn cho em bé và người già, tỏa nhiệt nhanh không gây chói mắt.",
                Status = true,
                CreatedAt = new DateTime(2021, 7, 15, 0, 0, 0)
            }
        };

        [HttpGet("")]
        [HttpGet("index")]
        public IActionResult Index(int? categoryId)
        {
            ViewBag.Categories = Categories;
            ViewBag.SelectedCategoryId = categoryId;

            var productsList = Products.AsEnumerable();
            if (categoryId.HasValue && categoryId.Value > 0)
            {
                productsList = productsList.Where(p => p.CategoryId == categoryId.Value);
            }

            return View("~/Views/Product/Index.cshtml", productsList.ToList());
        }

        [HttpGet("detail/{id?}")]
        [HttpGet("chi-tiet/{id?}")]
        public IActionResult Detail(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction(nameof(Index));
            }

            var product = Products.FirstOrDefault(p => p.Id == id.Value);
            if (product == null)
            {
                return NotFound();
            }

            return View("~/Views/Product/Detail.cshtml", product);
        }
    }
}
