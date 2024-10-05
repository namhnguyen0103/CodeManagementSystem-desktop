using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using HeThongQuanLy.Views;
using HeThongQuanLy.Repository;


namespace HeThongQuanLy.ViewModels;

public class HomePageViewModel : ObservableObject, INotifyPropertyChanged
{
    readonly IProductRepository _productRepo = new Services.ProductService();
    readonly ICartItemRepository _cartItemRepo = new Services.CartItemService();
    
    public ObservableCollection<Models.Product> SoftwareProducts { get; set; } = [];

    private bool _isBusy;

    public bool IsBusy 
    {
        get => _isBusy;
        set
        {
            _isBusy = value;
            OnPropertyChanged();
        }
    }

    private bool _isRefreshing;

    public bool IsRefreshing 
    {
        get => _isRefreshing;
        set
        {
            _isRefreshing = value;
            OnPropertyChanged();
        }
    }

    public string Heading => "Software Products";

    public string Searchbar_Placeholder => "Search a product";

    public ICommand Item_Select { get; set; }
    public ICommand Refresh_List { get; set; }
    public ICommand AddToCartButton_Clicked { get; set; }

    public HomePageViewModel()
    {
        
        Item_Select = new Command<Models.Product>(ListView_ItemTapped);
        AddToCartButton_Clicked = new Command<Models.Product>(AddToCart);
        GetHomePageViewModel.GetHomePage = this;
        LoadProducts();
    }
    
    private async void ListView_ItemTapped(Models.Product softwareProduct)
	{
        ProductViewModel pvm = new ProductViewModel(softwareProduct);
		await Shell.Current.GoToAsync(nameof(Views.ProductDetailPage), new Dictionary<string, object> {{"Product", pvm}});
	}

    public async void LoadProducts()
    {
        IsBusy = true;
        // await Task.Delay(1000);
        List<Models.Product> productData = await _productRepo.GetAllAsync();
        SoftwareProducts.Clear();
        foreach(Models.Product product in productData)
        {
            SoftwareProducts.Add(product);
        }
        IsBusy = false;
    }

    private async Task<string?> DisplayPopup()
    {
        return await Shell.Current.DisplayActionSheet("Select a duration", "Cancel", null, "1 month", "3 months", "6 months", "12 months");
    }

    private async void AddToCart(Models.Product product)
    {
        string? result = await DisplayPopup();
        if (result == "Cancel") return;
        Models.CartItem newCartItem = new Models.CartItem
            {
                Customer_id = Constant.Current_user,
                Product_id = product.Id,
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
}

public class GetHomePageViewModel
{
    public static HomePageViewModel? GetHomePage { get; set; }
}