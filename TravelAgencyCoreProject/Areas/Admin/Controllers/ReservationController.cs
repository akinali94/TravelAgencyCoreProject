using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TravelAgencyCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    [Route("Admin/Reservation/[action]")]
    public class ReservationController : Controller
    {
        private readonly  IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        public IActionResult Index()
        {
            var reservList = _reservationService.TGetListWithUserAndDestination();
            return View(reservList);
        }

        [Route("{id?}")]
        public IActionResult Wait(int id)
        {
            _reservationService.TWait(id);
            return RedirectToAction("Index");
        }

        [Route("{id?}")]
        public IActionResult Previous(int id)
        {
            _reservationService.TPrevious(id);
            return RedirectToAction("Index");
        }

        [Route("{id?}")]
        public IActionResult Active(int id)
        {
            _reservationService.TActive(id);
            return RedirectToAction("Index");
        }
    }
}
