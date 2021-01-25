using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GenericRazorPortfolio.Data;
using GenericRazorPortfolio.Dto;
using GenericRazorPortfolio.Helper;
using GenericRazorPortfolio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sodium;

namespace GenericRazorPortfolio.Pages
{
    public class LoginModel : PageModel
    {
        private IGenericRazorPortfolioRepo _repo;
        private IAuthenticator _auth;

        public LoginModel(IGenericRazorPortfolioRepo repo, IAuthenticator auth)
        {
            _repo = repo;
            _auth = auth;
        }

        [BindProperty]
        public LoginDto Admin { get; set; }




        public void OnGet()
        {
            // Debug.WriteLine(PasswordHash.ScryptHashString("", PasswordHash.Strength.Medium));
        }



        public IActionResult OnPost()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _repo.GetAccountByEmail(Admin.Email);

            var acc = _repo.GetAccountByEmail(Admin.Email);


            if (acc == null)
            {
                // Add Error
                return Page();
            }

            if (!PasswordHash.ScryptHashStringVerify(acc.Password, Admin.Password))
            {
                // Add Error
                return Page();
            }

            Response.Cookies.Append("Token", _auth.GenerateAccountAccessToken(acc));


            return RedirectToPage("/Index");
        }
    }
}
