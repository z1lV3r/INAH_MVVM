using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace INAH.Converters
{
    class ItemDetailMeasureVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null && float.Parse((string)value) != 0.0f ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
