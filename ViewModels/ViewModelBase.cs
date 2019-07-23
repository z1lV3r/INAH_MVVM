using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace INAH.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
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
    }
}
