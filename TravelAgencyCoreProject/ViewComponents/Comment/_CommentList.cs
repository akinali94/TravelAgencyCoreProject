using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TravelAgencyCoreProject.ViewComponents.Comment
{
    public class _CommentList : ViewComponent
    {
        CommentManager commentManager1 = new CommentManager(new EfCommentDal());
        public IViewComponentResult Invoke(int id)
        {

            var values = commentManager1.TGetDestinationById(id);
            return View(values);
        }
    }
}
