using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TravelAgencyCoreProject.Areas.Member.Controllers
{

    [Area("Member")]
    [Authorize(Roles = "Admin, Member")]
    public class ReservationController : Controller
    {
        DestinationManager destinationManager1 = new DestinationManager(new EfDestinationDal());
        ReservationManager reservationManager1 = new ReservationManager(new EfReservationDal());

        private readonly UserManager<AppUser> _userManager;
        public ReservationController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> MyCurrentReservation()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var valuesList = reservationManager1.GetListWithReservationByAccepted(values.Id);
            return View(valuesList);
        }
        public async Task<IActionResult> MyApprovalReservation()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var valuesList = reservationManager1.GetListWithReservationByWaitApproval(values.Id);
            return View(valuesList);
        }
        public async Task<IActionResult> PreviousReservation()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var valuesList = reservationManager1.GetListWithReservationByPrevious(values.Id);
            return View(valuesList);
        }

        [HttpGet]
        public IActionResult NewReservation()
        {
            List<SelectListItem> values = (from x in destinationManager1.TGetList()
                                           select new SelectListItem
                                           {
                                               Text = x.City,
                                               Value = x.DestinationID.ToString()
                                           }).ToList();
            ViewBag.v = values;
            return View();
        }

        [HttpPost]
        public IActionResult NewReservation(Reservation p)
        {
            p.Status = "Waiting for Approval";
            p.AppUserID = 10;
            reservationManager1.TAdd(p);
            return RedirectToAction("MyCurrentReservation");
        }
    }
}
