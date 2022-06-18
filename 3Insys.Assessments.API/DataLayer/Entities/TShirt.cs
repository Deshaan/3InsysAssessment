using System.ComponentModel.DataAnnotations;
namespace _3Insys.Assessments.API.Data.Entities
{
    public class TShirt
    {
        [Key]
        public int Id { get; set; }
        public string Size { get; set; }
        public string Price { get; set; }
        public string Color { get; set; }
        public string Made { get; set; }
        public string Style { get; set; }
        public string Gender { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; set; }
    }
}
