using INAH.ViewModels.Abstracts;
using System;
using System.Collections.ObjectModel;
using INAH.Commands;

namespace INAH.ViewModels
{
    public class CollectionsViewModel : BaseWindowViewModel
    {
        public static Guid viewId;
        public static string user;

        public override Guid ViewId => viewId;
        public string User { get => user; set => user = value; }
        public ObservableCollection<CollectionsItemViewModel> Items { get; private set; }

        public RelayCommand AddCommand { get; set; }

        public CollectionsViewModel()
        {
            viewId = Guid.NewGuid();
            Title = "Colección";
            Items = new ObservableCollection<CollectionsItemViewModel>();
            Items.Add(new CollectionsItemViewModel("1"));
            Items.Add(new CollectionsItemViewModel("2"));
            Items.Add(new CollectionsItemViewModel("3"));
            Items.Add(new CollectionsItemViewModel("4"));
            Items.Add(new CollectionsItemViewModel("5"));
            Items.Add(new CollectionsItemViewModel("6"));
            Items.Add(new CollectionsItemViewModel("7"));
            Items.Add(new CollectionsItemViewModel("8"));
            Items.Add(new CollectionsItemViewModel("9"));
            Items.Add(new CollectionsItemViewModel("10"));
            Items.Add(new CollectionsItemViewModel("11"));
            Items.Add(new CollectionsItemViewModel("12"));
            Items.Add(new CollectionsItemViewModel("13"));
            Items.Add(new CollectionsItemViewModel("14"));
            AddCommand = new RelayCommand(AddCommandExec);
        }

        public void AddCommandExec(object args)
        {
            navigatorService.NavigateToItemEdit(CollectionsViewModel.viewId, Math.Abs(Guid.NewGuid().GetHashCode()).ToString());
        }
    }
}
