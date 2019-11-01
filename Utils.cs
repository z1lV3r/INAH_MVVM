using System;
using System.IO;
using System.Linq;
using System.Windows;
using INAH.ViewModels.Abstracts;

namespace INAH
{
    public class Utils
    {
        public static Window GetWindowFromViewModelId(Guid id)
        {

            foreach (Window item in Application.Current.Windows)
            {
                if (item.DataContext is BaseWindowViewModel vm && vm.ViewId == id) return item;
            }

            return new Window();
        }

        public static string GetImageSource(int stockNumber)
        {
            var files = Directory.GetFiles(
                    Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Images"),
                    stockNumber + "*")
                .Where(file =>
                    stockNumber.ToString().Equals(Path.GetFileNameWithoutExtension(file)) || Path.GetFileNameWithoutExtension(file).Contains("_")).ToArray();
            string temp = null;
            if (files.Length > 0)
            {
                var file = files.First();

                var directoryInfo = new FileInfo(Path.GetTempFileName()).Directory;
                if (directoryInfo != null)
                    temp = Path.Combine(directoryInfo.FullName, new FileInfo(file).Name);

                File.Copy(file, temp, true);
            }
            return temp ?? "/Resources/Images/notFound.png";
        }
    }
}
