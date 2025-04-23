using Microsoft.AspNetCore.Mvc;
using KlarityMVP.Data;
using KlarityMVP.Models;

namespace KlarityMVP.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }
    }
}
