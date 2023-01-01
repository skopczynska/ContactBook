using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace ContactBook.App.Helpers
{
    public class BooleanToVisibleNotVivilbeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && value is bool && ((Boolean) value) == true)
                return Visibility.Visible;
            return Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && ((Visibility)value) == Visibility.Visible)
                return true;

            return false;
        }
    }
}
