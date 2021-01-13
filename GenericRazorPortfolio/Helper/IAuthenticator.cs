using GenericRazorPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericRazorPortfolio.Helper
{
    public interface IAuthenticator
    {
           public string GenerateAccountAccessToken(Administrator account);

    }
}
