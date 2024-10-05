using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.ComponentModel;
using WindowsApp.Repository;
using WindowsApp.Services;

namespace WindowsApp.ViewModels;

public class SearchPageViewModel : ObservableObject, INotifyPropertyChanged
{
    private readonly IAccountRepository _accountRepo = new AccountService();
    private readonly IProductRepository _productRepo = new ProductService();
    private readonly IUserProductRepository _userProductRepo = new UserProductService();

    public ObservableCollection<Models.Customer> CustomerList { get; set; } = [];

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
    public SearchPageViewModel()
    {
        Item_Select = new Command<Models.Customer>(ListView_ItemTapped);
        RefreshList_Command = new Command(RefreshList);
        //Task.Run(async () => {IsBusy = await RefreshList();});
        RefreshList();
    }

    public ICommand Item_Select { get; set; }
    public ICommand RefreshList_Command { get; set; }

    private async void ListView_ItemTapped(Models.Customer customer)
    {
        IsBusy = true;
        CustomerViewModel cvm = new CustomerViewModel(customer);
        Views.CustomerPage newPage = new Views.CustomerPage();
        IsBusy = await cvm.RefreshList();
        newPage.Customer = cvm;
        await Shell.Current.Navigation.PushAsync(newPage);
    }

    // public async void Refresh()
    // {
    //     IsBusy = true;
    //     IsBusy = await RefreshList();
    // }

    public async void RefreshList()
    {
        IsBusy = true;
        List<Models.Customer> customerData = await _accountRepo.GetCustomersAsync();
        CustomerList.Clear();
        foreach(Models.Customer customer in customerData) 
        {
            customer.CustomerProducts = await _userProductRepo.GetByUserIdAsync(customer.Id);
            CustomerList.Add(customer);
        }
        if (CustomerList.Count == 0) IsEmpty = true;
        else IsEmpty = false;
        IsBusy = false;
    }
}

