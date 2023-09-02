using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TravelAgencyCoreProject.Controllers
{
    [AllowAnonymous]
    public class DestinationController : Controller
    {
        //DestinationManager destinationManager1 = new DestinationManager(new EfDestinationDal());
        private readonly IDestionationService _destinationService;
        private readonly UserManager<AppUser> _userManager;
        public DestinationController(IDestionationService destinationService, UserManager<AppUser> userManager)
        {
            _destinationService = destinationService;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var values = _destinationService.TGetList();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> DestinationDetails(int id)
        {
            ViewBag.i = id;
            ViewBag.destID = id;
            var userID = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.userId = userID;
            //var values = _destinationService.TGetByID(id);
            var destinationGuide = _destinationService.TGetDestionationWithGuide(id);

            return View(destinationGuide);
        }
        [HttpPost]
        public IActionResult DestinationDetails(Destination p)
        {
            return View();
        }
    }
}
