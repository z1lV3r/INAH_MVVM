using INAH.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            MainWindow login = new MainWindow();
            LoginViewModel loginVM = new LoginViewModel();
            login.DataContext = loginVM;
            Show(login, isDialog);
        }
    }
}
