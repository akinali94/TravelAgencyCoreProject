using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TravelAgencyCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    [Route("Admin/ContactUs/[action]")]
    public class ContactUsController : Controller
    {
        IContactUsService _contactUsService;
        public ContactUsController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }
        public IActionResult Index()
        {
            var values = _contactUsService.TGetListContactUsByTrue();
            return View(values);
        }
    }
}
