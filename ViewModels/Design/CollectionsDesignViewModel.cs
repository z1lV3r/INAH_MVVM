using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INAH.ViewModels.Design
{
    public class CollectionsDesignViewModel : CollectionsViewModel
    {
        public CollectionsDesignViewModel()
        {
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
        }
    }
}
