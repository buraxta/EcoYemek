using MealBox.Models.Classes;
using MealBox.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics;

namespace MealBox.Controllers
{
    [AllowAnonymous]
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Context _context;

        public HomeController(ILogger<HomeController> logger, Context context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index(int? categoryId, string searchQuery)
        {
            try
            {
                // Kategorileri ViewBag'e ekle
                ViewBag.Categories = _context.Categorys.ToList();

                // Ürünleri filtrele
                var products = _context.Products
                    .Include(p => p.Category)
                    .Where(p => p.Status == true &&
                                (!categoryId.HasValue || p.CategoryId == categoryId) &&
                                (string.IsNullOrEmpty(searchQuery) || p.ProductName.Contains(searchQuery)))
                    .ToList();
                products = products.OrderBy(p => p.Distance).ToList();
                return View(products);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Index action error");
                return RedirectToAction("Error");
            }
        }

        [HttpPost]
        public IActionResult GetUserLocation(double latitude, double longitude)
        {
            try
            {
                // Kullanıcının ID'sini session'dan alıyoruz
                var userIdString = HttpContext.Session.GetString("UserID");

                if (string.IsNullOrEmpty(userIdString))
                {
                    return Json(new { success = false, message = "Kullanıcı girişi yapılmamış" });
                }

                int userId = int.Parse(userIdString);
                var user = _context.Users.FirstOrDefault(u => u.Id == userId);

                if (user != null)
                {
                    // Kullanıcının konum bilgisini güncelliyoruz
                    user.Latitude = latitude;
                    user.Longitude = longitude;
                    _context.SaveChanges();  // Değişiklikleri veritabanına kaydediyoruz
                    return Json(new { success = true, message = "Konum başarıyla kaydedildi" });
                }

                return Json(new { success = false, message = "Kullanıcı bulunamadı" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetUserLocation error");
                return Json(new { success = false, message = "Bir hata oluştu." });
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
