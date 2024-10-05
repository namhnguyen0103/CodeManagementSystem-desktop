using AuthenticationServices;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace HeThongQuanLy.Models;

internal static class SoftwareProductDatabase
{
    
    public async static Task<IEnumerable<Product>> GetProducts()
    {
        string sampleDescription = "Companies create application suites, which are composed of a few different but related applications. An application suite can have similar interfaces, making it easier for you to navigate between the applications when you're completing tasks.";
        await Task.Delay(1000);
        return [
            // new Product{Product_name = "Product A", Description = sampleDescription, PricePerMonth = 100.00},
            // new Product{Product_name = "Product B", Description = sampleDescription, PricePerMonth = 50.00},
            // new Product{Product_name = "Product C", Description = sampleDescription, PricePerMonth = 25.00},
            // new Product{Product_name = "Product D", Description = sampleDescription, PricePerMonth = 25.00},
            // new Product{Product_name = "Product E", Description = sampleDescription, PricePerMonth = 25.00},
            // new Product{Product_name = "Product F", Description = sampleDescription, PricePerMonth = 25.00},
            // new Product{Product_name = "Product G", Description = sampleDescription, PricePerMonth = 25.00}
        ];
    }

    public async static Task<IEnumerable<UserProduct>> GetUserProducts()
    {
        string sampleDescription = "Companies create application suites, which are composed of a few different but related applications. An application suite can have similar interfaces, making it easier for you to navigate between the applications when you're completing tasks.";
        await Task.Delay(1000);

        return [
            // new UserProduct{ProductName = "Product A", Sitecode = "00000000", MID = "01010101", ExpirationDate = DateTime.Parse("05/30/2023"), ActivationCode = "12345678", Description = sampleDescription},
            // new UserProduct{ProductName = "Product B", Sitecode = "00000000", MID = "01010101", ExpirationDate = DateTime.Parse("07/15/2024"), ActivationCode = "12345678", Description = sampleDescription},
            // new UserProduct{ProductName = "Product C", Sitecode = "00000000", MID = "01010101", ExpirationDate = DateTime.Parse("12/31/2026"), ActivationCode = "12345678", Description = sampleDescription},
            // new UserProduct{ProductName = "Product D", Sitecode = "00000000", MID = "01010101", ExpirationDate = DateTime.Parse("12/30/2022"), ActivationCode = "12345678", Description = sampleDescription},
            // new UserProduct{ProductName = "Product E", Sitecode = "00000000", MID = "01010101", ExpirationDate = DateTime.Parse("06/30/2026"), ActivationCode = "12345678", Description = sampleDescription},
            // new UserProduct{ProductName = "Product F", Sitecode = "00000000", MID = "01010101", ExpirationDate = DateTime.Parse("06/30/2026"), ActivationCode = "12345678", Description = sampleDescription},
            // new UserProduct{ProductName = "Product G", Sitecode = "00000000", MID = "01010101", ExpirationDate = DateTime.Parse("06/30/2026"), ActivationCode = "12345678", Description = sampleDescription}
        ];
    }

    public async static Task<IEnumerable<CartItem>> GetShoppingCart()
    {
        IEnumerable<Product> products = await GetProducts();
        List<CartItem> toReturn = new List<CartItem>();
        foreach(Product sp in products)
        {
            toReturn.Add(new CartItem{Product = sp, Duration = 3});
        }
        return toReturn;
    }

}
