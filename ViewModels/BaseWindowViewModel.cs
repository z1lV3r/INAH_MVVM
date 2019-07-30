using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace INAH.ViewModels
{
    public abstract class BaseWindowViewModel : BaseViewModel
    {
        private static bool isOnline;
        private string statusText;
        private SolidColorBrush statusColor;

        public string Tittle { get; set; }
        public string Rights { get; set; }
        public bool IsOnline
        {
            get => isOnline;
            set
            {
                StatusColor = value ? Brushes.Green : Brushes.Red;
                StatusText = value ? "Con conexión" : "Sin conexión";
                isOnline = value;
            }
        }
        public string StatusText
        {
            get => statusText;
            set
            {
                statusText = value;
                NotifyPropertyChanged();
            }
        }
        public SolidColorBrush StatusColor
        {
            get => statusColor;
            set
            {
                statusColor = value;
                NotifyPropertyChanged();
            }
        }

        protected BaseWindowViewModel()
        {
            NetworkChange.NetworkAvailabilityChanged += (sender, e) => { IsOnline = e.IsAvailable; };
            IsOnline = NetworkInterface.GetIsNetworkAvailable();
            Rights = "TODOS LOS DERECHOS RESERVADOS © " + DateTime.Now.Year.ToString();
        }
    }
}
