﻿using GenericRazorPortfolio.Models;
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

        public IEnumerable<ImageData> GetAllImageData()
        {
            return _context.ImageData.ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}