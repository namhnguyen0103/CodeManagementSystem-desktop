using WindowsApp.Models;

namespace WindowsApp.Repository;

public interface IRequestRepository
{
    Task<List<Request>> GetAllAsync();
    Task<List<Request>> GetAllAwaitingAsync();
    Task<Request> GetByIdAsync();
    public Task<bool> UpdateAsync(int id, bool isApproved);
}
