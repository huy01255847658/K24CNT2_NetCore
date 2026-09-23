using HmhLesson09Lab.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HmhLesson09Lab.Controllers
{
    public class HmhProductController : Controller
    {
        private static List<HmhCategory> _categories = new List<HmhCategory>
        {
            new HmhCategory { Id = 1, Name = "Điện thoại" },
            new HmhCategory { Id = 2, Name = "Laptop" },
            new HmhCategory { Id = 3, Name = "Máy tính bảng" },
            new HmhCategory { Id = 4, Name = "Phụ kiện" },
        };

        private static List<HmhProduct> _products = new List<HmhProduct>
        {
            new HmhProduct
            {
                Id = 1,
                Name = "iPhone 15 Pro Max",
                Image = "/products/ip15promax.jpg",
                Price = 28990000,
                SalePrice = 25990000,
                Description = "Điện thoại cao cấp của Apple với chip A17 Pro mạnh mẽ.",
                CategoryId = 1
            },
            new HmhProduct
            {
                Id = 2,
                Name = "MacBook Pro M3",
                Image = "/products/MacBookProM3.jpg",
                Price = 45990000,
                SalePrice = 41390000,
                Description = "Laptop chuyên nghiệp với chip Apple M3 siêu mạnh.",
                CategoryId = 2
            }
        };

        private static int _nextId = 3;

        private void PopulateCategoryDropdown(int? selectedId = null)
        {
            ViewBag.CategoryList = new SelectList(_categories, "Id", "Name", selectedId);
        }

        private string? GetCategoryName(int categoryId)
        {
            return _categories.FirstOrDefault(c => c.Id == categoryId)?.Name;
        }

        public IActionResult Index()
        {
            var products = _products.Select(p => new
            {
                p.Id,
                p.Name,
                p.Image,
                p.Price,
                p.SalePrice,
                p.Description,
                p.CategoryId,
                CategoryName = GetCategoryName(p.CategoryId)
            }).ToList();

            ViewBag.Products = products;
            ViewBag.Categories = _categories;
            return View(_products);
        }

        public IActionResult Details(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            ViewBag.CategoryName = GetCategoryName(product.CategoryId);
            return View(product);
        }

        public IActionResult Create()
        {
            PopulateCategoryDropdown();
            return View(new HmhProduct());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HmhProduct model)
        {
            if (model.ImageFile == null || model.ImageFile.Length == 0)
            {
                ModelState.AddModelError("ImageFile", "Vui lòng chọn ảnh sản phẩm");
            }
            else
            {
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".webp" };
                var ext = Path.GetExtension(model.ImageFile.FileName).ToLower();
                if (!allowedExtensions.Contains(ext))
                {
                    ModelState.AddModelError("ImageFile", "Chỉ chấp nhận file ảnh: .jpg, .jpeg, .png, .gif, .webp");
                }
            }

            if (ModelState.IsValid)
            {
                string imagePath = await SaveImageAsync(model.ImageFile!);
                model.Image = imagePath;
                model.Id = _nextId++;
                _products.Add(model);
                TempData["SuccessMessage"] = $"Thêm sản phẩm '{model.Name}' thành công!";
                return RedirectToAction(nameof(Index));
            }

            PopulateCategoryDropdown(model.CategoryId);
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            PopulateCategoryDropdown(product.CategoryId);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, HmhProduct model)
        {
            if (id != model.Id) return NotFound();

            var existingProduct = _products.FirstOrDefault(p => p.Id == id);
            if (existingProduct == null) return NotFound();

            if (model.ImageFile == null || model.ImageFile.Length == 0)
            {
                ModelState.Remove("ImageFile");
                model.Image = existingProduct.Image;
            }
            else
            {
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".webp" };
                var ext = Path.GetExtension(model.ImageFile.FileName).ToLower();
                if (!allowedExtensions.Contains(ext))
                {
                    ModelState.AddModelError("ImageFile", "Chỉ chấp nhận file ảnh: .jpg, .jpeg, .png, .gif, .webp");
                }
            }

            if (ModelState.IsValid)
            {
                if (model.ImageFile != null && model.ImageFile.Length > 0)
                {
                    model.Image = await SaveImageAsync(model.ImageFile);
                }

                existingProduct.Name = model.Name;
                existingProduct.Image = model.Image;
                existingProduct.Price = model.Price;
                existingProduct.SalePrice = model.SalePrice;
                existingProduct.Description = model.Description;
                existingProduct.CategoryId = model.CategoryId;

                TempData["SuccessMessage"] = $"Cập nhật sản phẩm '{model.Name}' thành công!";
                return RedirectToAction(nameof(Index));
            }

            PopulateCategoryDropdown(model.CategoryId);
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            ViewBag.CategoryName = GetCategoryName(product.CategoryId);
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _products.Remove(product);
                TempData["SuccessMessage"] = $"Đã xóa sản phẩm '{product.Name}' thành công!";
            }
            return RedirectToAction(nameof(Index));
        }

        [AcceptVerbs("GET", "POST")]
        public IActionResult VerifySalePrice(float salePrice, float price)
        {
            if (salePrice < 0)
                return Json("Giá khuyến mãi không được âm");

            if (price > 0 && salePrice >= price * 0.9f)
                return Json($"Giá khuyến mãi ({salePrice:N0} VNĐ) phải nhỏ hơn giá gốc ({price:N0} VNĐ) ít nhất 10%");

            return Json(true);
        }

        [AcceptVerbs("GET", "POST")]
        public IActionResult VerifyCategoryId(int categoryId)
        {
            bool exists = _categories.Any(c => c.Id == categoryId);
            if (!exists)
                return Json("Danh mục không hợp lệ, vui lòng chọn lại từ danh sách");

            return Json(true);
        }

        private async Task<string> SaveImageAsync(IFormFile imageFile)
        {
            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "products");
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }

            return "/products/" + uniqueFileName;
        }
    }
}
