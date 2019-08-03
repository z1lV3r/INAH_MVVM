using INAH.Commands;
using INAH.Services;
using INAH.ViewModels.Abstracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INAH.ViewModels
{
    class ItemEditViewModel : BaseItemOpWindowViewModel
    {
        private static Guid viewId;
        public override Guid ViewId => viewId;

        public ObservableCollection<string> Items { get; set; }

        public ItemEditViewModel()
        {

            Items = new ObservableCollection<string>();
            Items.Add("uno");
            Items.Add("dos");
            Items.Add("tres");
            viewId = Guid.NewGuid();
            Title = "Edición de elemento";
        }
    }
}
