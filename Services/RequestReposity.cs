using System.Text;
using HeThongQuanLy.Models;
using HeThongQuanLy.Repository;
using Newtonsoft.Json;

namespace HeThongQuanLy.Services;

public class RequestReposity : IRequestRepository
{
    private readonly HttpClient _httpclient;

    public RequestReposity()
    {
        _httpclient = new HttpClient();
        _httpclient.BaseAddress = new Uri(Constant.API_BASE_URL+"requests/");
    }
    public async Task<bool> CreateRequest(int product_id, int duration)
    {
        if(Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            return false;
        var newRequest = new {
            Product_id = product_id,
            Duration = duration
        };

        var jsonString = JsonConvert.SerializeObject(newRequest);
        var stringContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await _httpclient.PostAsync("createRequest", stringContent);
        if (response.IsSuccessStatusCode)
        {
            return true;
        }
        return false;
    }
}
