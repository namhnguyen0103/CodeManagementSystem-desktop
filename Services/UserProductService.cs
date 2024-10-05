using System.Text;
using HeThongQuanLy.Models;
using HeThongQuanLy.Repository;
using Newtonsoft.Json;

namespace HeThongQuanLy.Services;

public class UserProductService : IUserProductRepository
{
        private readonly HttpClient _httpclient;

        public UserProductService()
        {
            _httpclient = new HttpClient();
            _httpclient.BaseAddress = new Uri(Constant.API_BASE_URL + "user_products/");
        }
        

        public async Task<List<UserProduct>?> GetByUserIdAsync(string user_id)
        {
            var userProductList = new List<Models.UserProduct>();
            if(Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                return null;

            HttpResponseMessage response = await _httpclient.GetAsync("getByUserId/" + user_id);
            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                userProductList = JsonConvert.DeserializeObject<List<UserProduct>>(content);

                return userProductList;
            }
            return null;

        }
        public async Task<UserProduct?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<UserProduct?> CreateAsync(Models.CartItem cartItem)
        {
            if(Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                return null;
            
            var newUserProduct = new 
            {
                Customer_id = Constant.Current_user,
                Product_id = cartItem.Product_id, 
                Duration = cartItem.Duration
            };

            var jsonString = JsonConvert.SerializeObject(newUserProduct);
            var stringContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpclient.PostAsync("", stringContent);
            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                var userProduct = JsonConvert.DeserializeObject<UserProduct>(content);

                return userProduct;
            }
            return null;
        }
}
