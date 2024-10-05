namespace HeThongQuanLy.Views;

[QueryProperty(nameof(CheckoutItems), "CheckoutItems")]
public partial class CheckoutPage : ContentPage
{
	public ViewModels.CheckoutViewModel CheckoutItems 
	{
		set {
			Load(value);
		}
	}
	
	public CheckoutPage()
	{
		InitializeComponent();
	}

	private void Load(ViewModels.CheckoutViewModel cvm)
	{
		if (cvm != null)
		{
			BindingContext = cvm;
		}
	}
}