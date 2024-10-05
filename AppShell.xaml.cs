namespace HeThongQuanLy;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(Views.ProductDetailPage), typeof(Views.ProductDetailPage));
		Routing.RegisterRoute(nameof(Views.UserProductDetailPage), typeof(Views.UserProductDetailPage));
		Routing.RegisterRoute(nameof(Views.CheckoutPage), typeof(Views.CheckoutPage));
	}
}
