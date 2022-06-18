using _3Insys.Assessment.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using System.Net.Http.Headers;

namespace _3Insys.Assessment.ClientFactory
{
    public class HttpClientFactoryService : IHttpClientServiceImplementation
    {
        private IHttpClientFactory _httpClientFactory;
        public HttpClientFactoryService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<ManageTShirtModel> GetDetailofShirt(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("API");
            using (var response = await httpClient.GetAsync("api/tshirts/manage?id="+id, HttpCompletionOption.ResponseHeadersRead))
            {
                response.EnsureSuccessStatusCode();

                var stream = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<ManageTShirtModel>(stream);

                return result;
            }
        }

        public async Task<TShirtHomeModel> GetListOfAllTshirs()
        {
            var httpClient = _httpClientFactory.CreateClient("API");
            using (var response = await httpClient.GetAsync("api/tshirts/index", HttpCompletionOption.ResponseHeadersRead))
            {
                response.EnsureSuccessStatusCode();

                var stream = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<TShirtHomeModel>(stream);

                return result;
            }
        }

        public async Task Save(TShirt model)
        {
            var jsonContrne = JsonConvert.SerializeObject(model);
            HttpContent httpContent = new StringContent(jsonContrne, Encoding.UTF8, "application/json");
            var httpClient = _httpClientFactory.CreateClient("API");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header          
            using (var response = await httpClient.PostAsync("api/TShirts/Save", httpContent))
            {
                response.EnsureSuccessStatusCode();
            }
        }
        public async Task Delete(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("API");
            using (var response = await httpClient.PostAsync("api/tshirts/delete?id=" + id, null))
            {
                response.EnsureSuccessStatusCode();
            }
        }
    }
}
