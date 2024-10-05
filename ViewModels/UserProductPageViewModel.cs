using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using HeThongQuanLy.Repository;


namespace HeThongQuanLy.ViewModels;

public class UserProductPageViewModel : ObservableObject, INotifyPropertyChanged
{
    readonly IUserProductRepository _userProductRepo = new Services.UserProductService();
    readonly IProductRepository _productRepo = new Services.ProductService();

    private List<Models.UserProduct> _softwareProducts = [];

    public List<Models.UserProduct> SoftwareProducts { 
        get => _softwareProducts; 
        set
        {
            SetProperty(ref _softwareProducts, value);
            OnPropertyChanged();
        } 
    }

    private bool _isBusy = true;

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
    private bool _isEmpty = false;

    public bool IsEmpty
    {
        get => _isEmpty;
        set
        {
            _isEmpty = value;
            OnPropertyChanged();
        }
    }
  
    public UserProductPageViewModel()
    {
        Item_Select = new Command<Models.UserProduct>(ListView_ItemTapped);
        PullToRefresh = new Command(RefreshList);
        GetUserProductPageViewModel.GetUserProduct = this;
        Task.Run(async () => {
            IsBusy = await RefreshProducts();
        });
    }

    public string Heading => "Your Products";

    public string Searchbar_Placeholder => "Search your product";

    public ICommand Item_Select { get; set; }

    public ICommand PullToRefresh { get; set; }

    private async void ListView_ItemTapped(Models.UserProduct userProduct)
	{
        UserProductViewModel uvm = new UserProductViewModel(userProduct);
		await Shell.Current.GoToAsync(nameof(Views.UserProductDetailPage), new Dictionary<string, object> {{"Product", uvm}});
	}

    private async void RefreshList()
    {
        IsRefreshing = true;
        IsRefreshing = await RefreshProducts();
    }

    public async Task<bool> RefreshProducts()
    {
        List<Models.UserProduct> data = await _userProductRepo.GetByUserIdAsync(Constant.Current_user);
        data = data.OrderBy(productData => productData.ExpirationDate).ToList();
        SoftwareProducts.Clear();
        if (data != null){
            if (data.Count == 0) IsEmpty = true;
            else IsEmpty = false;

            foreach(Models.UserProduct product in data)
            {
                product.Product = await _productRepo.GetByIdAsync(product.Product_id);
            }
            SoftwareProducts = data;
        }
        return false;

    } 
}

public class GetUserProductPageViewModel
{
    public static UserProductPageViewModel? GetUserProduct { get; set; }
}
