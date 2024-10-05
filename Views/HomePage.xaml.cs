using HeThongQuanLy.ViewModels;

namespace HeThongQuanLy.Views;

public partial class HomePage : ContentPage
{	
	public HomePage()
	{
		BindingContext = new ViewModels.HomePageViewModel();
		InitializeComponent();
	}
}