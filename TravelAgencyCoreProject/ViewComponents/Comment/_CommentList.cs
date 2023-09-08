using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TravelAgencyCoreProject.ViewComponents.Comment
{
    
    public class _CommentList : ViewComponent
    {
        private readonly ICommentService _commentService;
        private readonly Context _context;
        public _CommentList(ICommentService commentService, Context context)
        {
            _commentService = commentService;
            _context = context;
        }
        public IViewComponentResult Invoke(int id)
        {
            ViewBag.commentCount = _context.Comments.Where(x => x.DestinationID == id).Count();
            var values = _commentService.TGetListCommentwithDestinationandUser(id);
            return View(values);
        }
    }
}
