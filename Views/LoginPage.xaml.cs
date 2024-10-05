namespace WindowsApp.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		BindingContext = new ViewModels.LoginViewModel();
		InitializeComponent();
	}

	
}