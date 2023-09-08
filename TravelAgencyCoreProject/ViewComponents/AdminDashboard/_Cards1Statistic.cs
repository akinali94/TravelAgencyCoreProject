using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TravelAgencyCoreProject.ViewComponents.AdminDashboard
{
    public class _Cards1Statistic : ViewComponent
    {
        private readonly Context _context;
        public _Cards1Statistic(Context context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = _context.Destinations.Count();
            ViewBag.v2 = _context.Users.Count();
            return View();
        }
    }
}
