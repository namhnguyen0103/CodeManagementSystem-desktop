using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace HeThongQuanLy.Models;

public class ShoppingCart : ObservableObject, INotifyPropertyChanged
{

    public ShoppingCart()
    {
    }


    
    private List<CartItem> _cart = [];

    private List<CartItem> Cart {
        get => _cart;
        set 
        {
            SetProperty(ref _cart, value);
            OnPropertyChanged();
        }
    }

    public double _orderTotal;

    public double OrderTotal 
    {
        get => _orderTotal;
        set
        {
            SetProperty(ref _orderTotal, value);
            OnPropertyChanged(nameof(OrderTotal));
        }
    }

    private int _numSelected;

    public int NumSelected
    {
        get => _numSelected;
        set
        {
            SetProperty(ref _numSelected, value);
            OnPropertyChanged(nameof(NumSelected));
        }
    }    
    
    public List<CartItem> GetCart()
    {
        return Cart;
    }

    public double GetOrderTotal()
    {
        return OrderTotal;
    }
    
    public async Task LoadShoppingCart(List<CartItem> items)
    {
        var totalCost = 0.0;
        var totalItem = 0;
        // IEnumerable<CartItem> productData = await SoftwareProductDatabase.GetShoppingCart();
        Cart.Clear();
        // foreach(CartItem sci in items)
        // {
        //     Cart.Add(sci);
        //     if (sci.Selected)
        //     {
        //         totalCost += sci.Product.PricePerMonth * sci.Duration;
        //         totalItem++;
        //     }
        // }
        Cart = items;
        // OrderTotal = totalCost;
        // NumSelected = totalItem;
        CalcTotal();
    }

    public void CalcTotal()
    {
        var totalCost = 0.0;
        var totalItem = 0;
        foreach(Models.CartItem item in Cart)
        {
            if (item.Selected) 
            {
                totalCost += item.Product.PricePerMonth * item.Duration;
                totalItem++;
            }

        }
        OrderTotal = totalCost;
        NumSelected = totalItem;
    }

}

public class ShoppingCartData
{
    public static ShoppingCart GetCart { get; } = new ShoppingCart();
}
