namespace WindowsApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
	}

	public async void LogoutButtonClicked(object sender, EventArgs args)
	{
		await Shell.Current.GoToAsync("///LoginPage");
	}
}
