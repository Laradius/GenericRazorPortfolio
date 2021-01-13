using GenericRazorPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericRazorPortfolio.Data
{
   public class SqlGenericRazorPortfolioRepo : IGenericRazorPortfolioRepo
    {
        private GenericRazorPortfolioDbContext _context;

        public SqlGenericRazorPortfolioRepo(GenericRazorPortfolioDbContext context)
        {
            _context = context;
        }

        public Administrator GetAccountByEmail(string email)
        {
            return _context.Administrators.FirstOrDefault(x => email == x.Email);
        }

        public Administrator GetAccountById(int id)
        {
            return _context.Administrators.FirstOrDefault(x => id == x.Id);
        }

        public IEnumerable<ImageData> GetAllImageData()
        {
            return _context.ImageData.ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void CreateImage(ImageData image)
        {
            _context.Add(image);
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
