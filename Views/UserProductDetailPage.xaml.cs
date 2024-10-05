using CommunityToolkit.Maui.Views;

namespace HeThongQuanLy.Views;

[QueryProperty(nameof(Product), "Product")]
public partial class UserProductDetailPage : ContentPage
{
	public ViewModels.UserProductViewModel Product
	{
		set {
			Load(value);
		}
	}

	public UserProductDetailPage()
	{
		InitializeComponent();
	}

	private void Load(ViewModels.UserProductViewModel product)
	{
		if (product != null) 
			BindingContext = product;
	}

	private void RenewButtonClicked(object sender, EventArgs e)
	{
		this.ShowPopup(new AddProductPopup());
	} 
}