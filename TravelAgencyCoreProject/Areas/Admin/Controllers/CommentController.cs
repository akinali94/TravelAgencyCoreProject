using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace TravelAgencyCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    [Route("Admin/Comment/[action]")]
    public class CommentController : Controller
    {
        //CommentManager commentManager = new CommentManager(new EfCommentDal());
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            var values = _commentService.TGetListCommentwithDestination();
            //var values = commentManager.TGetListCommentwithDestination();
            return View(values);
        }

        [Route("Admin/Comment/DeleteComment/{id?}")]
        public IActionResult DeleteComment(int id)
        {
            var values = _commentService.TGetByID(id);
            _commentService.TDelete(values);
            return RedirectToAction("Index");
        }
    }
}
