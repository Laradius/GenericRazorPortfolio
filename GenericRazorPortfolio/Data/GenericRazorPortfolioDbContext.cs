using GenericRazorPortfolio.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericRazorPortfolio.Data
{
    public class GenericRazorPortfolioDbContext : DbContext
    {


        public GenericRazorPortfolioDbContext(DbContextOptions<GenericRazorPortfolioDbContext> opt) : base(opt)
        {

        }
        public DbSet<ImageData> ImageData { get; set; }
        public DbSet<Administrator> Administrators { get; set; }

    }
}
