using BusinessLayer.Abstract;
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
    [Route("Member/Reservation/[action]")]
    public class ReservationController : Controller
    {
        private readonly IDestionationService _destServ;
        private readonly IReservationService _resServ;
        private readonly UserManager<AppUser> _userManager;
        public ReservationController(UserManager<AppUser> userManager, IDestionationService destServ, IReservationService resServ)
        {
            _userManager = userManager;
            _destServ = destServ;
            _resServ = resServ;
        }

        public async Task<IActionResult> MyCurrentReservation()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var valuesList = _resServ.GetListWithReservationByAccepted(values.Id);
            return View(valuesList);
        }
        public async Task<IActionResult> MyApprovalReservation()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var valuesList = _resServ.GetListWithReservationByWaitApproval(values.Id);
            return View(valuesList);
        }
        public async Task<IActionResult> PreviousReservation()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var valuesList = _resServ.GetListWithReservationByPrevious(values.Id);
            return View(valuesList);
        }

        [HttpGet]
        public IActionResult NewReservation()
        {
            List<SelectListItem> values = (from x in _destServ.TGetList()
                                           select new SelectListItem
                                           {
                                               Text = x.City,
                                               Value = x.DestinationID.ToString()
                                           }).ToList();
            ViewBag.v = values;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NewReservation(Reservation p)
        {
            p.Status = "Waiting for Approval";
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            p.AppUserID = user.Id;
            _resServ.TAdd(p);
            return RedirectToAction("MyCurrentReservation");
        }
    }
}
