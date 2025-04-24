using Microsoft.AspNetCore.Mvc;
using KlarityMVP.Models;
using System;

namespace KlarityMVP.Controllers
{
    public class NewsController : Controller
    {
        // GET: /News
        public IActionResult Index()
        {
            // Only one item now
            var item = new News
            {
                Name = "Focus Blend",
                Description = "Supports mental clarity and sustained concentration.",
                ReleaseDate = new DateTime(2025, 5, 1),
                ImageUrl = "/images/powders/focus-blend.png"
            };

            return View(item);
        }

        [HttpPost]
        public IActionResult Subscribe(string email)
        {
            TempData["Subscribed"] = "Thanks for subscribing!";
            return RedirectToAction(nameof(Index));
        }
    }
}
