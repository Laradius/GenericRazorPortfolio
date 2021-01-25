using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GenericRazorPortfolio.Models
{
    public class MailMessage
    {

        [Required]
        [EmailAddress]
        [MaxLength(128)]
        public string From { get; set; }

        [Required]
        [MaxLength(256)]
        public string Title { get; set; }

        [Required]
        [MaxLength(1024)]

        public string Message { get; set; }



    }
}
