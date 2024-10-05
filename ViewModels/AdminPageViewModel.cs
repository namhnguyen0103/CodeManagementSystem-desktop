using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;
using WindowsApp.Repository;
using WindowsApp.Services;

namespace WindowsApp.ViewModels;

public class AdminPageViewModel : ObservableObject
{
    private readonly IAccountRepository _accountRepo = new AccountService();
    public AdminPageViewModel()
    {
        NewAdmin_Clicked = new Command(Create_Account);
        Item_Select = new Command<Models.Admin>(ListView_ItemTapped);
        RefreshList();
    }
    
    public ObservableCollection<Models.Admin> AdminList { get; set; } = [];

    public ICommand NewAdmin_Clicked { get; set; }

    public ICommand Item_Select { get; set; }

    private async void Create_Account()
    {
        await Shell.Current.Navigation.PushAsync(new Views.CreateAdminPage());
    }
    
    private bool _isBusy;

    public bool IsBusy
    {
        get => _isBusy;
        set => SetProperty(ref _isBusy, value);
    }

    public async void RefreshList()
    {
        IsBusy = true;
        IEnumerable<Models.Admin> adminData = await _accountRepo.GetAdminsAsync();
        AdminList.Clear();

        foreach(Models.Admin admin in adminData) 
        {
            AdminList.Add(admin);
        }
        IsBusy = false;
    }

    private async void ListView_ItemTapped(Models.Admin admin)
    {
        AdminViewModel avm = new AdminViewModel(admin);
        Views.AdminDetail newPage = new Views.AdminDetail();
        await Shell.Current.Navigation.PushAsync(newPage);
        newPage.Admin = avm;
    }

}
