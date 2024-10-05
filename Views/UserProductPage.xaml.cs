namespace HeThongQuanLy.Views;

public partial class UserProductPage : ContentPage
{
	public UserProductPage()
	{
		BindingContext = new ViewModels.UserProductPageViewModel();
		InitializeComponent();
	}
}