using System.Collections.Generic;

namespace _3Insys.Assessments.API.Models
{
    public class TShirtHomeModel
    {
        public List<TShirt> TShirts { get; set; }

        public TShirtHomeModel(List<Data.Entities.TShirt> tshirts)
        {
            TShirts = new List<TShirt>();

            foreach(var item in tshirts)
            {
                TShirts.Add(new TShirt(item));
            }
        }
    }
}
