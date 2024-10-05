using WindowsApp.Models;

namespace WindowsApp.Repository;

public interface IProductRepository
{
    Task<Product?> GetByIdAsync(int id);
}
