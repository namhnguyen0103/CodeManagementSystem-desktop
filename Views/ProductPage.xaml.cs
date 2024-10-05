using Microsoft.Maui.Controls.Compatibility.Platform.iOS;

namespace WindowsApp.Views;

public partial class ProductPage : ContentPage
{
	
	public ViewModels.ProductViewModel Product
	{
		set {
			Load(value);
		}
	}
	
	public ProductPage()
	{
		InitializeComponent();
	}

	private void Load(ViewModels.ProductViewModel pvm)
	{
		if (pvm != null) 
		{
			BindingContext = pvm;
		}
	}
}