using HeThongQuanLy.Models;

namespace HeThongQuanLy.Repository;

public interface ICartItemRepository
{
        Task<List<CartItem>> GetByUserIdAsync(string user_id);
        Task<CartItem?> UpdateAsync(CartItem cartItem);
        Task<CartItem?> DeleteAsync(int id);
        Task<CartItem?> CreateAsync(CartItem cartItem);
}
