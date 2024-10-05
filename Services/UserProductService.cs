using WindowsApp.Repository;
using WindowsApp.Models;
using System.Net.Http.Json;
using Newtonsoft.Json;
using System.Text;

using WindowsApp.Repository;

namespace WindowsApp.Services;

public class UserProductService : IUserProductRepository
{
    private readonly HttpClient _httpclient;

    public UserProductService()
    {
        _httpclient = new HttpClient();
        _httpclient.BaseAddress = new Uri(Constants.API_BASE_URL + "user_products/");
    }
    public async Task<List<UserProduct>> GetByUserIdAsync(string id)
    {
            if(Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                return null;

            HttpResponseMessage response = await _httpclient.GetAsync("getByUserId/" + id);
            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                List<UserProduct> userProductList = JsonConvert.DeserializeObject<List<UserProduct>>(content);

                return userProductList;
            }
            return null;
    }

}
