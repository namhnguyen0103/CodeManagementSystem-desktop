using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WindowsApp.Repository;
using WindowsApp.Services;

namespace WindowsApp.ViewModels;

public class RequestPageViewModel : ObservableObject
{
    private readonly IRequestRepository _requestRepo = new RequestService();
    public ObservableCollection<Models.Request> RequestList { get; set; } = [];

    private bool _isBusy = true;

    public bool IsBusy 
    {
        get => _isBusy;
        set
        {
            SetProperty(ref _isBusy, value);
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

    public RequestPageViewModel()
    {
        Item_Select = new Command<Models.Request>(ListView_ItemTapped);
        RefreshList_Command = new Command(RefreshList);
        RefreshList();
    }

    public ICommand Item_Select { get; set; }
    public ICommand RefreshList_Command { get; set; }

    private async void ListView_ItemTapped(Models.Request request)
    {
        Views.RequestDetail newPage = new Views.RequestDetail();
        await Shell.Current.Navigation.PushAsync(newPage);
        RequestViewModel rvm = new RequestViewModel(request);
        newPage.Request = rvm;
        GetRequestPageViewModel.RequestPage = this;
    }

    public async void RefreshList()
    {
        IsBusy = true;
        List<Models.Request> requestData = await _requestRepo.GetAllAwaitingAsync();
        RequestList.Clear();
        foreach(Models.Request request in requestData)
        {
            RequestList.Add(request);
        }
        if (RequestList.Count == 0) IsEmpty = true;
        else IsEmpty = false;
        IsBusy = false;
    }

}

public static class GetRequestPageViewModel
{
    public static RequestPageViewModel? RequestPage { get; set; }

    public static void Refresh()
    {
        if (RequestPage != null) RequestPage.RefreshList();
    }
}
