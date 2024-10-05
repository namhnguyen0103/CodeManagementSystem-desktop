using WindowsApp.Models;

namespace WindowsApp.Repository;

public interface IUserProductRepository
{
    Task<List<UserProduct>> GetByUserIdAsync(string user_id);
}
