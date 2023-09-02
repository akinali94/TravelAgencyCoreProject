using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TravelAgencyCoreProject.Controllers
{
    [AllowAnonymous]
    public class GuideController : Controller
    {
        GuiderManager guideManager = new GuiderManager(new EfGuideDal());
        public IActionResult Index()
        {
            var values = guideManager.TGetList();
            return View(values);
        }
    }
}
