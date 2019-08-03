using INAH.ViewModels.Abstracts;
using System;
using System.Collections.ObjectModel;

namespace INAH.ViewModels
{
    public class CollectionsViewModel : BaseWindowViewModel
    {
        public static Guid viewId;
        public static string user;

        public override Guid ViewId => viewId;
        public string User { get => user; set => user = value; }
        public ObservableCollection<CollectionsItemViewModel> Items { get; private set; }

        public CollectionsViewModel()
        {
            viewId = Guid.NewGuid();
            Title = "Colección";
            Items = new ObservableCollection<CollectionsItemViewModel>();
            Items.Add(new CollectionsItemViewModel("1","/Resources/Images/help.png", "name1"));
            Items.Add(new CollectionsItemViewModel("2","/Resources/Images/help.png", "name2"));
            Items.Add(new CollectionsItemViewModel("3","/Resources/Images/help.png", "name2"));
            Items.Add(new CollectionsItemViewModel("4","/Resources/Images/help.png", "name2"));
            Items.Add(new CollectionsItemViewModel("5","/Resources/Images/help.png", "name2"));
            Items.Add(new CollectionsItemViewModel("6","/Resources/Images/help.png", "name2"));
            Items.Add(new CollectionsItemViewModel("7","/Resources/Images/help.png", "name2"));
            Items.Add(new CollectionsItemViewModel("8","/Resources/Images/help.png", "name2"));
            Items.Add(new CollectionsItemViewModel("9","/Resources/Images/help.png", "name2"));
            Items.Add(new CollectionsItemViewModel("10","/Resources/Images/help.png", "name2"));
            Items.Add(new CollectionsItemViewModel("11","/Resources/Images/help.png", "name2"));
            Items.Add(new CollectionsItemViewModel("12","/Resources/Images/help.png", "name2"));
            Items.Add(new CollectionsItemViewModel("13","/Resources/Images/help.png", "name2"));
            Items.Add(new CollectionsItemViewModel("14","/Resources/Images/help.png", "name2"));
        }
    }
}
