using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace ModernCRM.Converters
{
    public class NameToInitialsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || !(value is string name) || string.IsNullOrWhiteSpace(name))
            {
                return "??";
            }

            // İsmi boşluklara göre ayır
            var parts = name.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            
            // Sadece 1 kelime varsa, ilk harfi al
            if (parts.Length == 1)
            {
                return parts[0].Substring(0, 1).ToUpper();
            }
            
            // Birden fazla kelime varsa, ilk iki kelimenin baş harflerini al
            return string.Join("", parts.Take(2).Select(p => p.Substring(0, 1).ToUpper()));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
} 