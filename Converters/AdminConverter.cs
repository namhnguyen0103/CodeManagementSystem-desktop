using System.Globalization;

namespace WindowsApp.Converters;

public class TypeAdminConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if ((bool)value) return "Super Admin";
        else return "Admin";
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
