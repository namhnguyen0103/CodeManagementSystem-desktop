namespace WindowsApp.Views;

public partial class AdminPage : ContentPage
{
	public AdminPage()
	{
		BindingContext = new ViewModels.AdminPageViewModel();
		InitializeComponent();
	}
}