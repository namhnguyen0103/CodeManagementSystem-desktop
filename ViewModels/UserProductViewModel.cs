using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;
using System.ComponentModel;
using CommunityToolkit.Maui.Views;
using HeThongQuanLy.Repository;
using HeThongQuanLy.Services;

namespace HeThongQuanLy.ViewModels;

public class UserProductViewModel : ObservableObject, INotifyPropertyChanged
{
    private readonly IRequestRepository _requestRepo = new RequestReposity();
    private Models.UserProduct _product;


    public Models.UserProduct Product 
    {
        get => _product;
    }

    public string ProductName
    {
        get => _product.ProductName;
    }

    public string Sitecode
    {
        get => _product.Sitecode;
    }

    public string MID
    {
        get => _product.MID;
    }

    public string Description
    {
        get => _product.Description;
    }

    public DateTime ExpirationDate
    {
        get => _product.ExpirationDate;
    }

    public string ActivationCode
    {
        get => _product.ActivationCode;
    }

    public bool Requested
    {
        get => _product.Requested;
        set 
        {
            _product.Requested = value;
            OnPropertyChanged();
        }
    }

    public ICommand RenewButton_Command { get; set;}

    public ICommand BackButton_Tapped { get; set; }

    private async void RenewButton_Clicked(object obj)
    {
        var result = await Shell.Current.DisplayActionSheet("Select a duration", "Cancel", null, "1 month", "3 months", "6 months", "12 months");
        if (result == "Cancel") return;
        int duration;
        if (result == "1 month") duration = 1;
        else if (result == "3 months") duration = 3;
        else if (result == "6 months") duration = 6;
        else duration = 12;
        var requestSuccess = await _requestRepo.CreateRequest(Product.Id, duration);
        if (requestSuccess)
        {
            Requested = true;
            IsEnabled = CanExecute;
            await Shell.Current.DisplayAlert("Request Sent", "Your request has been sent", "Ok");
        }
        else
        {
            await Shell.Current.DisplayAlert("Unsuccessful", "There was an error sending your request", "Cancel");
        }
    }
    private bool _isEnabled = false;
    public bool IsEnabled 
    { 
        get => _isEnabled; 
        set
        {
            SetProperty(ref _isEnabled, value);
            OnPropertyChanged();
        }
    }
    public bool CanExecute => (Product.ExpirationDate < DateTime.Now) && !Requested;  
    private async void GoBack()
	{
		await Shell.Current.Navigation.PopAsync();
	}
    public UserProductViewModel(Models.UserProduct sp)
    {
        _product = sp;
        BackButton_Tapped = new Command(GoBack);
        RenewButton_Command = new Command(RenewButton_Clicked);  
        IsEnabled = CanExecute;  
    }
}


