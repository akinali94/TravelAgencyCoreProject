using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Crypto;

namespace TravelAgencyCoreProject.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Index(string selectedValue)
        {
            int id = Int32.Parse(selectedValue);
            TempData["idDest"] = id;
            return RedirectToAction("DestinationDetails", "Destination", new {id = id});
        }

        //public IActionResult RedirectToDest(int idDest)
        //{
        //    ViewData["idDest"] = idDest;
        //    return RedirectToAction("DestinationDetails", "Destination", idDest);
        //}
    }
}
