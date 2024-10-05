using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;


namespace HeThongQuanLy.Models;

public class UserProduct : ObservableObject, INotifyPropertyChanged
{    
    private int _id;

    public int Id
    {
        get => _id;
        set 
        {
            SetProperty(ref _id, value);
            RaisePropertyChanged(nameof(ProductName));
        }
    }

    private int _product_id;

    public int Product_id
    {
        get => _product_id;
        set 
        {
            SetProperty(ref _product_id, value);
            RaisePropertyChanged(nameof(ProductName));
        }
    }

    private Product _product;
    public Product Product
    {
        get => _product;
        set
        {
            SetProperty(ref _product, value);
            RaisePropertyChanged(nameof(Product));
        }
    }

    public string ProductName 
    {
        get 
        {
            if (_product != null) return _product.Product_name;
            return string.Empty;
        }
    }
    private string _sitecode;

    public string Sitecode 
    {
        get => _sitecode;
        set 
        {
            SetProperty(ref _sitecode, value);
            RaisePropertyChanged(nameof(Sitecode));
        }
    }

    private string _MID;

    public string MID 
    {
        get => _MID;
        set
        {
            SetProperty(ref _MID, value);
            RaisePropertyChanged(nameof(MID));
        }
    }

    private DateTime _expirationDate;

    public DateTime ExpirationDate 
    {
        get => _expirationDate;
        set 
        {
            SetProperty(ref _expirationDate, value);
            RaisePropertyChanged(nameof(ExpirationDate));
        }
    }

    private string _activationCode;

    public string ActivationCode 
    {
        get => _activationCode;
        set
        {
            SetProperty(ref _activationCode, value);
            RaisePropertyChanged(nameof(ActivationCode));
        }
    }
    public string Description 
    {
        get 
        {
            if (_product != null) return _product.Product_description;
            return string.Empty;
        }

    }

    private bool _requested = false;

    public bool Requested 
    {
        get => _requested;
        set 
        {
            SetProperty(ref _requested, value);
            RaisePropertyChanged(nameof(Requested));
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
		
    private void RaisePropertyChanged(string property) {
        if (PropertyChanged != null) {
        PropertyChanged(this, new PropertyChangedEventArgs(property));
        } 
    } 
}
