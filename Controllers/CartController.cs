using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using KlarityMVP.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace KlarityMVP.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            var cart = GetCart();
            return View(cart);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(string name, decimal price)
        {
            var cart = GetCart();
            var item = cart.FirstOrDefault(x => x.Name == name);
            if (item != null) item.Quantity++;
            else cart.Add(new CartItem { Name = name, Price = price, Quantity = 1 });
            SaveCart(cart);
            return RedirectToAction("Index", "Cart");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Remove(string name)
        {
            var cart = GetCart();
            var item = cart.FirstOrDefault(x => x.Name == name);
            if (item != null)
            {
                cart.Remove(item);
                SaveCart(cart);
            }
            return RedirectToAction("Index", "Cart");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Clear()
        {
            HttpContext.Session.Remove("Cart");
            return RedirectToAction("Index", "Cart");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateQuantity(string name, int quantity)
        {
            var cart = GetCart();
            var item = cart.FirstOrDefault(x => x.Name == name);
            if (item != null)
            {
                item.Quantity = quantity;
                SaveCart(cart);
            }
            return RedirectToAction("Index", "Cart");
        }

        private List<CartItem> GetCart()
        {
            var json = HttpContext.Session.GetString("Cart");
            return json == null
                ? new List<CartItem>()
                : JsonSerializer.Deserialize<List<CartItem>>(json)!;
        }

        private void SaveCart(List<CartItem> cart)
        {
            HttpContext.Session.SetString("Cart", JsonSerializer.Serialize(cart));
        }
    }
}
