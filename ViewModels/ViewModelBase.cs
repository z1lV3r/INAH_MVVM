using System.ComponentModel;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace INAH.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public ViewModelBase()
        {
            NetworkChange.NetworkAvailabilityChanged += 
                (object sender, NetworkAvailabilityEventArgs e) =>
                {
                    IsOnline = e.IsAvailable;
                };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyname = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        private string tittle;
        public string Tittle
        {
            get { return tittle; }
            set { tittle = value; }
        }

        private static bool isOnline;

        public bool IsOnline
        {
            get { return isOnline; }
            set
            {
                StatusColor = value ? Brushes.Green : Brushes.Red;
                StatusText = value ? "Con conexión" : "Sin conexión";
                isOnline = value;
            }
        }

        private SolidColorBrush statusColor;

        public SolidColorBrush StatusColor
        {
            get { return statusColor; }
            set {
                statusColor = value;
                NotifyPropertyChanged();
            }
        }

        private string statusText;

        public string StatusText
        {
            get { return statusText; }
            set {
                statusText = value;
                NotifyPropertyChanged();
            }
        }

    }
}
