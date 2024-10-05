using WindowsApp.Repository;
using WindowsApp.Models;
using System.Net.Http.Json;
using Newtonsoft.Json;
using System.Text;

namespace WindowsApp.Services;

public class ProductService : IProductRepository
{
    private readonly HttpClient _httpclient;

    public ProductService()
    {
        _httpclient = new HttpClient();
        _httpclient.BaseAddress = new Uri(Constants.API_BASE_URL+"products/");
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        if(Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            return null;

        HttpResponseMessage response = await _httpclient.GetAsync(id.ToString());
        if (response.IsSuccessStatusCode)
        {
            string content = response.Content.ReadAsStringAsync().Result;
            var product = JsonConvert.DeserializeObject<Product>(content);

            return product;
        }
        return null;
    }
}
