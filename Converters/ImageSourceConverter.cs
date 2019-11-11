using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace INAH.Converters
{
    public class ImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ("/Resources/Images/notFound.png".Equals(value))
                value = "pack://application:,,,/Resources/Images/notFound.png";
            var path = (string)(value != null && !string.IsNullOrEmpty(value as string) ? value : "pack://application:,,,/Resources/Images/notFound.png");
            var img = new BitmapImage { CacheOption = BitmapCacheOption.OnLoad };
            img.BeginInit();
            img.CacheOption = BitmapCacheOption.OnLoad;
            img.UriSource = new Uri(path);
            img.EndInit();

            return img;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}