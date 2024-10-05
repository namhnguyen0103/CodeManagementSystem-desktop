using System.Globalization;

namespace WindowsApp.Converters;

public class CustomerProducts : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        var toReturn = (List<Models.UserProduct>)value;
        return toReturn.Count;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
