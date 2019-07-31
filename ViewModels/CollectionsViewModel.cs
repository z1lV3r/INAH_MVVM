using INAH.ViewModels.Abstracts;
using System;
using System.Collections.ObjectModel;

namespace INAH.ViewModels
{
    public class CollectionsViewModel : BaseWindowViewModel
    {
        public static Guid viewId;
        public static string user;

        public override Guid ViewId { get { return viewId; } }
        public string User { get => user; set => user = value; }
        public ObservableCollection<CollectionsItemViewModel> Items { get; private set; }

        public CollectionsViewModel()
        {
            viewId = Guid.NewGuid();
            Tittle = "Colección";
            Items = new ObservableCollection<CollectionsItemViewModel>();
            Items.Add(new CollectionsItemViewModel("/Resources/Images/help.png", "name1"));
            Items.Add(new CollectionsItemViewModel("/Resources/Images/help.png", "name2"));
            Items.Add(new CollectionsItemViewModel("/Resources/Images/help.png", "name2"));
            Items.Add(new CollectionsItemViewModel("/Resources/Images/help.png", "name2"));
            Items.Add(new CollectionsItemViewModel("/Resources/Images/help.png", "name2"));
            Items.Add(new CollectionsItemViewModel("/Resources/Images/help.png", "name2"));
            Items.Add(new CollectionsItemViewModel("/Resources/Images/help.png", "name2"));
            Items.Add(new CollectionsItemViewModel("/Resources/Images/help.png", "name2"));
            Items.Add(new CollectionsItemViewModel("/Resources/Images/help.png", "name2"));
            Items.Add(new CollectionsItemViewModel("/Resources/Images/help.png", "name2"));
            Items.Add(new CollectionsItemViewModel("/Resources/Images/help.png", "name2"));
            Items.Add(new CollectionsItemViewModel("/Resources/Images/help.png", "name2"));
            Items.Add(new CollectionsItemViewModel("/Resources/Images/help.png", "name2"));
            Items.Add(new CollectionsItemViewModel("/Resources/Images/help.png", "name2"));
        }
    }
}
