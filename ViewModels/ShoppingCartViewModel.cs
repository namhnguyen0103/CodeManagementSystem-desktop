using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using HeThongQuanLy.Repository;
using HeThongQuanLy.Models;

namespace HeThongQuanLy.ViewModels;

public class ShoppingCartViewModel : ObservableObject, INotifyPropertyChanged
{
    private readonly ICartItemRepository _cartItemRepo = new Services.CartItemService();
    private readonly IProductRepository _productRepo = new Services.ProductService();

    private ShoppingCart _cart = ShoppingCartData.GetCart;

    public ShoppingCart Cart 
    {
        get => _cart;
    }

    public List<CartItem> Products 
    { 
        get => _cart.GetCart(); 
    }

    private bool _isBusy;

    public bool IsBusy
    {
        get => _isBusy;
        set
        {
            SetProperty(ref _isBusy, value);
            OnPropertyChanged();
        }
    }

    private bool _isRefreshing = false;

    public bool IsRefreshing
    {
        get => _isRefreshing;
        set
        {
            SetProperty(ref _isRefreshing, value);
            OnPropertyChanged();
        }
    }

    private bool _isEmpty = false;

    public bool IsEmpty
    {
        get => _isEmpty;
        set
        {
            SetProperty(ref _isEmpty, value);
            OnPropertyChanged();
        }

    }

    public double OrderTotal => _cart.OrderTotal;

    public int NumSelected 
    {
        get => _cart.NumSelected;
    }

    public ICommand CheckBox_Tapped { get; set; }

    public ICommand Trashbin_Tapped { get; set; }

    public ICommand Checkout_Tapped { get; set; }

    public ICommand PullToRefresh { get; set; }

    private async void CheckBox_Changed(CartItem item)
    {
        IsBusy = true;
        item.Selected = !item.Selected;
        var result = await _cartItemRepo.UpdateAsync(item);
        IsBusy = await LoadProducts();
    }

    private async void Delete_Item(CartItem item)
    {
        IsBusy = true;
        await _cartItemRepo.DeleteAsync(item.Id);
        IsBusy = await LoadProducts();
    }

    private async void Checkout_Execute()
    {
        List<CartItem> selectedItems = new List<CartItem>();
        foreach(CartItem item in _cart.GetCart())
        {
            selectedItems.Add(item);
        }
        CheckoutViewModel cvm = new CheckoutViewModel(selectedItems);
        await Shell.Current.GoToAsync(nameof(Views.CheckoutPage), new Dictionary<string, object> {{"CheckoutItems", cvm}});
    }

    private bool Checkout_CanExecute()
    {
        return Cart.NumSelected == 0;
    }
    
    public ShoppingCartViewModel()
    {
        CheckBox_Tapped = new Command<CartItem>(CheckBox_Changed);
        Trashbin_Tapped = new Command<CartItem>(Delete_Item);
        Checkout_Tapped = new Command(execute: Checkout_Execute, canExecute: Checkout_CanExecute);
        PullToRefresh = new Command(RefreshList);
        GetShoppingCartViewModel.GetCartViewModel = this;
        IsBusy = true;
        Task.Run(async () => {
            IsBusy = await LoadProducts();
        });
    }

    private async void RefreshList()
    {
        IsRefreshing = true;
        OnPropertyChanged(nameof(Products));
        IsRefreshing = await LoadProducts();
    }

    
    public async Task<bool> LoadProducts()
    {
        List<CartItem> items = await _cartItemRepo.GetByUserIdAsync(Constant.Current_user);
        foreach(CartItem ci in items)
        {
            ci.Product = await _productRepo.GetByIdAsync(ci.Product_id);
        }
        if (items.Count == 0) IsEmpty = true;
        else IsEmpty = false;
        await _cart.LoadShoppingCart(items);
        OnPropertyChanged(nameof(Products));
        return false;
    }

}

public class GetShoppingCartViewModel
{
    public static ShoppingCartViewModel? GetCartViewModel { get; set; }
}
