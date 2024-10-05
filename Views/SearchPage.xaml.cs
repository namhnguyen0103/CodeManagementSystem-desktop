namespace WindowsApp.Views;

public partial class SearchPage : ContentPage
{
	public SearchPage()
	{
		BindingContext = new ViewModels.SearchPageViewModel();
		InitializeComponent();
	}
}