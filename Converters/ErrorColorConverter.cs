using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace INAH.Converters
{
    class ErrorColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Brush brush;
            var converter = new System.Windows.Media.BrushConverter();
            if (string.IsNullOrEmpty(value as string))
            {
                brush = (Brush)converter.ConvertFromString("#FFABADB3");
            }
            else
            {
                brush = (Brush)converter.ConvertFromString("#FFE00000");
            }
            return brush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
