using HmhLesson08Lab.Models;
using Microsoft.AspNetCore.Mvc;

namespace HmhLesson08Lab.Controllers
{
    public class HmhCategoryController : Controller
    {
        // In-memory data store (static để giữ dữ liệu giữa các request)
        private static List<HmhCategory> _categories = new List<HmhCategory>
        {
            new HmhCategory { Id = 1, Name = "Điện thoại" },
            new HmhCategory { Id = 2, Name = "Laptop" },
            new HmhCategory { Id = 3, Name = "Tablet" }
        };
        private static int _nextId = 4;

        // GET: /HmhCategory/HmhIndex
        public IActionResult HmhIndex()
        {
            return View(_categories);
        }

        // GET: /HmhCategory/HmhDetail/5
        public IActionResult HmhDetail(int id)
        {
            var category = _categories.FirstOrDefault(c => c.Id == id);
            if (category == null) return NotFound();
            return View(category);
        }

        // GET: /HmhCategory/HmhCreate
        public IActionResult HmhCreate()
        {
            return View();
        }

        // POST: /HmhCategory/HmhCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult HmhCreate(HmhCategory category)
        {
            if (ModelState.IsValid)
            {
                category.Id = _nextId++;
                _categories.Add(category);
                return RedirectToAction(nameof(HmhIndex));
            }
            return View(category);
        }

        // GET: /HmhCategory/HmhEdit/5
        public IActionResult HmhEdit(int id)
        {
            var category = _categories.FirstOrDefault(c => c.Id == id);
            if (category == null) return NotFound();
            return View(category);
        }

        // POST: /HmhCategory/HmhEdit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult HmhEdit(int id, HmhCategory category)
        {
            if (id != category.Id) return NotFound();

            if (ModelState.IsValid)
            {
                var existing = _categories.FirstOrDefault(c => c.Id == id);
                if (existing == null) return NotFound();

                existing.Name = category.Name;
                return RedirectToAction(nameof(HmhIndex));
            }
            return View(category);
        }

        // GET: /HmhCategory/HmhDelete/5
        public IActionResult HmhDelete(int id)
        {
            var category = _categories.FirstOrDefault(c => c.Id == id);
            if (category == null) return NotFound();
            return View(category);
        }

        // POST: /HmhCategory/HmhDelete/5
        [HttpPost, ActionName("HmhDelete")]
        [ValidateAntiForgeryToken]
        public IActionResult HmhDeleteConfirmed(int id)
        {
            var category = _categories.FirstOrDefault(c => c.Id == id);
            if (category != null)
            {
                _categories.Remove(category);
            }
            return RedirectToAction(nameof(HmhIndex));
        }
    }
}
