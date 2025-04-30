using Microsoft.AspNetCore.Mvc;
using KlarityMVP.Models;
using KlarityMVP.Data;
using System.Linq;

namespace KlarityMVP.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.Message = TempData["Message"];
            ViewBag.MessageType = TempData["MessageType"];
            return View("~/Views/Home/Login.cshtml");
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);

            if (user == null)
            {
                TempData["Message"] = "❌ Incorrect email or password.";
                TempData["MessageType"] = "danger"; // will be shown as red alert
                return RedirectToAction("Login");
            }

            HttpContext.Session.SetString("User", user.FullName);
            TempData["Message"] = "✅ Login successful!";
            TempData["MessageType"] = "success"; // will be shown as green alert
            return RedirectToAction("Login");
        }

        [HttpPost]
        public IActionResult Register(string fullName, string email, string password)
        {
            if (_context.Users.Any(u => u.Email == email))
            {
                TempData["Message"] = "⚠️ Email already registered.";
                TempData["MessageType"] = "warning"; // will be yellow alert
                return RedirectToAction("Login");
            }

            var newUser = new User
            {
                FullName = fullName,
                Email = email,
                Password = password
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();

            HttpContext.Session.SetString("User", newUser.FullName);
            TempData["Message"] = "✅ Account created successfully!";
            TempData["MessageType"] = "success";
            return RedirectToAction("Login");
        }
    }
}
