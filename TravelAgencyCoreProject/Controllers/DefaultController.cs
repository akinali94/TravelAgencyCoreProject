using Microsoft.AspNetCore.Mvc;

namespace TravelAgencyCoreProject.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
