using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TravelAgencyCoreProject.Controllers
{
    public class CommentController : Controller
    {
        CommentManager commentManager1 = new CommentManager(new EfCommentDal());
        
        [HttpGet]
        public PartialViewResult AddComment(int id)
        {
            ViewBag.destID = id;
            return PartialView();
        }
        [HttpPost]
        public IActionResult AddComment(Comment p)
        {
            p.CommentTime = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.CommentState = true;
            commentManager1.TAdd(p);
            return RedirectToAction("Index", "Destination");
        }
        
    }
}
