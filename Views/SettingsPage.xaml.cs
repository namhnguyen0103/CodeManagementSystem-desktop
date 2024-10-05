using HeThongQuanLy.ViewModels;

namespace HeThongQuanLy.Views;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();
		BindingContext = new UserSettingsViewModel();
	}

	private async void Logout(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("//LoginPage");
	}
}