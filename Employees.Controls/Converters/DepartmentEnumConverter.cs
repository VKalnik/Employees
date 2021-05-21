using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using Employees.Controls.Extensions;

namespace Employees.Controls.Converters
{
    public class DepartmentEnumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => 
            !(value is Enum enumValue) ? DependencyProperty.UnsetValue : enumValue.GetDescriptionFromEnumValue();

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => value;
    }
}