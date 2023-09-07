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
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly UserManager<AppUser> _userManager;

        public CommentController(ICommentService commentService, UserManager<AppUser> userManager)
        {
            _commentService = commentService;
            _userManager = userManager;
        }

        [HttpGet]
        public PartialViewResult AddComment(int id)
        {
            ViewBag.destID = id;
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> AddComment(Comment p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            p.AppUserID = user.Id;
            p.CommentUser = user.Name;
            p.CommentTime = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.CommentState = true;

            _commentService.TAdd(p);
            return RedirectToAction("Index", "Destination");
        }
        
    }
}
