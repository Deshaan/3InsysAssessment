using System.Linq;

namespace _3Insys.Assessments.API.Models
{
    public class TShirt
    {
        public int? Id { get; set; }
        public string Size { get; set; }
        public string Price { get; set; }
        public string Color { get; set; }
        public string Made { get; set; }
        public string Style { get; set; }
        public string Gender { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; set; }

        public TShirt(Data.Entities.TShirt shirt)
        {
            Id = shirt.Id;
            Size = shirt.Size;
            Price = shirt.Price;
            Color = shirt.Color;
            Made = shirt.Made;
            Style = shirt.Style;
            Gender = shirt.Gender;
            Image = shirt.Image;
            Description = shirt.Description;

        }

        public TShirt()
        {

        }
    }
}
