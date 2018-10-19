using System.Collections.Generic;
using System.Threading.Tasks;
using XmMobileApp.Models;
using XmMobileApp.RestClients;

namespace XmMobileApp.Services
{
    public class ProductService
    {
        private readonly ProductRestClient productRestClient = new ProductRestClient();

        public async Task<List<Product>> GetProducts()
        {
            return await productRestClient.GetProductsAsync();
        }

        public async Task<bool> CreateProduct(Product product)
        {
            return await productRestClient.PostProductAsync(product);
        }

        public async Task<bool> UpdateProduct(int id, Product product)
        {
            return await productRestClient.PutProductAsync(id, product);
        }

        public async Task<bool> DeleteProduct(int id)
        {
            return await productRestClient.DeleteProductAsync(id);
        }
    }
}
