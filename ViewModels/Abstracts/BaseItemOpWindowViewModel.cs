using INAH.Commands;
using INAH.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INAH.ViewModels.Abstracts
{
    public abstract class BaseItemOpWindowViewModel : BaseWindowViewModel
    {
        public long ItemId { get; set; }
        public RelayCommand ReturnToCollections { get; private set; }

        public BaseItemOpWindowViewModel()
        {
            ReturnToCollections = new RelayCommand(ReturnToCollectionsExec);
        }

        public void ReturnToCollectionsExec(object args)
        {
            navigatorService.NativigateToCollections(ViewId, CollectionsViewModel.user, NavigatorService.NavigationMode.MODAL);
        }
    }
}
