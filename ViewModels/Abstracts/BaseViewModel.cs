using INAH.Services;
using System;
using System.ComponentModel;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace INAH.ViewModels.Abstracts
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        protected NavigatorService navigatorService;
        public event PropertyChangedEventHandler PropertyChanged;

        protected BaseViewModel()
        {
            navigatorService = new NavigatorService();
        }

        protected void NotifyPropertyChanged([CallerMemberName] string propertyname = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
    }
}
