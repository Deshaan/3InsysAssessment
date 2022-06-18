using System.Threading.Tasks;
using _3Insys.Assessment.Models;

namespace _3Insys.Assessment.ClientFactory
{
    public interface IHttpClientServiceImplementation
    {
        Task<TShirtHomeModel> GetListOfAllTshirs();
        Task<ManageTShirtModel> GetDetailofShirt(int id);
        Task Save(TShirt model);
        Task Delete(int id);
    }
}
