using baitapthemSession7.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace YourProject.Controllers
{
    public class ProductsController : Controller
    {
        // Danh sách Category
        private static List<Category> categories = new List<Category>
        {
            new Category { Id = 1, Name = "Điện thoại" },
            new Category { Id = 2, Name = "Laptop" },
            new Category { Id = 3, Name = "Phụ kiện" }
        };

        // Danh sách Product
        private static List<Product> products = new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "iPhone 15",
                Image = "products/iphone15.jpg",
                Price = 20000000,
                SalePrice = 18000000,
                Description = "Điện thoại Apple",
                CategoryId = 1
            },

            new Product
            {
                Id = 2,
                Name = "Laptop Dell",
                Image = "products/dell.jpg",
                Price = 15000000,
                SalePrice = 13000000,
                Description = "Laptop văn phòng",
                CategoryId = 2
            }
        };

        // =========================
        // DANH SÁCH
        // =========================
        public IActionResult Index()
        {
            return View(products);
        }

        // =========================
        // CHI TIẾT
        // =========================
        public IActionResult Details(int id)
        {
            var product = products.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // =========================
        // THÊM - GET
        // =========================
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(
                categories,
                "Id",
                "Name"
            );

            return View();
        }

        // =========================
        // THÊM - POST
        // =========================
        [HttpPost]
        public IActionResult Create(Product product)
        {
            // Kiểm tra SalePrice
            if (product.SalePrice > product.Price * 0.9f)
            {
                ModelState.AddModelError(
                    "SalePrice",
                    "Giá khuyến mãi phải thấp hơn ít nhất 10% so với giá chuẩn."
                );
            }

            // Kiểm tra Description
            if (!string.IsNullOrEmpty(product.Description))
            {
                string[] tuCam =
                {
                    "chửi tục",
                    "vn",
                    "die",
                    "admin",
                    "fake"
                };

                foreach (var tu in tuCam)
                {
                    if (product.Description.Contains(
                        tu,
                        StringComparison.OrdinalIgnoreCase))
                    {
                        ModelState.AddModelError(
                            "Description",
                            $"Mô tả không được chứa từ: {tu}"
                        );

                        break;
                    }
                }
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Categories = new SelectList(
                    categories,
                    "Id",
                    "Name"
                );

                return View(product);
            }

            product.Id = products.Count == 0
                ? 1
                : products.Max(x => x.Id) + 1;

            products.Add(product);

            return RedirectToAction("Index");
        }

        // =========================
        // SỬA - GET
        // =========================
        public IActionResult Edit(int id)
        {
            var product = products.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            ViewBag.Categories = new SelectList(
                categories,
                "Id",
                "Name",
                product.CategoryId
            );

            return View(product);
        }

        // =========================
        // SỬA - POST
        // =========================
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (product.SalePrice > product.Price * 0.9f)
            {
                ModelState.AddModelError(
                    "SalePrice",
                    "Giá khuyến mãi phải thấp hơn ít nhất 10% so với giá chuẩn."
                );
            }

            if (!string.IsNullOrEmpty(product.Description))
            {
                string[] tuCam =
                {
                    "chửi tục",
                    "vn",
                    "die",
                    "admin",
                    "fake"
                };

                foreach (var tu in tuCam)
                {
                    if (product.Description.Contains(
                        tu,
                        StringComparison.OrdinalIgnoreCase))
                    {
                        ModelState.AddModelError(
                            "Description",
                            $"Mô tả không được chứa từ: {tu}"
                        );

                        break;
                    }
                }
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Categories = new SelectList(
                    categories,
                    "Id",
                    "Name",
                    product.CategoryId
                );

                return View(product);
            }

            var oldProduct =
                products.FirstOrDefault(x => x.Id == product.Id);

            if (oldProduct == null)
            {
                return NotFound();
            }

            oldProduct.Name = product.Name;
            oldProduct.Image = product.Image;
            oldProduct.Price = product.Price;
            oldProduct.SalePrice = product.SalePrice;
            oldProduct.Description = product.Description;
            oldProduct.CategoryId = product.CategoryId;

            return RedirectToAction("Index");
        }

        // =========================
        // XÓA - GET
        // =========================
        public IActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // =========================
        // XÓA - POST
        // =========================
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = products.FirstOrDefault(x => x.Id == id);

            if (product != null)
            {
                products.Remove(product);
            }

            return RedirectToAction("Index");
        }
    }
}