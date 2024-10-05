using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace HeThongQuanLy.Models;

public class LoginRequestModel
{   
    public string Id { get; set; } = string.Empty;
    public string Account_password { get; set; } = string.Empty;
}
