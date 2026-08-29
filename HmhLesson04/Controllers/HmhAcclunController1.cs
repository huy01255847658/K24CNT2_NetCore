using HmhLesson04.Models;
using Microsoft.AspNetCore.Mvc;

namespace HmhLesson04.Controllers
{
    public class HmhAcclunController1 : Controller
    {
        private readonly List<HmhAccount> hmhAccounts = new()
        {
            new HmhAccount
    {
        Id = 1,
        Name = "Nguyễn Văn An",
        Email = "an.nguyen@example.com",
        Phone = "0901234567",
        Avatar = "/images/1.jpg",
        Address = "123 Đường Lê Lợi, Phường Bến Nghé, Quận 1, TP. Hồ Chí Minh",
        Bio = "Lập trình viên Senior .NET Core, yêu thích công nghệ và chia sẻ kiến thức.",
        Gender = 1, // 1: Nam
        Birthday = new DateTime(1995, 5, 15)
    },
            new HmhAccount
    {
        Id = 2,
        Name = "Trần Thị Mai",
        Email = "mai.tran@example.com",
        Phone = "0912345678",
        Avatar = "/images/2.jpg",
        Address = "456 Đường Cầu Giấy, Phường Dịch Vọng, Quận Cầu Giấy, Hà Nội",
        Bio = "UI/UX Designer với hơn 5 năm kinh nghiệm trong thiết kế ứng dụng di động.",
        Gender = 2, // 2: Nữ
        Birthday = new DateTime(1998, 10, 20)
    },
            new HmhAccount
    {
        Id = 3,
        Name = "Lê Hoàng Nam",
        Email = "nam.le@example.com",
        Phone = "0923456789",
        Avatar = "/images/3.jpg",
        Address = "789 Đường Nguyễn Văn Linh, Phường Thạc Gián, Quận Thanh Khê, Đà Nẵng",
        Bio = "Quản lý dự án phần mềm (Project Manager), đam mê Agile/Scrum.",
        Gender = 1, // 1: Nam
        Birthday = new DateTime(1992, 3, 8)
    },
            new HmhAccount
    {
        Id = 4,
        Name = "Phạm Thu Hương",
        Email = "huong.pham@example.com",
        Phone = "0934567890",
        Avatar = "/images/4.webp",
        Address = "101 Đường Trần Hưng Đạo, Phường 1, TP. Vũng Tàu, Bà Rịa - Vũng Tàu",
        Bio = "Chuyên viên Kiểm thử phần mềm (QA/QC Engineeer).",
        Gender = 2, // 2: Nữ
        Birthday = new DateTime(2000, 12, 1)
    },
            new HmhAccount
    {
        Id = 5,
        Name = "Đặng Quốc Bảo",
        Email = "bao.dang@example.com",
        Phone = "0945678901",
        Avatar = "/images/2.jpg",
        Address = "202 Đường 3 Tháng 2, Phường Xuân Khánh, Quận Ninh Kiều, Cần Thơ",
        Bio = "DevOps Engineer đam mê Docker, Kubernetes và tự động hóa CI/CD.",
        Gender = 1, // 1: Nam
        Birthday = new DateTime(1997, 7, 25)
    },
        };
        public IActionResult HmhIndex()
        {
            ViewBag.HmhAccounts = hmhAccounts;
            return View();
        }
    }
}
