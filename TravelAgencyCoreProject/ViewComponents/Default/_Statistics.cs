using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TravelAgencyCoreProject.ViewComponents.Default
{
    public class _Statistics : ViewComponent
    {
        private readonly Context _context;
        public _Statistics(Context context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {

            ViewBag.v1 = _context.Destinations.Count();
            ViewBag.v2 = _context.Guides.Count();
            ViewBag.v3 = 285;
            ViewBag.v4 = 25;
            return View();
        }
    }
}
