using System.Windows.Input;

namespace HeThongQuanLy.ViewModels;

public class UserSettingsViewModel 
{
    public UserSettingsViewModel()
    {
        LogoutButton_Command = new Command(Logout);
    }

    public ICommand LogoutButton_Command { get; set; }

    private async void Logout()
    {
        Constant.Current_user = string.Empty;
        if (GetUserProductPageViewModel.GetUserProduct != null) GetUserProductPageViewModel.GetUserProduct.SoftwareProducts.Clear();
        if (GetShoppingCartViewModel.GetCartViewModel != null) GetShoppingCartViewModel.GetCartViewModel.Products.Clear();
        await Shell.Current.GoToAsync("///LoginPage");
    }
}
