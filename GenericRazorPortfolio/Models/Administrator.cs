using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GenericRazorPortfolio.Models
{
    public class Administrator
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        [EmailAddress]
        [MaxLength(128)]
        [Required]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"((?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%]).{8,32})", ErrorMessage = @"Password must contain minimum eight characters, at least one letter, one number and one special character")]
        public string Password { get; set; }



    }
}
