using HmhLabGuire05.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace HmhLabGuire05.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            List<Account> accounts = new List<Account>();
            return View(accounts);
        }

        // GET: Account/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Account/Create
        public ActionResult Create()
        {
            Account model = new Account();
            return View(model);
        }

        // POST: Account/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Account model)
        {
            if (ModelState.IsValid)
            {
                // TODO: Save to database
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Account/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Account/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Account model)
        {
            if (ModelState.IsValid)
            {
                // TODO: Update in database
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Account/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Account/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Account model)
        {
            // TODO: Delete from database
            return RedirectToAction("Index");
        }

        // Remote Validation: Verify Phone
        [AcceptVerbs("GET", "POST")]
        public IActionResult VerifyPhone(string phone)
        {
            Regex regex_isPhone = new Regex(@"^(\(([0-9]{3})\)|[0-9]{3})[- .]?([0-9]{3})[- .]?([0-9]{4})$");
            if (!regex_isPhone.IsMatch(phone))
            {
                return Json($"Số điện thoại {phone} Không đúng định dạng, VD: 0986421127 hoặc 098.421.1127");
            }
            return Json(true);
        }
    }
}
