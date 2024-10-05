using System.ComponentModel;
using System.Reflection.Metadata;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using WindowsApp.Repository;
using WindowsApp.Services;

namespace WindowsApp.ViewModels;

public class LoginViewModel : ObservableObject, INotifyPropertyChanged
{
    private readonly IAccountRepository _accountRepo = new AccountService();
    public ICommand Login_Command { get; set; }

    private string _id;
    public string Id
    {
        get => _id;
        set
        {
            SetProperty(ref _id, value);
            OnPropertyChanged();
        }
    }

    private Models.LoginRequestModel _myLoginRequestModel = new Models.LoginRequestModel();

    private string _password;

    public string Password
    {
        get => _password;
        set 
        {
            SetProperty(ref _password, value);
            OnPropertyChanged();
        }
    }
    
    public async void GoToMainPage()
    {
        await Shell.Current.GoToAsync("///HomePage/Search");
    }

    public LoginViewModel()
    {
        Login_Command = new Command(PerformLoginOperation);
    }

    private async void PerformLoginOperation()
    {
        var data = _myLoginRequestModel;
        data.Id = Id;
        data.Account_password = Password;
        var isValid = await _accountRepo.VerifyLoginAsync(data);
        if (isValid == true)
        {
            Constants.Current_user = data.Id;
            await Shell.Current.GoToAsync("///HomePage/Search", false);
            Id = string.Empty;
            Password = string.Empty;
        }
        else
        {
            await Shell.Current.DisplayAlert("Invalid Login","The data entered is incorrect", "Ok");
        }
    }
}
