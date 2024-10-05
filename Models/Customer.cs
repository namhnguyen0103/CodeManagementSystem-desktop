using System.Collections.ObjectModel;
namespace WindowsApp.Models;

// public record Customer(
//     string Name,
//     string AccountID,
//     string Email,
//     List<Product> CustomerProducts
// );

public class Customer
{
    public string Id { get; set; } = string.Empty;

    public string Account_name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public DateTime Date_of_birth { get; set; }

    public List<UserProduct> CustomerProducts { get; set; } = [];
}
