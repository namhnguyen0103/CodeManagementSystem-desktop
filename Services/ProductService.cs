using System.Net.Http.Json;
using Newtonsoft.Json;
using HeThongQuanLy.Models;
using HeThongQuanLy.Repository;

namespace HeThongQuanLy.Services;

public class ProductService : IProductRepository
{
    private readonly HttpClient _httpclient;

    public ProductService()
    {
        _httpclient = new HttpClient();
        _httpclient.BaseAddress = new Uri(Constant.API_BASE_URL+"products/");
    }

    public async Task<List<Models.Product>?> GetAllAsync()
    {
        var productList = new List<Models.Product>();
        
        if(Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            return null;

        HttpResponseMessage response = await _httpclient.GetAsync("");
        if (response.IsSuccessStatusCode)
        {
            string content = response.Content.ReadAsStringAsync().Result;
            productList = JsonConvert.DeserializeObject<List<Product>>(content);

            return productList;
        }
        return null;
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
