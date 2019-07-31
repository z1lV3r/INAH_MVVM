using INAH.Commands;
using INAH.Services;
using INAH.ViewModels.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INAH.ViewModels
{
    class ItemEditViewModel : BaseItemOpWindowViewModel
    {
        private static Guid viewId;
        public override Guid ViewId { get { return viewId; } }
        public ItemEditViewModel()
        {
            viewId = Guid.NewGuid();
            Tittle = "Edición de elemento";
        }
    }
}
