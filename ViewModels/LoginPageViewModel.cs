using System.ComponentModel;
using System.Windows.Input;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HeThongQuanLy.Models;
using HeThongQuanLy.Repository;


namespace HeThongQuanLy.ViewModels;

internal partial class LoginPageViewModel : ObservableObject, INotifyPropertyChanged
{

    private readonly IAccountRepository _accountRepo = new Services.AccountService();

    public string Heading => "Welcome back";

    public string Subheading => "sign in to access your account";

    public string UsernameEntry => "Account ID or email";

    public string PasswordEntry => "Password";

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

    private string _account_password;
    public string Account_password 
    {
        get => _account_password;
        set
        {
            SetProperty(ref _account_password, value);
            OnPropertyChanged();
        }
    }

    public string CheckboxText => "Remember me";

    public string ButtonText => "Login";

    public string RegisterNew => "New member?";

    public string RegisterButton => "Register now";

    private LoginRequestModel _myLoginRequestModel = new LoginRequestModel();

    public ICommand LoginButton_Command { get; set; }

    public ICommand RegisterButton_Command { get; set; }

    // public LoginPageViewModel(IPopupService popupService)
    // {
    //     this.popupService = popupService;
    //     LoginButton_Command = new Command(PerformLoginOperation);
    // }

    public LoginPageViewModel()
    {
        LoginButton_Command = new Command(PerformLoginOperation);
        RegisterButton_Command = new Command(GoToSignUpPage);
    }

    public async void GoToSignUpPage(object obj)
    {
        await Shell.Current.GoToAsync("///SignUpPage");
    }


    private async void PerformLoginOperation(object obj)
    {
        var data = _myLoginRequestModel;
        data.Id = Id;
        data.Account_password = Account_password;
        var isValid = await _accountRepo.VerifyLogin(data);
        if (isValid == true)
        {
            Constant.Current_user = data.Id;
            if (GetUserProductPageViewModel.GetUserProduct != null) GetUserProductPageViewModel.GetUserProduct.RefreshProducts();
            if (GetShoppingCartViewModel.GetCartViewModel != null) GetShoppingCartViewModel.GetCartViewModel.LoadProducts();
            await Shell.Current.GoToAsync("//HomePage/Main");
            Id = string.Empty;
            Account_password = string.Empty;
        }
        else
        {
            await Shell.Current.DisplayAlert("Invalid Login","The data entered is incorrect", "Ok");
        }

    }
}
