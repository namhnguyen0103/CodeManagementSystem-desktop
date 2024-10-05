using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using HeThongQuanLy.Repository;
using HeThongQuanLy.Services;
using HeThongQuanLy.Models;

namespace HeThongQuanLy.ViewModels;

public class CheckoutViewModel : ObservableObject, INotifyPropertyChanged
{
    private readonly IUserProductRepository _userProductRepo = new UserProductService();
    private readonly ICartItemRepository _cartItemRepo = new CartItemService();
    private List<Models.CartItem> _selectedItems = new List<Models.CartItem>();
    public List<Models.CartItem> SelectedItems 
    {
        get => _selectedItems;
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

    public ICommand BackButton_Clicked { get; set; }

    public ICommand CheckoutButton_Clicked { get; set; }


    private async void GoBack()
    {
        await Shell.Current.Navigation.PopAsync();
    }

    private async void Checkout_Products()
    {
        IsBusy = true;
        foreach(Models.CartItem item in _selectedItems)
        {
            var result = await _userProductRepo.CreateAsync(item);
            if (result != null)
            {
                await _cartItemRepo.DeleteAsync(item.Id);
            }
        }
        if (GetShoppingCartViewModel.GetCartViewModel != null ) GetShoppingCartViewModel.GetCartViewModel.LoadProducts();
        if (GetUserProductPageViewModel.GetUserProduct != null ) GetUserProductPageViewModel.GetUserProduct.RefreshProducts(); 
        IsBusy = false;
        await Shell.Current.DisplayAlert("Checkout Successfully", "Go to product page to see activation codes", "Ok");
        GoBack();
    }

    public double _orderTotal;

    public double OrderTotal 
    {
        get => _orderTotal;
        set
        {
            SetProperty(ref _orderTotal, value);
            OnPropertyChanged();
        }
    }

    private void CalcTotal()
    {
        var totalCost = 0.0;
        foreach(Models.CartItem item in SelectedItems)
        {
            totalCost += item.Product.PricePerMonth * item.Duration;
        }
        OrderTotal = totalCost;
    }

    public CheckoutViewModel(List<CartItem> selectedItems)
    {
        BackButton_Clicked = new Command(GoBack);
        CheckoutButton_Clicked = new Command(Checkout_Products);
        _selectedItems = selectedItems;
        CalcTotal();
    }

    public CheckoutViewModel(CartItem item)
    {
        BackButton_Clicked = new Command(GoBack);
        CheckoutButton_Clicked = new Command(Checkout_Products);
        _selectedItems.Add(item);
        CalcTotal();
    }

}
