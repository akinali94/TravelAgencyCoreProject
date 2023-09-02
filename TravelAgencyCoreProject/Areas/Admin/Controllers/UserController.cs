using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TravelAgencyCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class UserController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IReservationService _reservationService;
        public UserController(IAppUserService appUserService, IReservationService reservationService)
        {
            _appUserService = appUserService;
            _reservationService = reservationService;

        }
        public IActionResult Index()
        {
            var values = _appUserService.TGetList();

            return View(values);
        }

        public IActionResult DeleteUser(int id)
        {
            var values = _appUserService.TGetByID(id);
            _appUserService.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditUser(int id)
        {
            var values = _appUserService.TGetByID(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditUser(AppUser appUser)
        {
            _appUserService.TDelete(appUser);
            return RedirectToAction("Index");
        }

        public IActionResult CommentUser(int id)
        {
            _appUserService.TGetList();
            return View();
        }

        public IActionResult ReservationUser(int id)
        {
            var values = _reservationService.GetListWithReservationByAccepted(id);
            return View(values);
        }
    }
}
