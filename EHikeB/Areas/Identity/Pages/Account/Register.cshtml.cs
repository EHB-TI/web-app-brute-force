using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using EHikeB.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;

namespace EHikeB.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<Customer> _signInManager;
        private readonly UserManager<Customer> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly IConfiguration _config;

        public RegisterModel(
            UserManager<Customer> userManager,
            SignInManager<Customer> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _config = configuration;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "First name")]
            [DataType(DataType.Text)]
            public string Firstname { get; set; }
            [Required]
            [Display(Name = "Last name")]
            [DataType(DataType.Text)]
            public string Lastname { get; set; }

            [Required]
            [Display(Name = "Personal student ID(on the back of your student card)")]

            public int StudentID { get; set; }

            [Required]
            [Display(Name = "Phone number")]
            [DataType(DataType.PhoneNumber, ErrorMessage = "Put a valid phone number")]
            public string Phone { get; set; }


            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare(nameof(Password), ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {

            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new Customer { UserName = Input.Email, Email = Input.Email, FirstName = Input.Firstname, LastName = Input.Lastname, StudentID = Input.StudentID, PhoneNumber = Input.Phone };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    sendEmail(callbackUrl, user.Email);

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                  
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
        public void sendEmail(string url, string receiver)
        {

            MailMessage mail = new MailMessage();
            var cred_mail = _config.GetSection("Credentials")["Email"];
            var cred_password = _config.GetSection("Credentials")["Password"];
            mail.To.Add(receiver);
            mail.From = new MailAddress(cred_mail);
            mail.ReplyToList.Add(cred_mail);
            mail.Subject = "Confirmation mail";
            mail.Body = $"Please click on this link to confirm your mail:<a href='{HtmlEncoder.Default.Encode(url)}'> Confirm mail </a> ";
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