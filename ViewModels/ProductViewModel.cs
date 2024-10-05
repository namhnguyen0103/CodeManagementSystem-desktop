using CommunityToolkit.Mvvm.ComponentModel;
using HeThongQuanLy.Repository;
using System.Windows.Input;

namespace HeThongQuanLy.ViewModels;

public class ProductViewModel : ObservableObject
{
    private readonly ICartItemRepository _cartItemRepo = new Services.CartItemService();
    private readonly Models.Product _product;

    public string ProductName
    {
        get => _product.Product_name;
    }

    public double PricePerMonth
    {
        get => _product.PricePerMonth;
    }

    public string Description
    {
        get => _product.Product_description;
    }

    public ICommand BackButton_Clicked { get; set; }

    public ICommand AddToCartButton_Clicked { get; set; }

    public ICommand BuyNowButton_Clicked { get; set; }

    private async void GoBack()
    {
        await Shell.Current.Navigation.PopAsync();
    }

    private async Task<string?> DisplayPopup()
    {
        return await Shell.Current.DisplayActionSheet("Select a duration", "Cancel", null, "1 month", "3 months", "6 months", "12 months");
    }

    private async void AddToCart()
    {
        string? result = await DisplayPopup();
        if (result == "Cancel") return;
        Models.CartItem newCartItem = new Models.CartItem
            {
                Customer_id = Constant.Current_user,
                Product_id = this._product.Id,
                Selected = true
            };
        if (result == "1 month") newCartItem.Duration = 1;
        else if (result == "3 months") newCartItem.Duration = 3;
        else if (result == "6 months") newCartItem.Duration = 6;
        else if (result == "12 months") newCartItem.Duration = 12;
        var success = await _cartItemRepo.CreateAsync(newCartItem);
        if (success != null) 
        {
            if (GetShoppingCartViewModel.GetCartViewModel != null ) GetShoppingCartViewModel.GetCartViewModel.LoadProducts();
            await Shell.Current.DisplayAlert("Added Successfully", "Your product has been added to cart", "Ok");
        }
        else
            await Shell.Current.DisplayAlert("Error", "There was an error adding to cart", "Cancel");
    }

    private async void Checkout()
    {
        string? result = await DisplayPopup();
        if (result == "Cancel") return;
        Models.CartItem checkoutItem = new Models.CartItem
            {
                Customer_id = Constant.Current_user,
                Product_id = this._product.Id,
                Product = _product,
                Selected = true
            };
        if (result == "1 month") checkoutItem.Duration = 1;
        else if (result == "3 months") checkoutItem.Duration = 3;
        else if (result == "6 months") checkoutItem.Duration = 6;
        else if (result == "12 months") checkoutItem.Duration = 12;
        CheckoutViewModel cvm = new CheckoutViewModel(checkoutItem);
        await Shell.Current.GoToAsync(nameof(Views.CheckoutPage), new Dictionary<string, object> {{"CheckoutItems", cvm}});
    }

    public ProductViewModel(Models.Product sp)
    {
        _product = sp;
        BackButton_Clicked = new Command(GoBack);
        AddToCartButton_Clicked = new Command(AddToCart);
        BuyNowButton_Clicked = new Command(Checkout);
    }
}
