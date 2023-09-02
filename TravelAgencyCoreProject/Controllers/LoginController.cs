using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TravelAgencyCoreProject.Models;

namespace TravelAgencyCoreProject.Controllers
{

	[AllowAnonymous]
	public class LoginController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;

        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserRegisterViewModel p)
        {
            AppUser appUser1 = new AppUser()
            {
                Name = p.Name,
                Surname = p.Surname,
                UserName = p.Username,
                Email = p.Mail,
                
            };

            if(p.Password == p.ConfirmPassword)
            {
                var result = await _userManager.CreateAsync(appUser1, p.Password);

                if(result.Succeeded)
                {
                    return RedirectToAction("SignIn");
                }
                else
                {
                    foreach(var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }

            return View(p);
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> SignIn(UserSignInModel p)
        {
            var errors = ModelState
                .Where(x => x.Value.Errors.Count > 0)
                .Select(x => new { x.Key, x.Value.Errors })
                .ToArray();
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(p.Username, p.Password,false,true);
                if (result.Succeeded)
                {
                    
                    return RedirectToAction("Index", "Profile", new {area = "Member"});
                }
                else
                {
                    return RedirectToAction("SignIn", "Login");
                }
            }
            return View();
        }
    }
}
 


