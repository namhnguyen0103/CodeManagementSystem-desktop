namespace WindowsApp.Views;

public partial class RequestDetail : ContentPage
{
	public ViewModels.RequestViewModel Request
	{
		set => Load(value);
	}
	
	public RequestDetail()
	{
		InitializeComponent();
	}

	private void Load(ViewModels.RequestViewModel rvm)
	{
		if (rvm != null)
		{
			BindingContext = rvm;
		}
	}
}