using Microsoft.AspNetCore.Mvc;
using KlarityMVP.Models;
using System.Text.Json;

namespace KlarityMVP.Controllers
{
    public class CheckoutController : Controller
    {
        public IActionResult Index()
        {
            // pull cart total
            var json = HttpContext.Session.GetString("Cart");
            var cart = json == null
                ? new List<CartItem>()
                : JsonSerializer.Deserialize<List<CartItem>>(json)!;

            var vm = new CheckoutViewModel
            {
                OrderTotal = cart.Sum(x => x.Price * x.Quantity)
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(CheckoutViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // TODO: process payment here

            // clear cart
            HttpContext.Session.Remove("Cart");

            return RedirectToAction("Confirmation");
        }

        public IActionResult Confirmation()
        {
            return View();
        }
    }
}