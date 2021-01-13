using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GenericRazorPortfolio.Data;
using GenericRazorPortfolio.Helper;
using GenericRazorPortfolio.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GenericRazorPortfolio.Pages
{
   // [Authorize]
    public class GalleryModel : PageModel
    {
        private IGenericRazorPortfolioRepo _repository;

        public GalleryModel(IGenericRazorPortfolioRepo repository)
        {
            _repository = repository;

        }

        public List<ImageData> Images { get; set; }


        public bool TokenValid { get; set; }

        // public bool ValidTokenExists;


        public IActionResult OnPost()
        {
            return RedirectToPage("/CreateImage");
        }

       

        public IActionResult OnGet()
        {

            Images = _repository.GetAllImageData().ToList();
            TokenValid = this.ValidTokenExists();
                return Page();
        }
    }
}
