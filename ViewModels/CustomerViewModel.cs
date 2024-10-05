using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using WindowsApp.Repository;
using WindowsApp.Services;

namespace WindowsApp.ViewModels;

public class CustomerViewModel : ObservableObject
{
    private readonly IProductRepository _productRepo = new ProductService();
    private string _name;

    private string _email;

    private string _accountID;

    private bool _isBusy;

    public bool IsBusy {
        get => _isBusy;
        set 
        {
            SetProperty(ref _isBusy, value);
            OnPropertyChanged();
        }
    }

    private List<Models.UserProduct> _customerProducts;
    public ObservableCollection<Models.UserProduct> ProductList { get; set; } = [];

    public string Name 
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    public string Email 
    {
        get => _email;
        set => SetProperty(ref _email, value);
    }

    public string AccountID 
    {
        get => _accountID;
        set => SetProperty(ref _accountID, value);
    }

    public List<Models.UserProduct> CustomerProducts 
    {
        get => _customerProducts;
        set 
        {
            SetProperty(ref _customerProducts, value);
            OnPropertyChanged();
        }
    }

    public int NoOfProd
    {
        get => CustomerProducts.Count;
    }

    public ICommand Item_Select { get; set; }

    public ICommand BackButton_Tapped { get; set; }

    public async Task<bool> RefreshList()
    { 
        IsBusy = true;
        ProductList.Clear();
        foreach(Models.UserProduct product in CustomerProducts.OrderBy(prod => prod.ExpirationDate))
        {
            product.Product = await _productRepo.GetByIdAsync(product.Product_id);
            ProductList.Add(product);
        }
        IsBusy = false;
        return false;
    }

    private async void ListView_ItemTapped(Models.UserProduct product)
    {
        ProductViewModel pvm = new ProductViewModel(product);
        Views.ProductPage newPage = new Views.ProductPage();
        await Shell.Current.Navigation.PushAsync(newPage);
        newPage.Product = pvm;
    }

    private async void GoBack()
    {
        await Shell.Current.Navigation.PopAsync();
    }
    
    public CustomerViewModel(Models.Customer customer)
    {
        _name = customer.Account_name;
        _accountID = customer.Id;
        _email = customer.Email;
        CustomerProducts = customer.CustomerProducts;
        Item_Select = new Command<Models.UserProduct>(ListView_ItemTapped);
        BackButton_Tapped = new Command(GoBack);
    }
}
