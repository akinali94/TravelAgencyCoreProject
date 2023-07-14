using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TravelAgencyCoreProject.Controllers
{
    public class DestinationController : Controller
    {
        DestinationManager destinationManager1 = new DestinationManager(new EfDestinationDal());
        public IActionResult Index()
        {
            var values = destinationManager1.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult DestinationDetails(int id)
        {
            ViewBag.i = id;
            var values = destinationManager1.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult DestinationDetails(Destination p)
        {
            return View();
        }
    }
}
