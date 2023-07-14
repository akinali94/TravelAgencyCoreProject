using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TravelAgencyCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommentController : Controller
    {
        CommentManager commentManager = new CommentManager(new EfCommentDal());
        public IActionResult Index()
        {
            var values = commentManager.TGetListCommentwithDestination();
            return View(values);
        }
    }
}
