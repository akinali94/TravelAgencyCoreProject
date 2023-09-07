using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TravelAgencyCoreProject.Areas.Member.Controllers
{

    [Area("Member")]
    [Authorize(Roles = "Admin, Member")]
    [Route("Member/Comment/[action]")]
    public class CommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }

}
