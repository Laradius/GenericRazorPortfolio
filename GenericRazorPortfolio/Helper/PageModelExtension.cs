using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GenericRazorPortfolio.Helper
{
    public static class PageModelExtension
    {

        public static string ReadTokenCookie(this PageModel model)
        {
            return model.Request.Cookies["Token"];
        }

        public static bool ValidTokenExists(this PageModel model)
        {
            string token = model.Request.Cookies["Token"];

            if (JwtAuthorizer.ValidateToken(token))
            {
                return true;
            }

            return false;
        }

       public static List<Claim> GetClaims(this PageModel model)
        {
            return  model.User.Claims.ToList();
        } 

        public static string GetClaimValue(this PageModel model, string claimName)
        {
           return model.User.Claims.FirstOrDefault(x => x.Type.Equals(claimName, StringComparison.OrdinalIgnoreCase))?.Value;
        }

    }
}
