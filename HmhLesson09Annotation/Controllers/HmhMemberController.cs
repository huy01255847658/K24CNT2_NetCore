using HmhLesson09Annotation.Models.DataModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HmhLesson09Annotation.Controllers
{
    public class HmhMemberController : Controller
    {
        private static List<HmhMember> _hmhmembers = new List<HmhMember>();
        // GET: HmhMemberController
        public ActionResult Index()
        {
            return View();
        }

        // GET: HmhMemberController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HmhMemberController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HmhMemberController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection HmhMember)
        {
            try
            {   
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HmhMemberController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HmhMemberController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HmhMemberController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HmhMemberController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
