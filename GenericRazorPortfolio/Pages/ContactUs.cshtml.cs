using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GenericRazorPortfolio.Helper;
using GenericRazorPortfolio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using Newtonsoft.Json.Linq;

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


        public async Task<IActionResult> OnPost()
        {



            string recaptchaResponse = this.Request.Form["g-recaptcha-response"];
            var client = HttpClientFactory.Create();
            try
            {
                var parameters = new Dictionary<string, string>
            {
                {"secret", Startup.StaticConfig["RecaptchaSecretKey"]},
                {"response", recaptchaResponse},
                {"remoteip", this.HttpContext.Connection.RemoteIpAddress.ToString()}
            };

                HttpResponseMessage response = await client.PostAsync("https://www.google.com/recaptcha/api/siteverify", new FormUrlEncodedContent(parameters));
                response.EnsureSuccessStatusCode();

                string apiResponse = await response.Content.ReadAsStringAsync();
                dynamic apiJson = JObject.Parse(apiResponse);
                if (apiJson.success != true)
                {
                    this.ModelState.AddModelError(string.Empty, "There was an unexpected problem processing this request. Please try again.");
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("Unexpected captcha response: " + ex.Message);
            }



            if (ModelState.IsValid)
            {
                _sender.SendEmail(Startup.StaticConfig["RecepientEmails"], Message.From, Message.Title, Message.Message);
                return Page();
            }

            return BadRequest();
        }
    }
}
