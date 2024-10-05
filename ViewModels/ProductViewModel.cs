using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace WindowsApp.ViewModels;

public class ProductViewModel : ObservableObject
{
    private string _productName;

    private string _MID;

    private string _sitecode;

    private DateTime _expirationDate;

    private string _activationCode;

    private string _description;

    private double _price;

    private Models.Request _request;
    

    public DateTime currentDate = DateTime.Now;

    public string ProductName 
    {
        get => _productName;
        set => SetProperty(ref _productName, value);
    }

    public string Sitecode
    {
        get => _sitecode;
        set => SetProperty(ref _sitecode, value);
    }

    public string MID 
    {
        get => _MID;
        set => SetProperty(ref _MID, value);
    }

    public DateTime ExpirationDate 
    {
        get => _expirationDate;
        set => SetProperty(ref _expirationDate, value);
    }

    public string ActivationCode 
    {
        get => _activationCode;
        set => SetProperty(ref _activationCode, value);
    }

    public string Description 
    {
        get => _description;
        set => SetProperty(ref _description, value);
    }

    public double Price 
    {
        get => _price;
        set => SetProperty(ref _price, value);
    }

    public Models.Request Request
    {
        get => _request;
        set => SetProperty(ref _request, value);
    }

    public ICommand BackButton_Tapped { get; set; }

    public ICommand RenewButton_Tapped { get; set;}
    private async void RenewActivationCode(object obj)
    {
        RequestViewModel rvm = new RequestViewModel(Request);
        Views.CustomerRenewPage newPage = new Views.CustomerRenewPage();
        await Shell.Current.Navigation.PushAsync(newPage);
        newPage.Request = rvm;
    }

    private bool RenewButton_CanExecute(object obj)
    {
        return this.Request != null;
    }

    private async void GoBack()
    {
        await Shell.Current.Navigation.PopAsync();
    }


    public ProductViewModel(Models.UserProduct sp)
    {
        _productName = sp.Product.Product_name;
        _sitecode = sp.Sitecode;
        _MID = sp.MID;
        _expirationDate = sp.ExpirationDate;
        _activationCode = sp.ActivationCode;
        _description = sp.Description;
        _price = sp.Product.PricePerMonth;
        // _request = sp.Request;
        BackButton_Tapped = new Command(GoBack);
        RenewButton_Tapped = new Command(execute: RenewActivationCode, canExecute: RenewButton_CanExecute);
    }
}
