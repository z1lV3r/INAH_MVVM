using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace INAH.Converters
{
    public class IntegerSetVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return Visibility.Collapsed;

            switch (value)
            {
                case int valueInt:
                    return valueInt > 0 ? Visibility.Visible : Visibility.Collapsed;
                case float valueFloat:
                    return valueFloat > 0 ? Visibility.Visible : Visibility.Collapsed;
                case double valueDouble:
                    return valueDouble > 0 ? Visibility.Visible : Visibility.Collapsed;
                case long valueLong:
                    return valueLong > 0 ? Visibility.Visible : Visibility.Collapsed;
                case string stringValue:
                    return double.Parse(stringValue) > 0d ? Visibility.Visible : Visibility.Collapsed;
            }

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
