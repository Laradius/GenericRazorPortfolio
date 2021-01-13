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
        public IActionResult OnGet()
        {

            if (this.ValidTokenExists())
            {

                Images = _repository.GetAllImageData().ToList();
                return Page();
            }
            return RedirectToPage("/Index");




        }
    }
}
