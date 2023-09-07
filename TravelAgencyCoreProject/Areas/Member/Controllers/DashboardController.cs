using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TravelAgencyCoreProject.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize(Roles = "Admin, Member")]
    [Route("Member/Dashboard/[action]")]
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public DashboardController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.userName = values.Name + " " + values.Surname;
            ViewBag.userImage = values.ImageUrl;
            return View();
        }
    }
}
