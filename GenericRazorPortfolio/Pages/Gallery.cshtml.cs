using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GenericRazorPortfolio.Data;
using GenericRazorPortfolio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GenericRazorPortfolio.Pages
{
    public class GalleryModel : PageModel
    {
        private IGenericRazorPortfolioRepo _repository;

        public GalleryModel(IGenericRazorPortfolioRepo repository)
        {
            _repository = repository;

        }

        public List<ImageData> Images { get; set; }

        public void OnGet()
        {
            Images = _repository.GetAllImageData().ToList();

        }
    }
}
