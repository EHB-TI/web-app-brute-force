using EHikeB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace EHikeB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Contact(string name, string email, string phone, string message)
        {
            sendEmail(name, email, phone, message);

            return Redirect("/");
        }
        public void sendEmail(string name, string email, string phone, string message)
        {

            MailMessage mail = new MailMessage();
            //mail must be changed
            mail.To.Add("ehikeebh@gmail.com");
            mail.From = new MailAddress("ehikeebh@gmail.com");

            mail.ReplyToList.Add("ehikeebh@gmail.com");
            mail.Subject = "Contact us";
            mail.Body = "Name: " + name + "<br>Email: " + email + "<br>Phone: " + phone + "<br>Message: " + message;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.office365.com";

            smtp.Port = 587;
            
            smtp.Credentials = new System.Net.NetworkCredential("ehikeebh@gmail.com", "SoftwareSec-2020");
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }
    }
}
