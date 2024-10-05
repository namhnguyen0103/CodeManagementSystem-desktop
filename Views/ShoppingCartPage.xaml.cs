namespace HeThongQuanLy.Views;

public partial class ShoppingCartPage : ContentPage
{
	public ShoppingCartPage()
	{
		BindingContext = new ViewModels.ShoppingCartViewModel();
		InitializeComponent();
	}
}