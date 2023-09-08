using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TravelAgencyCoreProject.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/Destination/[action]")]
    [Authorize(Roles = "Admin, Member")]
    public class DestinationController : Controller
    {
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

        
        public IActionResult SearchCitiesByName(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;
            var values = from x in _destinationService.TGetList() select x;
            if(!string.IsNullOrEmpty(searchString) )
            {
                values = values.Where(y => y.City.Contains(searchString));
            }

            return View(values.ToList());
        }
    }
}
