using GenericRazorPortfolio.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace GenericRazorPortfolio.Helper
{
    public class JwtAuthenticator : IAuthenticator
    {
        public JwtAuthenticator(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public string GenerateAccountAccessToken(Administrator account)
        {


            SymmetricSecurityKey securityKey = null;
            SigningCredentials credentials = null;


            securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtSecretKey"]));



        


            credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("ID", account.Id.ToString()),
                new Claim("Email", account.Email),
                new Claim("Name", account.Name),
            };

            var token = new JwtSecurityToken(

                issuer: Configuration["JwtIssuer"],
                audience: Configuration["JwtAudience"],
                

                claims,
                expires: DateTime.Now.AddDays(7), signingCredentials: credentials);

            var encodetoken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodetoken;
        }


 

    }
}
