using System;
using System.Globalization;
using System.Windows.Data;

namespace Employees.Controls.Converters
{
    public class LockedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null && value is bool && (bool)value == true ? "Блокирован" : "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
