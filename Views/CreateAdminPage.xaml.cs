namespace WindowsApp.Views;

public partial class CreateAdminPage : ContentPage
{
	public CreateAdminPage()
	{
		BindingContext = new ViewModels.CreateAdminViewModel();
		InitializeComponent();
	}
}