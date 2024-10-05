namespace HeThongQuanLy.Views;

[QueryProperty(nameof(Product), "Product")]
public partial class ProductDetailPage : ContentPage
{

	public ViewModels.ProductViewModel Product 
	{
		set {
			Load(value);
		}
	}
	public ProductDetailPage()
	{
		InitializeComponent();
	}

	private void Load(ViewModels.ProductViewModel product)
	{
		if (product != null) 
			BindingContext = product;
	}
}