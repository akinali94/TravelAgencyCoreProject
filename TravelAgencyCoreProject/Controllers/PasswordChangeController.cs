using AutoMapper.Internal;
using DocumentFormat.OpenXml.Spreadsheet;
using EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using TravelAgencyCoreProject.Models;

namespace TravelAgencyCoreProject.Controllers
{
    [AllowAnonymous]
    public class PasswordChangeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public PasswordChangeController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel forgetVM)
        {
            var user = await _userManager.FindByEmailAsync(forgetVM.Email);
            string passwordResetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var passwordResetTokenLink = Url.Action("ResetPassword", "PasswordChange",new
            {
               userId = user.Id,
               token = passwordResetToken,

            }, HttpContext.Request.Scheme);


            //mail
            //instance from mimekit package
            MimeMessage mimeMessage = new MimeMessage();

            //Mail From
            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "denemetraversal150403@gmail.com");
            //new MailboxAddress(mailRequest.Name, mailRequest.SenderMail);
            mimeMessage.From.Add(mailboxAddressFrom);

            //Mail To
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", forgetVM.Email);
            mimeMessage.To.Add(mailboxAddressTo);

            //Body
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = passwordResetTokenLink;
            mimeMessage.Body = bodyBuilder.ToMessageBody();


            //Using package and viewModel
            mimeMessage.Subject = "Password Change";

            //SmtpClient came from using MailKit.Net.Smtp; !!not from MailKit.Net
            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("denemetraversal150403@gmail.com", "jhlftccntlklzjrh"); //Password of a mail
            client.Send(mimeMessage);
            client.Disconnect(true);

            return View();
        }

        [HttpGet]
        public IActionResult ResetPassword(string userid, string token)
        {
            TempData["userid"] = userid;
            TempData["token"] = token;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetVM)
        {
            var userid = TempData["userid"];
            var token = TempData["token"];
            if (userid == null || token == null)
            {
                //hata mesajı
            }
            var user = await _userManager.FindByIdAsync(userid.ToString());
            var result = await _userManager.ResetPasswordAsync(user, token.ToString(), resetVM.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("SignIn", "Login");
            }
            return View();
        }
    }
}
