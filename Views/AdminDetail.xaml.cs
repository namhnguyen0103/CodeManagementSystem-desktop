namespace WindowsApp.Views;

[QueryProperty(nameof(Admin), "Admin")]
public partial class AdminDetail : ContentPage
{
	public ViewModels.AdminViewModel Admin
	{
		set {
			Load(value);
		}
	}
	
	public AdminDetail()
	{
		InitializeComponent();
	}

	private void Load(ViewModels.AdminViewModel admin)
	{
		if (admin != null)
		{
			BindingContext = admin;
		}
	}
}