using HeThongQuanLy.Repository;
using HeThongQuanLy.Models;
using System.Net.Http.Json;
using Newtonsoft.Json;
using System.Text;

namespace HeThongQuanLy.Services;

public class AccountService : IAccountRepository
{
        private readonly HttpClient _httpclient;

        public AccountService()
        {
            _httpclient = new HttpClient();
            _httpclient.BaseAddress = new Uri(Constant.API_BASE_URL + "accounts/");
        }

    
    public async Task<bool?> VerifyLogin(LoginRequestModel loginInfo)
    {
        if(Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            return null;

        var jsonString = JsonConvert.SerializeObject(loginInfo);
        var stringContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await _httpclient.PostAsync("customerLogin", stringContent);
        if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                var isValid = JsonConvert.DeserializeObject<bool>(content);

                return isValid;
            }
            return null;
    }
}
