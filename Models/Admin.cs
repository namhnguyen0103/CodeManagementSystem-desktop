using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace WindowsApp.Models;

public class Admin : ObservableObject
{
    private string _adminID;

    public string AdminID
    {
        get => _adminID;
        set => SetProperty(ref _adminID, value);
    }

    private string _name;

    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    private string _email;

    public string Email
    {
        get => _email;
        set => SetProperty(ref _email, value);
    }

    private bool _superAdmin;

    public bool SuperAdmin
    {
        get => _superAdmin;
        set => SetProperty(ref _superAdmin, value);
    }

}
