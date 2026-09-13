using HmhLesson07.Models.DataModels;
using Microsoft.AspNetCore.Mvc;

namespace HmhLesson07.Controllers
{
    public class HmhMemberController : Controller
    {
        //Modk Data
        protected static List<HmhMember> _members = new List<HmhMember>
        {
            new HmhMember
            {
                HmhMemberId = Guid.NewGuid().ToString(),
                HmhUserName = "Hmhuy",
                HmhPassword = "123456",
                HmhFullName = "Hoàng Mạnh Huy",
                HmhEmail = "huy01255847658@gmail.com"
            },
            new HmhMember
            {
                HmhMemberId = Guid.NewGuid().ToString(),
                HmhUserName = "tranthib",
                HmhPassword = "123456",
                HmhFullName = "Trần Thị B",
                HmhEmail = "tranthib@gmail.com"
            },
            new HmhMember
            {
                HmhMemberId = Guid.NewGuid().ToString(),
                HmhUserName = "levanc",
                HmhPassword = "123456",
                HmhFullName = "Lê Văn C",
                HmhEmail = "levanc@gmail.com"
            },
            new HmhMember
            {
                HmhMemberId = Guid.NewGuid().ToString(),
                HmhUserName = "phamthid",
                HmhPassword = "123456",
                HmhFullName = "Phạm Thị D",
                HmhEmail = "phamthid@gmail.com"
            },
            new HmhMember
            {
                HmhMemberId = Guid.NewGuid().ToString(),
                HmhUserName = "hoangminhe",
                HmhPassword = "123456",
                HmhFullName = "Hoàng Minh E",
                HmhEmail = "hoangminhe@gmail.com"
            }
        };
        public IActionResult Index()
        {
            return View(_members);
        }
        public IActionResult GetMember()
        {
            var member = new HmhMember
            {
                HmhMemberId = Guid.NewGuid().ToString(),
                HmhUserName = "HmHuy",
                HmhPassword = "password123",
                HmhFullName = "Hoàng Mạnh Huy",
                HmhEmail = "huy01255847658@gmail.com"
            };
            //ViewBag.Member = member;
            return View(member);
        }
        //Đưa dữ liệu dạng list ra view
        public IActionResult GetMembers()
        {
            // Lấy từ Mock Data
            ViewBag.Members = _members;
            return View();
        }

        //Get: Create Member
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //Post: Create Member
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(HmhMember member)
        {
            if (ModelState.IsValid)
            {
                member.HmhMemberId = Guid.NewGuid().ToString();
                _members.Add(member);
                return RedirectToAction("Index");
            }
            return View(member);
        }
    }
}
