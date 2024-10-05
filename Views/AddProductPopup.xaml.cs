using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Views;

namespace HeThongQuanLy.Views;


public partial class AddProductPopup : Popup
{
	public IList<int> Choices = [1, 3, 6, 12];
	private int _duration;
	public AddProductPopup()
	{
		InitializeComponent();
	}

	void OnRenewButtonClicked(object? sender, EventArgs e)
	{
		Close();
	}

	void OnCancelButtonClicked(object? sender, EventArgs e)
	{

		Close();
	} 
}