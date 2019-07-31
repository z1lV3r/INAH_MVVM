using INAH.Commands;
using INAH.Services;
using INAH.ViewModels.Abstracts;
using System.Windows;

namespace INAH.ViewModels
{
    public class CollectionsItemViewModel : BaseViewModel
    {
        private string image;
        private string name;
        public string Image
        {
            get => image;
            set
            {
                image = value;
                NotifyPropertyChanged();
            }
        }
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
            navigatorService.NavigateToItemDetail(CollectionsViewModel.viewId);
        }

        public void EditCommandExec(object args)
        {
            navigatorService.NavigateToItemEdit(CollectionsViewModel.viewId);
        }

        public void DeleteCommandExec(object args)
        {
            MessageBox.Show(name);
        }
    }
}
