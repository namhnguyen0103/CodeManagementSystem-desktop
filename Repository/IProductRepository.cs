namespace HeThongQuanLy.Repository;

public interface IProductRepository
{
        Task<List<Models.Product>> GetAllAsync();
        Task<Models.Product?> GetByIdAsync(int id);
}
