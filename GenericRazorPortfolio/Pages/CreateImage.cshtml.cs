using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GenericRazorPortfolio.Data;
using GenericRazorPortfolio.Models;
using GenericRazorPortfolio.Dto;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Diagnostics;
using GenericRazorPortfolio.Helper;

namespace GenericRazorPortfolio.Pages
{
    [Authorize]
    public class CreateImageModel : PageModel
    {
        private readonly IGenericRazorPortfolioRepo _repo;

        public CreateImageModel(IGenericRazorPortfolioRepo repo)
        {
            _repo = repo;
        }

        public IActionResult OnGet()
        {


            return Page();
        }

        [BindProperty]
        public ImageDto ImageData { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }



            ImageData data = new ImageData
            {
                Link = ImageData.Link,
                ThumbnailLink = ImageData.ThumbnailLink,
                Description = ImageData.Description,
                Title = ImageData.Title,
                Author = this.GetClaimValue("Name")
            };


            _repo.CreateImage(data);
            await _repo.SaveChangesAsync();
            return RedirectToPage("./Gallery");
        }
    }
}
