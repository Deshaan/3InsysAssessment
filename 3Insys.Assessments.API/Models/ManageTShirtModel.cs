namespace _3Insys.Assessments.API.Models
{
    public class ManageTShirtModel
    {
        public int RequestedId { get; set; }
        public bool NewTShirt { get; set; }
        public bool TShirtFound { get { return tShirt != null || NewTShirt; } }
        public TShirt tShirt { get; set; }
    }
}
