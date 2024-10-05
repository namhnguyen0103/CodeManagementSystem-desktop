namespace HeThongQuanLy.Views;

public partial class LoginPage : ContentPage
{
	public const double MyFontSize = 28;
	public LoginPage()
	{
		InitializeComponent();
	}

	private async void RegisterNow_Clicked(object sender, EventArgs e) {
		await Shell.Current.GoToAsync("//SignUpPage");
	}

	private async void Login_Clicked(object sender, EventArgs e) {
		await Shell.Current.GoToAsync($"//{nameof(HomePage)}/Main");
	}

}

