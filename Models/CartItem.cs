using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;


namespace HeThongQuanLy.Models;

public class CartItem : ObservableObject, INotifyPropertyChanged
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

    private string _customer_id;
    public string Customer_id
    {
        get => _customer_id;
        set 
        {
            SetProperty(ref _customer_id, value);
            OnPropertyChanged();
        }
    }

    private int _product_id;
    public int Product_id
    {
        get => _product_id;
        set
        {
            SetProperty(ref _product_id, value);
            OnPropertyChanged();
        }
    }
    
    private Product _product;

    public Product Product
    {
        get => _product;
        set
        {
            SetProperty(ref _product, value);
            OnPropertyChanged();
        }
    }


    private int _duration;

    public int Duration
    {
        get => _duration;
        set
        {
            SetProperty(ref _duration, value);
            OnPropertyChanged();
        }
    }

    private bool _selected = true;

    public bool Selected
    {
        get => _selected;
        set 
        {
            SetProperty(ref _selected, value);
            OnPropertyChanged();
        }
    }
}
