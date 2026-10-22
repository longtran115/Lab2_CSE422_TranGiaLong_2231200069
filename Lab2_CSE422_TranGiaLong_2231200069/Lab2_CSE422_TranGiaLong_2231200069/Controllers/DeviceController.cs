using Lab2_CSE422_TranGiaLong_2231200069.Models;
using Microsoft.AspNetCore.Mvc;


namespace Lab2_CSE422_TranGiaLong_2231200069.Controllers
{
    public class DeviceController : Controller
    {
        // Dữ liệu giả lập trong RAM
        private static List<Category> categories = new List<Category>
        {
            new Category { Id = 1, Name = "Computer" },
            new Category { Id = 2, Name = "Printer" },
            new Category { Id = 3, Name = "Phone" }
        };

        private static List<Device> devices = new List<Device>
        {
            new Device { Id = 1, Name = "Dell XPS 15", Code = "DEV001", CategoryId = 1, Status = "In use", DateOfEntry = DateTime.Now },
            new Device { Id = 2, Name = "HP LaserJet", Code = "DEV002", CategoryId = 2, Status = "Broken", DateOfEntry = DateTime.Now }
        };

        private static List<User> users = new List<User>
        {
            new User { Id = 1, FullName = "Trần Gia Long", Email = "long@gmail.com", PhoneNumber = "0123456789" }
        };

        // --- 1. HIỂN THỊ DANH SÁCH THIẾT BỊ + TÌM KIẾM & LỌC (Yêu cầu 4) ---
        public IActionResult Index(string searchString, string statusFilter, int? categoryId)
        {
            var result = devices.AsQueryable();

            // Tìm kiếm theo tên thiết bị hoặc mã thiết bị
            if (!string.IsNullOrEmpty(searchString))
            {
                result = result.Where(d => d.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                                           d.Code.Contains(searchString, StringComparison.OrdinalIgnoreCase));
            }

            // Lọc theo trạng thái (Status)
            if (!string.IsNullOrEmpty(statusFilter))
            {
                result = result.Where(d => d.Status == statusFilter);
            }

            // Lọc theo danh mục (Category)
            if (categoryId.HasValue)
            {
                result = result.Where(d => d.CategoryId == categoryId.Value);
            }

            ViewBag.Categories = categories;
            ViewBag.CurrentSearch = searchString;
            ViewBag.CurrentStatus = statusFilter;
            ViewBag.CurrentCategory = categoryId;

            return View(result.ToList());
        }

        // --- 2. THÊM THIẾT BỊ (GET) ---
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = categories;
            return View();
        }

        // --- THÊM THIẾT BỊ (POST) + VALIDATION ---
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Device device)
        {
            if (ModelState.IsValid)
            {
                device.Id = devices.Count > 0 ? devices.Max(d => d.Id) + 1 : 1;
                devices.Add(device);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categories = categories;
            return View(device);
        }

        // --- 3. QUẢN LÝ USER ---
        public IActionResult Users()
        {
            return View(users);
        }
    }
}