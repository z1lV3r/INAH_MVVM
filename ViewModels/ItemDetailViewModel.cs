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
    public class ItemDetailViewModel : BaseItemOpWindowViewModel
    {
        public static Guid viewId;
        public override Guid ViewId => viewId;

        public ItemDetailViewModel() { }
        public ItemDetailViewModel(int id, int userId) : base(id, userId)
        {
            viewId = Guid.NewGuid();
            Title = "Detalle de elemento";
        }
    }
}
