using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using KlarityMVP.Models;

namespace KlarityMVP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index() => View();
        public IActionResult Privacy() => View();
        public IActionResult About() => View();
        public IActionResult FAQ() => View();
        public IActionResult Products() => View();
        public IActionResult Cart() => View();
        public IActionResult Login() => View();
        public IActionResult Information() => View();

        [HttpGet]
        public IActionResult Tracking()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Tracking(string orderNumber)
        {
            var statuses = new[]
            {
                "Order received. Preparing for shipment.",
                "Order is being packed. Expected delivery in 3–4 days.",
                "Shipped! Estimated arrival: 4 days from now.",
                "Your package is in transit. Hang tight!",
                "Out for delivery! It’ll be with you soon.",
                "Delivered! We hope you enjoy Klarity!"
            };

            var rand = new Random();
            ViewBag.Status = statuses[rand.Next(statuses.Length)];
            ViewBag.OrderNumber = orderNumber;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
