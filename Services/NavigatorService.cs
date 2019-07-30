using INAH.ViewModels;
using INAH.Views;
using System.Windows;

namespace INAH.Services
{
    public class NavigatorService
    {
        public enum NavigationMode { SHOW, MODAL, DIALOG }
        private void Show(object context, Window window, NavigationMode navigationMode)
        {
            switch(navigationMode)
            {
                case NavigationMode.SHOW:
                    window.Show();
                    foreach (Window item in Application.Current.Windows)
                    {
                        if (item.DataContext == context) item.Close();
                    }
                    break;
                case NavigationMode.MODAL:
                    window.Show();
                    break;
                case NavigationMode.DIALOG:
                    window.ShowDialog();
                    break;
            }
        }
        public void NavigateToLogin(object context, NavigationMode navigationMode=NavigationMode.SHOW)
        {
            LoginView view = new LoginView()
            {
                DataContext = new LoginViewModel()
            };
            Show(context, view, navigationMode);
        }

        public void NativigateToCollections(object context, string user, NavigationMode navigationMode = NavigationMode.SHOW)
        {
            CollectionsView view = new CollectionsView()
            {
                DataContext = new CollectionsViewModel()
                {
                    User = user
                }
            };
            Show(context, view, navigationMode);
        }
    }
}
