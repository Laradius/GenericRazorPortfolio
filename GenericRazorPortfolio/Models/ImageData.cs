using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GenericRazorPortfolio.Models
{
    public class ImageData
    {
        [Key]
        public int Id { get; set; }


        [Required]
        [MaxLength(128)]
        public string Author { get; set; }

        [MaxLength(128)]
        public string Title { get; set; }
        [MaxLength(256)]
        public string Description { get; set; }



        [Required]
        [MaxLength(256)]
        public string ThumbnailLink { get; set; }
        [Required]
        [MaxLength(256)]
        public string Link { get; set; }



    }
}
