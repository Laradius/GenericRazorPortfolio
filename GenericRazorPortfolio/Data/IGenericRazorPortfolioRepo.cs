using GenericRazorPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericRazorPortfolio.Data
{
    public interface IGenericRazorPortfolioRepo
    {

        IEnumerable<ImageData> GetAllImageData();

        Administrator GetAccountByEmail(string email);
        Administrator GetAccountById(int id);

        void SaveChanges();

        Task SaveChangesAsync();

        public void CreateImage(ImageData image);


    }
}
