using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;
using WindowsApp.Repository;
using WindowsApp.Services;

namespace WindowsApp.ViewModels;

public class RequestViewModel : ObservableObject
{
    private IRequestRepository _requestRepo = new RequestService();
    private int _requestID;

    private string _customerName;

    private string _accountID;

    private string _productName;

    private string _oldActivationCode;

    private DateTime? _requestedDate;

    private DateTime? _oldExpirationDate;

    private DateTime? _newExpirationDate;

    public int RequestID 
    {
        get => _requestID;
        set => SetProperty(ref _requestID, value);
    }

    public string CustomerName 
    {
        get => _customerName;
        set => SetProperty(ref _customerName, value);
    }

    public string AccountID 
    {
        get => _accountID;
        set => SetProperty(ref _accountID, value);
    }
    
    public string ProductName 
    {
        get => _productName;
        set => SetProperty(ref _productName, value);
    }

    public string OldActivationCode 
    {
        get => _oldActivationCode;
        set => SetProperty(ref _oldActivationCode, value);
    }

    public DateTime? RequestedDate
    {
        get => _requestedDate;
        set => SetProperty(ref _requestedDate, value);
    }

    public DateTime? OldExpirationDate 
    {
        get => _oldExpirationDate;
        set => SetProperty(ref _oldExpirationDate, value);
    }

    public DateTime? NewExpirationDate 
    {
        get => _newExpirationDate;
        set => SetProperty(ref _newExpirationDate, value);
    }

    public ICommand BackButton_Tapped { get; set; }
    public ICommand ApproveButton_Tapped { get; set; }
    public ICommand RejectButton_Tapped { get; set; }

    private async void GoBack()
    {
        GetRequestPageViewModel.Refresh();
        await Shell.Current.Navigation.PopAsync();
    }

    private async void ApproveRequest_Command()
    {
        var result = await _requestRepo.UpdateAsync(_requestID, true);
        if (result)
        {
            await Shell.Current.DisplayAlert("Approved Successfully", "This request has been approved", "Ok");
            GoBack();
        }
        else 
        {
            await Shell.Current.DisplayAlert("Unsuccessful", "There was an error approving this request", "Cancel");
        }
    }

    private async void RejectRequest_Command()
    {
        var result = await _requestRepo.UpdateAsync(_requestID, false);
        if (result)
        {
            await Shell.Current.DisplayAlert("Rejected Successfully", "This request has been rejected", "Ok");
            GoBack();
        }
        else 
        {
            await Shell.Current.DisplayAlert("Unsuccessful", "There was an error rejecting this request", "Cancel");
        }
    }


    public RequestViewModel(Models.Request request)
    {
        _requestID = request.Id;
        _customerName = request.Customer_name;
        _accountID = request.Customer_id;
        _productName = request.Product_name;
        _oldActivationCode = request.OldActivationCode;
        _requestedDate = request.Created_at;
        _oldExpirationDate = request.OldExpirationDate;
        _newExpirationDate = request.NewExpirationDate;
        BackButton_Tapped = new Command(GoBack);
        ApproveButton_Tapped = new Command(ApproveRequest_Command);
        RejectButton_Tapped = new Command(RejectRequest_Command);
    }

}
