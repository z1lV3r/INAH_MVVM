using System.Collections.ObjectModel;

namespace INAH.ViewModels
{
    public class CollectionsViewModel : BaseWindowViewModel
    {
        public string User { get; set; }
        public ObservableCollection<CollectionsItemViewModel> Items { get; private set; }
        public CollectionsViewModel()
        {
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
