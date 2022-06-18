using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace _3Insys.Assessment.Models
{
    public class TShirt
    {
        public int? Id { get; set; }
        [Required]
        public string Size { get; set; }
        [Required]
        public string Price { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public string Made { get; set; }
        [Required]
        public string Style { get; set; }
        [Required]
        public string Gender { get; set; }
        public string Gender_Display
        {
            get
            {
                if (Gender == "Male")
                    return "M";
                else
                    return "F";
            }

        }
        public byte[] Image { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public IFormFile ImageFile { get; set; }
        public string ImageSrc
        {
            get
            {
                if (Image != null && Image.Length > 0)
                {
                    return "data:image/png;base64," + Convert.ToBase64String(Image);
                }

                return "";
            }
        }
    }
}
