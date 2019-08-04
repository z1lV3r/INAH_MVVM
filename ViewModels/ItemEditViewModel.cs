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

        public ObservableCollection<string> Types { get; set; }

        public ObservableCollection<string> ConservationTypes { get; set; }

        public ItemEditViewModel()
        {

            viewId = Guid.NewGuid();
            Title = "Edición de elemento";

            Types = new ObservableCollection<string>();
            Types.Add("Arqueológico");
            Types.Add("Histórico");
            Types.Add("Paleontológico");
            Types.Add("Etnográfico");
            Types.Add("Contemporáneo");

            ConservationTypes = new ObservableCollection<string>();
            ConservationTypes.Add("No requiere intervencion");
            ConservationTypes.Add("Requiere intervencion");
            ConservationTypes.Add("Requiere intervencion urgente");
            ConservationTypes.Add("En riesgo");
        }
    }
}
