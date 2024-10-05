using HeThongQuanLy.Repository;
using HeThongQuanLy.Models;
using System.Net.Http.Json;
using Newtonsoft.Json;
using System.Text;

namespace HeThongQuanLy.Services;

public class CartItemService : ICartItemRepository
{       
        private readonly HttpClient _httpclient;

        public CartItemService()
        {
            _httpclient = new HttpClient();
            _httpclient.BaseAddress = new Uri(Constant.API_BASE_URL + "cart_item/");
        }

        public async Task<List<CartItem>> GetByUserIdAsync(string user_id)
        {
            var cartItemList = new List<CartItem>();
            if(Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                return null;

            HttpResponseMessage response = await _httpclient.GetAsync("getByUserId/" + user_id);
            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                cartItemList = JsonConvert.DeserializeObject<List<CartItem>>(content);

                return cartItemList;
            }
            return null;
        }
        public async Task<CartItem?> UpdateAsync(CartItem cartItem)
        {
            var changes = new {
                Id = cartItem.Id,
                Customer_id = cartItem.Customer_id,
                Product_id = cartItem.Product_id,
                Duration = cartItem.Duration,
                Selected = cartItem.Selected
            };

            var jsonString = JsonConvert.SerializeObject(changes);
            var stringContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
            if(Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                return null;
            
            HttpResponseMessage response = await _httpclient.PutAsync("", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return cartItem;
            }
            return null;
        }
        public async Task<CartItem?> DeleteAsync(int id)
        {
            if(Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                return null;

            HttpResponseMessage response = await _httpclient.DeleteAsync($"{id}");
            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                var cartItem = JsonConvert.DeserializeObject<CartItem>(content);
                return cartItem;
            }
            return null;
            // throw new NotImplementedException();
        }
        public async Task<CartItem?> CreateAsync(CartItem cartItem)
        {
            if(Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                return null;
            var newCartItem = new {
                Customer_id = cartItem.Customer_id,
                Product_id = cartItem.Product_id,
                Duration = cartItem.Duration,
                Selected = true
            };

            var jsonString = JsonConvert.SerializeObject(newCartItem);
            var stringContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpclient.PostAsync("", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return cartItem;
            }
            return null;
        }
}
