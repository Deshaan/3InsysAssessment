namespace _3Insys.Assessment.Models
{
    public class ManageTShirtModel
    {
        public int RequestedId { get; set; }
        public bool NewTShirt { get; set; }
        public bool TShirtFound { get; set; }
        public TShirt tShirt { get; set; }
    }
}
