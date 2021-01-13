﻿using GenericRazorPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericRazorPortfolio.Data
{
    public interface IGenericRazorPortfolioRepo
    {

        IEnumerable<ImageData> GetAllImageData();

        void SaveChanges();


    }
}