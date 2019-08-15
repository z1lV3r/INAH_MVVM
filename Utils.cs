using System;
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
    }
}
