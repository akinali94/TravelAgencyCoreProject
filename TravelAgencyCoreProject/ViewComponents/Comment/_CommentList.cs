using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TravelAgencyCoreProject.ViewComponents.Comment
{
    public class _CommentList : ViewComponent
    {
        CommentManager commentManager1 = new CommentManager(new EfCommentDal());
        Context context = new Context();
        public IViewComponentResult Invoke(int id)
        {
            ViewBag.commentCount = context.Comments.Where(x => x.DestinationID == id).Count();
            var values = commentManager1.TGetListCommentwithDestinationandUser(id);
            return View(values);
        }
    }
}
