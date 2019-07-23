using INAH.ViewModels;
using INAH.Views;
using System.Windows;

namespace INAH.Services
{
    public class NavigatorService
    {

        private void Show(Window window, bool isDialog)
        {
            if(isDialog)
            {
                window.ShowDialog();
            } else
            {
                window.Show();
            }
        }
        public void NavigateToLogin(bool isDialog=false)
        {
            LoginView view = new LoginView()
            {
                DataContext = new LoginViewModel()
            };
            Show(view, isDialog);
        }

        public void NativigateToCollections(string user, bool isDialog=false)
        {
            CollectionsView view = new CollectionsView();
            {
                
            }
        }
    }
}
