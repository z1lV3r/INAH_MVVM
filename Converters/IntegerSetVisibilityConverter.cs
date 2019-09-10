using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace INAH.Converters
{
    public class IntegerSetVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                switch (value)
                {
                    case int valueInt:
                        return valueInt > 0;
                    case float valueFloat:
                        return valueFloat > 0;
                    case double valueDouble:
                        return valueDouble > 0;
                    case long valueLong:
                        return valueLong > 0;
                }
            }

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
