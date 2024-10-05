namespace HeThongQuanLy.Repository;

public interface IRequestRepository
{
    Task<bool> CreateRequest(int product_id, int duration);
}
