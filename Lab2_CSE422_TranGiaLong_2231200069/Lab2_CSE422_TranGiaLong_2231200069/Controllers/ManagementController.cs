using Lab2_CSE422_TranGiaLong_2231200069.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab2_CSE422_TranGiaLong_2231200069.Controllers
{
    public class ManagementController : Controller
    {
        private static List<Category> categories = new List<Category>
        {
            new Category { Id = 1, Name = "Computer" },
            new Category { Id = 2, Name = "Printer" },
            new Category { Id = 3, Name = "Phone" }
        };

        private static List<Device> devices = new List<Device>
        {
            new Device { Id = 1, Name = "Dell XPS", Code = "PC01", CategoryId = 1, Status = "In use", DateOfEntry = DateTime.Now },
            new Device { Id = 2, Name = "HP LaserJet", Code = "PR01", CategoryId = 2, Status = "Broken", DateOfEntry = DateTime.Now }
        };

        private static List<User> users = new List<User>
        {
            new User { Id = 1, FullName = "Trần Gia Long", Email = "long@gmail.com", PhoneNumber = "0123456789" }
        };

        // --- 1. DEVICE CATEGORY MANAGEMENT ---
        public IActionResult Categories()
        {
            return View(categories);
        }

        // --- 2. DEVICE MANAGEMENT ---
        public IActionResult Devices(int? categoryId)
        {
            var result = devices;
            if (categoryId.HasValue)
            {
                result = devices.Where(d => d.CategoryId == categoryId.Value).ToList();
            }
            ViewBag.Categories = categories;
            return View(result);
        }

        // --- 3. USER MANAGEMENT ---
        public IActionResult Users()
        {
            return View(users);
        }
    }
}
