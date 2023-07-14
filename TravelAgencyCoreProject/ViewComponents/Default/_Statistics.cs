using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TravelAgencyCoreProject.ViewComponents.Default
{
    public class _Statistics : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            using var c = new Context();
            ViewBag.v1 = c.Destinations.Count();
            ViewBag.v2 = c.Guides.Count();
            ViewBag.v3 = 285;
            ViewBag.v4 = 25;
            return View();
        }
    }
}
