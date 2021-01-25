using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GenericRazorPortfolio.Helper;
using GenericRazorPortfolio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GenericRazorPortfolio.Pages
{
    public class ContactUsModel : PageModel
    {
        private IEmailSender _sender;

        public ContactUsModel(IEmailSender sender)
        {

            _sender = sender;

        }

        [BindProperty]
        public MailMessage Message { get; set; }

        public void OnGet()
        {
        }


        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _sender.SendEmail(Startup.StaticConfig["RecepientEmails"], Message.From, Message.Title, Message.Message);
                return Page();
            }

            return BadRequest();
        }
    }
}
