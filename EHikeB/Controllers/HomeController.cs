using EHikeB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _config;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _config = configuration;
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
            var cred_mail = _config.GetSection("Credentials")["Email"];
            var cred_password = _config.GetSection("Credentials")["Password"];
            mail.To.Add(cred_mail);
            mail.From = new MailAddress(cred_mail);

            mail.ReplyToList.Add(cred_mail);
            mail.Subject = "Contact us";
            mail.Body = "Name: " + name + "<br>Email: " + email + "<br>Phone: " + phone + "<br>Message: " + message;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";

            smtp.Port = 587;
            
            smtp.Credentials = new System.Net.NetworkCredential(cred_mail, cred_password);
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }
    }
}
