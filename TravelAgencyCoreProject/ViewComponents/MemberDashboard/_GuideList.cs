using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TravelAgencyCoreProject.ViewComponents.MemberDashboard
{
    public class _GuideList : ViewComponent
    {
        GuiderManager guiderManager1 = new GuiderManager(new EfGuideDal());
        public IViewComponentResult Invoke()
        {
            var values = guiderManager1.TGetList();
            return View(values);
        }
    }
}
