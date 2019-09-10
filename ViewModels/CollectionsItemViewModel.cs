using System.Linq;
using INAH.Commands;
using INAH.Services;
using INAH.ViewModels.Abstracts;
using System.Windows;
using INAH.Services.DataServices;

namespace INAH.ViewModels
{
    public class CollectionsItemViewModel : BaseViewModel
    {
        private int userId;
        private string image;
        private string name;
        public int Id { get; set; }
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
        public RelayCommand ShowDetailCommand { get; protected set; }
        public RelayCommand EditCommand { get; protected set; }
        public RelayCommand DeleteCommand { get; protected set; }

        protected PiecesDataService piecesDataService;
        protected PieceDetailsDataService pieceDetailsDataService;
        protected FileService fileService;

        public CollectionsItemViewModel()
        {
        }
        public CollectionsItemViewModel(int userId)
        {
            this.userId = userId;

            piecesDataService = new PiecesDataService();
            pieceDetailsDataService = new PieceDetailsDataService();
            fileService = new FileService();

            ShowDetailCommand = new RelayCommand(ShowDetailCommandExec);
            EditCommand = new RelayCommand(EditCommandExec);
            DeleteCommand = new RelayCommand(DeleteCommandExec);
        }

        public void ShowDetailCommandExec(object args)
        {
            navigatorService.NavigateToItemDetail(CollectionsViewModel.viewId, Id, userId);
        }

        public void EditCommandExec(object args)
        {
            navigatorService.NavigateToItemEdit(CollectionsViewModel.viewId, Id, userId);
        }

        public void DeleteCommandExec(object args)
        {
            var res = MessageBox.Show("¿Estas seguro que deseas eliminar el elemento " + Name + "?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (res.Equals(MessageBoxResult.No)) return;
            piecesDataService.Delete(Id);
            CollectionsViewModel.Items.Remove(CollectionsViewModel.Items.First(vm => vm.Id == Id));
        }
    }
}
