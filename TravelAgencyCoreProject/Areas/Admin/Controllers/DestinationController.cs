using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TravelAgencyCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class DestinationController : Controller
    {
        DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());

        public IActionResult Index()
        {
            var values = destinationManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddDestination()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDestination(Destination destination)
        {
            destinationManager.TAdd(destination);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteDestination(int id)
        {
            var values = destinationManager.TGetByID(id);
            destinationManager.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateDestination(int id)
        {
            var values = destinationManager.TGetByID(id);
            return View();
        }

        [HttpPost]
        public IActionResult UpdateDestination(Destination destination)
        {
            destinationManager.TUpdate(destination);
            return RedirectToAction("Index");
        }

    }
}
