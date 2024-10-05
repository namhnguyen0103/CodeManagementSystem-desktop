using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace HeThongQuanLy.Models;

public class Product : ObservableObject, INotifyPropertyChanged 
{
    private int _id;


    public int Id
    {
        get => _id;
        set
        {
            SetProperty(ref _id, value);
            OnPropertyChanged();
        }
    }

    private string _product_name = string.Empty;

    public string Product_name
    {
        get => _product_name;
        set
        {
            SetProperty(ref _product_name, value);
            OnPropertyChanged();
        }
    }

    private string _description = string.Empty;

    public string Product_description
    {
        get => _description;
        set
        {
            SetProperty(ref _description, value);
            RaisePropertyChanged(nameof(Product_description));
        }
    }

    private double _pricePerMonth;

    public double PricePerMonth
    {
        get => _pricePerMonth;
        set
        {
            SetProperty(ref _pricePerMonth, value);
            RaisePropertyChanged(nameof(PricePerMonth));
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
		
    private void RaisePropertyChanged(string property) {
        if (PropertyChanged != null) {
        PropertyChanged(this, new PropertyChangedEventArgs(property));
        } 
    } 
}