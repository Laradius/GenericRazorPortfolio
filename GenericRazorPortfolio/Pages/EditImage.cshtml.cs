using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GenericRazorPortfolio.Data;
using GenericRazorPortfolio.Dto;
using GenericRazorPortfolio.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GenericRazorPortfolio.Pages
{

    [Authorize]
    public class EditImageModel : PageModel


    {
        private IGenericRazorPortfolioRepo _repo;

        public EditImageModel(IGenericRazorPortfolioRepo repo)
        {

            _repo = repo;

        }


        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public ImageDto ImageInfo { get; set; }



        public IActionResult OnGet()
        {


            ImageData image = _repo.GetImageById(Id);

            if (image != null)
            {
                ImageInfo = new ImageDto(image.Title, image.Description, image.ThumbnailLink, image.Link);
                return Page();

            }

            return NotFound();

        }

        public IActionResult OnPostDelete ()

        {

            ImageData image = _repo.GetImageById(Id);



            if (image != null)

            {
                _repo.DeleteImage(image);
                _repo.SaveChanges();
                return RedirectToPage("./Gallery");

    }


            return NotFound();
}

public IActionResult OnPostEdit()

{

    ImageData image = _repo.GetImageById(Id);


    if (ModelState.IsValid)
    {
        image.Title = ImageInfo.Title;
        image.Description = ImageInfo.Description;
        image.ThumbnailLink = ImageInfo.ThumbnailLink;
        image.Link = ImageInfo.Link;

        _repo.SaveChanges();

        return RedirectToPage("./Gallery");

    }

    return BadRequest();
}

    }
}
