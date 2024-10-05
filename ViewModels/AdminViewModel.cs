using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;


namespace WindowsApp.ViewModels;

public class AdminViewModel : ObservableObject
{
    private string _id;
    
    private string _name;

    private string _email;

    private bool _superAdmin;

    public string Id
    {
        get => _id;
        set
        {
            SetProperty(ref _id, value);
        }
    }

    public string Name
    {
        get => _name;
        set
        {
            SetProperty(ref _name, value);
        }
    }

    public string Email
    {
        get => _email;
        set
        {
            SetProperty(ref _email, value);
        }
    }

    public bool SuperAdmin
    {
        get => _superAdmin;
        set
        {
            SetProperty(ref _superAdmin, value);
        }
    }

    public ICommand BackButton_Tapped { get; set; }

    public AdminViewModel(Models.Admin admin)
    {
        _id = admin.AdminID;
        _name = admin.Name;
        _email = admin.Email;
        _superAdmin = admin.SuperAdmin;
        BackButton_Tapped = new Command(GoBack);
    }

    private async void GoBack()
    {
        await Shell.Current.Navigation.PopAsync();
    }

}
