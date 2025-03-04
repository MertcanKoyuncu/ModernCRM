using System;
using System.Globalization;
using System.Windows.Data;

namespace ModernCRM.Converters
{
    public class BoolToActiveConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isActive)
            {
                return isActive ? "Aktif" : "Pasif";
            }
            return "Bilinmiyor";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string text)
            {
                return text.Equals("Aktif", StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }
    }
} 