using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace WindowsApp.Models;

public class Request : ObservableObject, INotifyPropertyChanged
{
    public int Id { get; set; }
    public int Product_id { get; set; }
    public string Product_name { get; set; } = string.Empty;
    public string Customer_id { get; set; } = string.Empty;
    public string Customer_name { get; set; } = string.Empty;
    public string OldActivationCode { get; set; } = string.Empty;
    public DateTime? OldExpirationDate { get; set; }
    public DateTime? NewExpirationDate { get; set; }
    public int Duration { get; set; }
    public bool? IsApproved { get; set; }
    public string? ApprovedBy { get; set; } = string.Empty;
    public DateTime? Created_at { get; set; }
}


