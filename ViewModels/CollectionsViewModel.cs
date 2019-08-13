using INAH.ViewModels.Abstracts;
using System;
using System.Collections.ObjectModel;
using INAH.Commands;

namespace INAH.ViewModels
{
    public class CollectionsViewModel : BaseWindowViewModel
    {
        public static Guid viewId;
        public static int userId;

        public override Guid ViewId => viewId;
        public int UserId { get => userId; set => userId = value; }
        public ObservableCollection<CollectionsItemViewModel> Items { get; protected set; }

        public RelayCommand AddCommand { get; set; }

        public CollectionsViewModel() { }

        public CollectionsViewModel(string user)
        {
            viewId = Guid.NewGuid();
            Title = "Colección";
            Items = new ObservableCollection<CollectionsItemViewModel>();
            AddCommand = new RelayCommand(AddCommandExec);
        }

        public void AddCommandExec(object args)
        {
            navigatorService.NavigateToItemEdit(CollectionsViewModel.viewId, Math.Abs(Guid.NewGuid().GetHashCode()).ToString());
        }
    }
}
