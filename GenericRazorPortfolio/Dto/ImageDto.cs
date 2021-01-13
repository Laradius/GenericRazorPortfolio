using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GenericRazorPortfolio.Dto
{
    public class ImageDto { 


         public ImageDto()
    {

    }

    public ImageDto(string title, string desc, string thumb, string link)
    {
            Title = title;
            Description = desc;
            ThumbnailLink = thumb;
            Link = link;
    }
    
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
