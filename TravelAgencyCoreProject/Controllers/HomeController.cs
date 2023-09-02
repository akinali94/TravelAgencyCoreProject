using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TravelAgencyCoreProject.Models;

namespace TravelAgencyCoreProject.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Index page Called");
            return View();
        }

        public IActionResult Privacy()
        {
            DateTime d = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
            _logger.LogInformation(d + "Privacy page Called");
            _logger.LogError("Error Page called");
            return View();
        }

        public IActionResult Test()
        {
            _logger.LogInformation("Test page Called");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}