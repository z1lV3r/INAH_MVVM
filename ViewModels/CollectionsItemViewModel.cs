using INAH.Commands;
using INAH.Services;
using INAH.ViewModels.Abstracts;
using System.Windows;
using INAH.Services.DataServices;

namespace INAH.ViewModels
{
    public class CollectionsItemViewModel : BaseViewModel
    {
        private string image;
        private string name;
        public string Id { get; set; }
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

        private PiecesDataService piecesDataService;
        private FileService fileService;

        public CollectionsItemViewModel(string id)
        {
            piecesDataService = new PiecesDataService();
            fileService = new FileService();
            
            Id = id;
            Image = fileService.GetImagePath(id);
            Name = piecesDataService.GetName(id);
            ShowDetailCommand = new RelayCommand(ShowDetailCommandExec);
            EditCommand = new RelayCommand(EditCommandExec);
            DeleteCommand = new RelayCommand(DeleteCommandExec);
        }

        public void ShowDetailCommandExec(object args)
        {
            navigatorService.NavigateToItemDetail(CollectionsViewModel.viewId, Id);
        }

        public void EditCommandExec(object args)
        {
            navigatorService.NavigateToItemEdit(CollectionsViewModel.viewId, Id);
        }

        public void DeleteCommandExec(object args)
        {
            MessageBoxResult res = MessageBox.Show("¿Estas seguro que deseas eliminar el elemento " + Name + "?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (res.Equals(MessageBoxResult.Yes))
            {
                piecesDataService.Delete(Id);
            }
        }
    }
}
