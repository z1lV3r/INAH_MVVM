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
            Items.Add(new CollectionsItemDesignViewModel(1));
            Items.Add(new CollectionsItemDesignViewModel(2));
            Items.Add(new CollectionsItemDesignViewModel(3));
            Items.Add(new CollectionsItemDesignViewModel(4));
            Items.Add(new CollectionsItemDesignViewModel(5));
            Items.Add(new CollectionsItemDesignViewModel(6));
            Items.Add(new CollectionsItemDesignViewModel(7));
            Items.Add(new CollectionsItemDesignViewModel(8));
            Items.Add(new CollectionsItemDesignViewModel(9));
            Items.Add(new CollectionsItemDesignViewModel(10));
            Items.Add(new CollectionsItemDesignViewModel(11));
            Items.Add(new CollectionsItemDesignViewModel(12));
            Items.Add(new CollectionsItemDesignViewModel(13));
            Items.Add(new CollectionsItemDesignViewModel(14));
        }
    }
}
