using Employees.Data;
using System;
using System.Globalization;
using System.Reflection;
using System.Windows.Data;

namespace Employees.Controls.Converters
{
    public class DepartmentNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && value is Department)
            {
                switch (value)
                {
                    case Department.General:
                        value = "Основной";
                        break;
                    case Department.Industrial:
                        value = "Производственный";
                        break;
                    case Department.Personal:
                        value = "Персонала";
                        break;
                    case Department.Financial:
                        value = "Финансов";
                        break;
                    default:
                        value = "Ошибка!";
                        break;
                }
            }
            else
            {
                value = "Ошибка!";
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
