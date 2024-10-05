namespace HeThongQuanLy.Views;

public partial class SignUpPage : ContentPage
{
	public SignUpPage()
	{
		InitializeComponent();
	}

	private async void Login_Clicked(object sender, EventArgs e) {
		await Shell.Current.GoToAsync("//LoginPage");
	}
}