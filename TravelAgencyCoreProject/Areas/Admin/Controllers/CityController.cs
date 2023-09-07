using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TravelAgencyCoreProject.Models;

namespace TravelAgencyCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    [Route("Admin/City/[action]")]
    public class CityController : Controller
    {
        private readonly IDestionationService _destinationService;
        public CityController(IDestionationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CityList()
        {
            var jsonCity = JsonConvert.SerializeObject(_destinationService.TGetList());
            return Json(jsonCity);
        }

        [HttpPost]
        public IActionResult AddCityDestination(Destination destination)
        {
            destination.Status = true; 
            _destinationService.TAdd(destination); //Firstly Add
            var values = JsonConvert.SerializeObject(destination); //Convert To JSon
            return Json(values);
        }

        public IActionResult GetById(int DestinationID)
        {
            var values = _destinationService.TGetByID(DestinationID);
            var jsonValues = JsonConvert.SerializeObject(values);
            return Json(jsonValues);
        }

        public IActionResult DeleteCity(int id)
        {
            var values = _destinationService.TGetByID(id);
            _destinationService.TDelete(values);
            return NoContent();
        }

        public IActionResult UpdateCity(Destination destination)
        {
            _destinationService.TUpdate(destination);
            var v = JsonConvert.SerializeObject(destination);
            return Json(v);
        }

        //public static List<CityViewModel> cities = new List<CityViewModel>()
        //{
        //    new CityViewModel
        //    {
        //        CityID = 1,
        //        CityName = "Rome",
        //        CityCountry = "Italy"
        //    },
        //    new CityViewModel
        //    {
        //        CityID = 2,
        //        CityName = "Budapest",
        //        CityCountry = "Hungary"
        //    },
        //    new CityViewModel
        //    {
        //        CityID = 3,
        //        CityName = "Prag",
        //        CityCountry = "Czeck Republic"
        //    }
        //};


    }
}
