using Microsoft.AspNetCore.Mvc;

namespace TravelAgencyCoreProject.ViewComponents.MemberDashboard
{
    public class _MemberLayoutLanguages : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
