using HmhLesson08Lab.Models;
using Microsoft.AspNetCore.Mvc;

namespace HmhLesson08Lab.Controllers
{
    public class HmhProductController : Controller
    {
        // In-memory data store (static để giữ dữ liệu giữa các request)
        private static List<HmhProduct> _products = new List<HmhProduct>
        {
            new HmhProduct
            {
                Id = 1, Name = "iPhone 15 Pro", Price = 30000000, SalePrice = 27000000,
                Status = true, CreatedDate = DateTime.Now, Image = "iphone15.jpg",
                CategoryId = 1, Description = "Điện thoại cao cấp của Apple"
            },
            new HmhProduct
            {
                Id = 2, Name = "MacBook Pro M3", Price = 55000000, SalePrice = 50000000,
                Status = true, CreatedDate = DateTime.Now, Image = "macbook.jpg",
                CategoryId = 2, Description = "Laptop mạnh mẽ với chip M3"
            }
        };
        private static int _nextId = 3;

        // Lấy danh sách Category từ HmhCategoryController
        private List<HmhCategory> GetCategories()
        {
            // Truy cập static list của HmhCategoryController
            var field = typeof(HmhCategoryController)
                .GetField("_categories", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
            return field?.GetValue(null) as List<HmhCategory> ?? new List<HmhCategory>();
        }

        // GET: /HmhProduct/HmhIndex
        public IActionResult HmhIndex()
        {
            var categories = GetCategories();
            ViewBag.Categories = categories;
            return View(_products);
        }

        // GET: /HmhProduct/HmhDetail/5
        public IActionResult HmhDetail(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            var categories = GetCategories();
            ViewBag.CategoryName = categories.FirstOrDefault(c => c.Id == product.CategoryId)?.Name ?? "Không xác định";
            return View(product);
        }

        // GET: /HmhProduct/HmhCreate
        public IActionResult HmhCreate()
        {
            ViewBag.Categories = GetCategories();
            return View();
        }

        // POST: /HmhProduct/HmhCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult HmhCreate(HmhProduct product)
        {
            if (ModelState.IsValid)
            {
                product.Id = _nextId++;
                product.CreatedDate = DateTime.Now;
                _products.Add(product);
                return RedirectToAction(nameof(HmhIndex));
            }
            ViewBag.Categories = GetCategories();
            return View(product);
        }

        // GET: /HmhProduct/HmhEdit/5
        public IActionResult HmhEdit(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            ViewBag.Categories = GetCategories();
            return View(product);
        }

        // POST: /HmhProduct/HmhEdit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult HmhEdit(int id, HmhProduct product)
        {
            if (id != product.Id) return NotFound();

            if (ModelState.IsValid)
            {
                var existing = _products.FirstOrDefault(p => p.Id == id);
                if (existing == null) return NotFound();

                existing.Name = product.Name;
                existing.Price = product.Price;
                existing.SalePrice = product.SalePrice;
                existing.Status = product.Status;
                existing.Image = product.Image;
                existing.CategoryId = product.CategoryId;
                existing.Description = product.Description;

                return RedirectToAction(nameof(HmhIndex));
            }
            ViewBag.Categories = GetCategories();
            return View(product);
        }

        // GET: /HmhProduct/HmhDelete/5
        public IActionResult HmhDelete(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            var categories = GetCategories();
            ViewBag.CategoryName = categories.FirstOrDefault(c => c.Id == product.CategoryId)?.Name ?? "Không xác định";
            return View(product);
        }

        // POST: /HmhProduct/HmhDelete/5
        [HttpPost, ActionName("HmhDelete")]
        [ValidateAntiForgeryToken]
        public IActionResult HmhDeleteConfirmed(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _products.Remove(product);
            }
            return RedirectToAction(nameof(HmhIndex));
        }
    }
}
