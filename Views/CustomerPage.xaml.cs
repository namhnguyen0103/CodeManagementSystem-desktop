namespace WindowsApp.Views;

[QueryProperty(nameof(Customer), "Customer")]
public partial class CustomerPage : ContentPage
{
	
	public ViewModels.CustomerViewModel Customer
	{
		set {
			Load(value);
		}
	}


	public CustomerPage()
	{
		InitializeComponent();
	}

	private void Load(ViewModels.CustomerViewModel customer)
	{
		if (customer != null)
		{
			BindingContext = customer;
		}
	}
}