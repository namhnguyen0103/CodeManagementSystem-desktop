using HeThongQuanLy.Models;

namespace HeThongQuanLy.Repository;

public interface IAccountRepository
{
    Task<bool?> VerifyLogin(Models.LoginRequestModel loginInfo);
}
