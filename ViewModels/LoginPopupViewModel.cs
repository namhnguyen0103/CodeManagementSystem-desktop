using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;

namespace HeThongQuanLy.ViewModels;

public class LoginPopupViewModel : INotifyPropertyChanged
{
    
    
    public event PropertyChangedEventHandler PropertyChanged;
		
    private void RaisePropertyChanged(string property) {
        if (PropertyChanged != null) {
        PropertyChanged(this, new PropertyChangedEventArgs(property));
        } 
    } 
}
