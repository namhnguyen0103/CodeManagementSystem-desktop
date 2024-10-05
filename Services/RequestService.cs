using WindowsApp.Repository;
using WindowsApp.Models;
using System.Net.Http.Json;
using Newtonsoft.Json;
using System.Text;
using WindowsApp.Repository;

namespace WindowsApp.Services;

public class RequestService : IRequestRepository
{
    private readonly HttpClient _httpClient;

    public RequestService()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(Constants.API_BASE_URL + "requests/");
    }
    public async Task<List<Request>> GetAllAsync()
    {
        if(Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            return [];
        

        HttpResponseMessage response = await _httpClient.GetAsync("");
        if (response.IsSuccessStatusCode)
        {
            string content = response.Content.ReadAsStringAsync().Result;
            var requests = JsonConvert.DeserializeObject<List<Request>>(content);
            return requests;
        }
        return [];
    }
    public async Task<List<Request>> GetAllAwaitingAsync()
    {
        if(Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            return [];
        

        HttpResponseMessage response = await _httpClient.GetAsync("getWaitingRequests");
        if (response.IsSuccessStatusCode)
        {
            string content = response.Content.ReadAsStringAsync().Result;
            var requests = JsonConvert.DeserializeObject<List<Request>>(content);
            return requests;
        }
        return [];
    }

    public async Task<Request> GetByIdAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateAsync(int id, bool isApproved)
    {
        if(Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            return false;
        
        var changes = new {
            Id = id,
            IsApproved = isApproved,
            ApprovedBy = Constants.Current_user
        };

        var jsonString = JsonConvert.SerializeObject(changes);
        var stringContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await _httpClient.PutAsync("updateRequest", stringContent); 
        return response.IsSuccessStatusCode;
    }
}
