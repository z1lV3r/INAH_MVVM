using INAH.ViewModels;
using INAH.ViewModels.Abstracts;
using INAH.Views;
using System;
using System.Windows;

namespace INAH.Services
{
    public class NavigatorService
    {
        public enum NavigationMode { SHOW, MODAL, DIALOG }
        private void Show(Guid windowId, Window window, NavigationMode navigationMode)
        {
            switch(navigationMode)
            {
                case NavigationMode.SHOW:
                    window.Show();
                    Close(windowId);
                    break;
                case NavigationMode.MODAL:
                    window.Show();
                    break;
                case NavigationMode.DIALOG:
                    window.ShowDialog();
                    break;
            }
        }
        public void Close(Guid windowId)
        {
            foreach (Window item in Application.Current.Windows)
            {
                if (item.DataContext is BaseWindowViewModel vm && vm.ViewId == windowId) item.Close();
            }
        }
        public void NavigateToLogin(Guid windowId, NavigationMode navigationMode=NavigationMode.SHOW)
        {
            LoginView view = new LoginView()
            {
                DataContext = new LoginViewModel()
            };
            Show(windowId, view, navigationMode);
        }

        public void NavigateToCollections(Guid windowId, int userId, NavigationMode navigationMode = NavigationMode.SHOW)
        {
            CollectionsView view = new CollectionsView()
            {
                DataContext = new CollectionsViewModel(userId)
            };
            Show(windowId, view, navigationMode);
        }

        public void NavigateToItemDetail(Guid windowId, int id, NavigationMode navigationMode = NavigationMode.SHOW)
        {
            ItemDetailView view = new ItemDetailView()
            {
                DataContext = new ItemDetailViewModel()
                {
                    StockNumber = id
                }
            };
            Show(windowId, view, navigationMode);
        }

        public void NavigateToItemEdit(Guid windowId, int id, NavigationMode navigationMode = NavigationMode.SHOW)
        {
            ItemEditView view = new ItemEditView()
            {
                DataContext = new ItemEditViewModel(id)
            };
            Show(windowId, view, navigationMode);
        }
    }
}
