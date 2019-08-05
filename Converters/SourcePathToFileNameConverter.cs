using System;
using System.Globalization;
using System.Windows.Data;
using System;
using System.IO;
using System.Text;

namespace INAH.Converters
{
    class SourcePathToFileNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null && !string.IsNullOrEmpty(value as string) ? Path.GetFileName(value as string) : null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
