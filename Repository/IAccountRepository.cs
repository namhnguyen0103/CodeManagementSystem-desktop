using WindowsApp.Models;

namespace WindowsApp.Repository;

public interface IAccountRepository
{
    Task<bool?> VerifyLoginAsync(Models.LoginRequestModel loginInfo);
    Task<List<Customer>> GetCustomersAsync();
    Task<List<Admin>> GetAdminsAsync();
}
