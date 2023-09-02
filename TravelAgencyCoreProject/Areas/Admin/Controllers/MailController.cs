using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using TravelAgencyCoreProject.Models;

namespace TravelAgencyCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(MailRequest mailRequest)
        {
            //instance from mimekit package
            MimeMessage mimeMessage = new MimeMessage();

            //Mail From
            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "denemetraversal150403@gmail.com");
            //new MailboxAddress(mailRequest.Name, mailRequest.SenderMail);
            mimeMessage.From.Add(mailboxAddressFrom);

            //Mail To
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", mailRequest.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);

            //Body
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = mailRequest.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            //Using package and viewModel
            mimeMessage.Subject = mailRequest.Subject;

            //SmtpClient came from using MailKit.Net.Smtp; !!not from MailKit.Net
            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("denemetraversal150403@gmail.com", "jhlftccntlklzjrh"); //Password of a mail
            client.Send(mimeMessage);
            client.Disconnect(true);
            return View();
        }
    }
}//denemetraversal150403@gmail.com
 //1234567890*Aa
