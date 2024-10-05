using System.Globalization;

namespace HeThongQuanLy.Converters;

public class DateToStatusConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        var currentDate = DateTime.Now;
        if ((DateTime)value < currentDate) return "Expired";
        else if (currentDate.AddDays(14) > (DateTime)value) return "Expires soon";
        else return "Active";   
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

public class DateToColorConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        var currentDate = DateTime.Now;
        if ((DateTime)value < currentDate) return Color.FromRgb(235, 83, 83);
        else if (currentDate.AddDays(14) > (DateTime)value) return Color.FromRgb(255,179,71);
        else return Color.FromRgb(54,174,124);   
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

public class DateToBoolConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        var currentDate = DateTime.Now;
        if ((DateTime)value < currentDate) return true;
        else return false;  
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
