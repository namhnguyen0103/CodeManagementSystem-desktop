using WindowsApp.ViewModels;

namespace WindowsApp.Views;

public partial class RequestPage : ContentPage
{
	public RequestPage()
	{
		InitializeComponent();
		RequestPageViewModel rvm = new RequestPageViewModel();
		BindingContext = rvm;
	}
}