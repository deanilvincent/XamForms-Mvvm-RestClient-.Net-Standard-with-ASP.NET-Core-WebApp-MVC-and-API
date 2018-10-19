using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XmMobileApp.Models;

namespace XmMobileApp.RestClients
{
    public class ProductRestClient
    {
        private const string ApiUrl = "http://mywebappdemo01.azurewebsites.net/api/products/";

        private readonly HttpClient httpClient = new HttpClient();
        private HttpContent httpContent;

        public async Task<List<Product>> GetProductsAsync()
        {
            var json = await httpClient.GetStringAsync(ApiUrl);

            return JsonConvert.DeserializeObject<List<Product>>(json);
        }

        public async Task<bool> PostProductAsync(Product product)
        {
            var json = JsonConvert.SerializeObject(product);

            httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PostAsync(ApiUrl, httpContent);

            return result.IsSuccessStatusCode;
        }

        public async Task<bool> PutProductAsync(int id, Product product)
        {
            var json = JsonConvert.SerializeObject(product);

            httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PutAsync($"{ApiUrl}{id}", httpContent);

            return result.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var result = await httpClient.DeleteAsync($"{ApiUrl}{id}");

            return result.IsSuccessStatusCode;
        }
    }
}
