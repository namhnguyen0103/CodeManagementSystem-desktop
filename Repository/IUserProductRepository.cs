using HeThongQuanLy.Models;

namespace HeThongQuanLy.Repository;

public interface IUserProductRepository
{
        Task<List<UserProduct>> GetByUserIdAsync(string user_id);
        Task<UserProduct?> GetByIdAsync(int id);
        Task<UserProduct?> CreateAsync(Models.CartItem cartItem);
}
