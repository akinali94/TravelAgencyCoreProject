using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgencyCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    [Route("Admin/Guide/[action]")]

    public class GuideController : Controller
    {
        private readonly IGuideService _guideService;

        public GuideController(IGuideService guideService)
        {
            _guideService = guideService;
        }
        

        public IActionResult Index()
        {
            var values = _guideService.TGetList();
            return View(values);
        }

        [Route("AddGuide")]
        [HttpGet]
        public IActionResult AddGuide()
        {

            return View();
        }

        [Route("AddGuide")]
        [HttpPost]
        public IActionResult AddGuide(Guide guide)
        {

            GuideValidator validationRules = new GuideValidator();
            ValidationResult result = validationRules.Validate(guide);
            if (result.IsValid)
            {
                _guideService.TAdd(guide);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }

        [HttpGet]
        [Route("Admin/Guide/EditGuide/{id?}")]
        public IActionResult EditGuide(int id)
        {
            var values = _guideService.TGetByID(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditGuide(Guide guide)
        {
            _guideService.TUpdate(guide);
            return RedirectToAction("Index");
        }

        [Route("Admin/Guide/ChangeToTrue/{id?}")]
        public IActionResult ChangeToTrue(int id)
        {
            _guideService.TChangeToTrueByGuide(id);
            return RedirectToAction("Index","Guide", new {area = "Admin"});
        }

        [Route("Admin/Guide/ChangeToFalse/{id?}")]
        public IActionResult ChangeToFalse(int id)
        {
            _guideService.TChangeToFalseByGuide(id);
            return RedirectToAction("Index", "Guide", new { area = "Admin" });
        }
    }
}
