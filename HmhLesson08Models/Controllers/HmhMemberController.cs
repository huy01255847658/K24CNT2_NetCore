using HmhLesson08Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace HmhLesson08Models.Controllers
{
    public class HmhMemberController : Controller
    {
        //Mock data - HmhMember
        private static List<HmhMember> _members = new List<HmhMember>()
        {
            new HmhMember
            {
                HmhMemberId = Guid.NewGuid().ToString(),
                HmhUserName = "HmHuy",
                HmhPassword = "123456",
                HmhFullName = "Hoàng Mạnh Huy",
                HmhEmail = "huy01255847658@gmail.com"
            },

            new HmhMember
            {
                HmhMemberId = Guid.NewGuid().ToString(),
                HmhUserName = "tranthib",
                HmhPassword = "123456",
                HmhFullName = "Trần Thị Bình",
                HmhEmail = "tranthibinh@gmail.com"
            },

            new HmhMember
            {
                HmhMemberId = Guid.NewGuid().ToString(),
                HmhUserName = "levanc",
                HmhPassword = "123456",
                HmhFullName = "Lê Văn Cường",
                HmhEmail = "levancuong@gmail.com"
            },

            new HmhMember
            {
                HmhMemberId = Guid.NewGuid().ToString(),
                HmhUserName = "phamthid",
                HmhPassword = "123456",
                HmhFullName = "Phạm Thị Dung",
                HmhEmail = "phamthidung@gmail.com"
            },

            new HmhMember
            {
                HmhMemberId = Guid.NewGuid().ToString(),
                HmhUserName = "hoangmine",
                HmhPassword = "123456",
                HmhFullName = "Hoàng Minh Đức",
                HmhEmail = "hoangminhduc@gmail.com"
            }
        };
        // GET: danh sách thành viên
        public IActionResult Index()
        {
            return View(_members);
        }

        [HttpGet]
        public IActionResult HmhCreate()
        {
            var member = new HmhMember();
            return View(member);
        }

        [HttpPost]
        public IActionResult HmhCreate(HmhMember hmhMember)
        {
            hmhMember.HmhMemberId = Guid.NewGuid().ToString();
            _members.Add(hmhMember);

            return RedirectToAction("Index");
            //return View(hmhMember);
        }

        [HttpGet]
        public IActionResult HmhEdit(string id)
        {
            var member = _members.Where(x => x.HmhMemberId.Equals(id)).FirstOrDefault();
            return View(member);
        }

        [HttpPost]
        public IActionResult HmhEdit(string id, HmhMember hmhMember)
        {
            hmhMember.HmhMemberId = Guid.NewGuid().ToString();
            //var member = _member.Where(x => x.HmhMemberId.Equals(id)).FirstOrDefault();
            for (int i = 0; i < _members.Count; i++)
            {
                if (_members[i].HmhMemberId == id)
                {
                    _members[i].HmhUserName = hmhMember.HmhUserName;
                    _members[i].HmhPassword = hmhMember.HmhPassword;
                    _members[i].HmhFullName = hmhMember.HmhFullName;
                    _members[i].HmhEmail = hmhMember.HmhEmail;

                    return RedirectToAction("Index");
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult HmhDetails(string id)
        {
            var member = _members.Where(x => x.HmhMemberId.Equals(id)).FirstOrDefault();
            return View(member);
        }

        [HttpGet]
        public IActionResult HmhDelete(string id)
        {
            var member = _members.Where(x => x.HmhMemberId.Equals(id)).FirstOrDefault();
            return View(member);
        }

        [HttpPost]
        public IActionResult HmhDeleted(string id)
        {
            foreach (var item in _members)
            {
                if (item.HmhMemberId.Equals(id))
                {
                    _members.Remove(item);
                    return RedirectToAction("Index");
                }
            }
            return View("HmhDelete");
        }
    }
}
