using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using DTOLayer.DTOs.ContactDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TravelAgencyCoreProject.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly IContactUsService _contactUsService;
        private readonly IMapper _mapper;
        public ContactController(IContactUsService contactUsService, IMapper mapper)
        {
            _contactUsService = contactUsService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(SendMessageDto model)
        {
            ContactUsValidator validationRules = new ContactUsValidator();
            var validate = validationRules.Validate(model);
            if (validate.IsValid)
            {
                _contactUsService.TAdd(new ContactUs()
                {
                    MessageBody = model.MessageBody,
                    Mail = model.Mail,
                    MessageStatus = true,
                    Name = model.Name,
                    Subject = model.Subject,
                    MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString())
                });

                return RedirectToAction("Index", "Default");
            }
            return View(model);
        }
    }
}
