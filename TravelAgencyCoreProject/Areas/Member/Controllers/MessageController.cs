using Microsoft.AspNetCore.Mvc;

namespace TravelAgencyCoreProject.Areas.Member.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
