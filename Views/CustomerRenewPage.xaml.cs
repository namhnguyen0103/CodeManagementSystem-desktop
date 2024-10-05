namespace WindowsApp.Views;

public partial class CustomerRenewPage : ContentPage
{
	public ViewModels.RequestViewModel Request
	{
		set => Load(value);
	}

	public CustomerRenewPage()
	{
		InitializeComponent();
	}

	private void Load(ViewModels.RequestViewModel rvm)
	{
		if (rvm != null)
		{
			BindingContext = rvm;
		}
	}
}