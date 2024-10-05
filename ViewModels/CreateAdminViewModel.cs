using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;

namespace WindowsApp.ViewModels;

public class CreateAdminViewModel
{
    public ICommand BackButton_Tapped { get; set; }

    public List<string> AdminType { get; } = ["Super Admin", "Admin"];

    private async void GoBack()
    {
        await Shell.Current.Navigation.PopAsync();
    }

    public CreateAdminViewModel()
    {
        BackButton_Tapped = new Command(GoBack);
    }

}
