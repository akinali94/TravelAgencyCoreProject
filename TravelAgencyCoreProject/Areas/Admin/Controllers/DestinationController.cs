using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TravelAgencyCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    [Route("Admin/Destination/[action]")]
    public class DestinationController : Controller
    {
        //DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());
        private readonly IDestionationService _destinationService;
        public DestinationController(IDestionationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            var values = _destinationService.TGetList();
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
            _destinationService.TAdd(destination);
            return RedirectToAction("Index");
        }

        [Route("/Admin/Destination/DeleteDestination/{id?}")]
        public IActionResult DeleteDestination(int id)
        {
            var values = _destinationService.TGetByID(id);
            _destinationService.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("/Admin/Destination/UpdateDestination/{id?}")]
        public IActionResult UpdateDestination(int id)
        {
            var values = _destinationService.TGetByID(id);
            return View();
        }

        [HttpPost]
        public IActionResult UpdateDestination(Destination destination)
        {
            _destinationService.TUpdate(destination);
            return RedirectToAction("Index");
        }

    }
}
