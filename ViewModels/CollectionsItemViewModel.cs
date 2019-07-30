using INAH.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace INAH.ViewModels
{
    public class CollectionsItemViewModel : BaseViewModel
    {

        private string image;
        public string Image
        {
            get => image;
            set
            {
                image = value;
                NotifyPropertyChanged();
            }
        }
        private string name;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                NotifyPropertyChanged();
            }
        }
        public RelayCommand ShowDetailCommand { get; private set; }
        public RelayCommand EditCommand { get; private set; }
        public RelayCommand DeleteCommand { get; private set; }

        public CollectionsItemViewModel(string image, string name)
        {
            Image = image;
            Name = name;
            ShowDetailCommand = new RelayCommand(ShowDetailCommandExec);
            EditCommand = new RelayCommand(EditCommandExec);
            DeleteCommand = new RelayCommand(DeleteCommandExec);
        }

        public void ShowDetailCommandExec(object args)
        {
            MessageBox.Show(name);
        }

        public void EditCommandExec(object args)
        {
            MessageBox.Show(name);
        }

        public void DeleteCommandExec(object args)
        {
            MessageBox.Show(name);
        }
    }
}
