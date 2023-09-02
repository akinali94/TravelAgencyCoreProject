using Microsoft.AspNetCore.Mvc;

namespace TravelAgencyCoreProject.ViewComponents.AdminDashboard
{
    public class _AdminDashboardHeader : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
