using WindowsApp.Repository;
using WindowsApp.Models;
using System.Net.Http.Json;
using Newtonsoft.Json;
using System.Text;

namespace WindowsApp.Services;

public class AccountService : IAccountRepository
{
    private readonly HttpClient _httpClient;

    public AccountService()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(Constants.API_BASE_URL + "accounts/");
    }

    public async Task<List<Admin>> GetAdminsAsync()
    {
        if(Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            return [];
        
        HttpResponseMessage response = await _httpClient.GetAsync("getAdminAccounts");
        if (response.IsSuccessStatusCode)
        {
            string content = response.Content.ReadAsStringAsync().Result;
            List<Admin> admins = JsonConvert.DeserializeObject<List<Admin>>(content);

            return admins;
        }
        return [];
    }

    public async Task<List<Customer>> GetCustomersAsync()
    {
        if(Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            return [];
        
        HttpResponseMessage response = await _httpClient.GetAsync("getCustomerAccounts");
        if (response.IsSuccessStatusCode)
        {
            string content = response.Content.ReadAsStringAsync().Result;
            List<Customer> customers = JsonConvert.DeserializeObject<List<Customer>>(content);

            return customers;
        }
        return [];
    }

    public async Task<bool?> VerifyLoginAsync(LoginRequestModel loginInfo)
    {
        if(Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            return null;

        var jsonString = JsonConvert.SerializeObject(loginInfo);
        var stringContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await _httpClient.PostAsync("adminLogin", stringContent);
        if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                var isValid = JsonConvert.DeserializeObject<bool>(content);

                return isValid;
            }
            return null;
    }
}
