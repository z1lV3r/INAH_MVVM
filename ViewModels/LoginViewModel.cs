using INAH.Commands;
using INAH.Services;
using System.Net.NetworkInformation;
using System.Windows;
using System.Windows.Controls;

namespace INAH.ViewModels
{
    public class LoginViewModel : BaseWindowViewModel
    {
        public string Email { get; set; }
        public RelayCommand LoginCommand { get; private set; }

        private SecurityService SecurityService;

        public LoginViewModel()
        {
            Tittle = "Inicio de sesión";
            LoginCommand = new RelayCommand(LoginCommandExec);
            SecurityService = new SecurityService();
        }

        public void LoginCommandExec(object args)
        {
            PasswordBox passwordBox = args as PasswordBox;
            string password = passwordBox.Password;
            if(SecurityService.authenticate(Email, password))
            {
                string user="";
                navigatorService.NativigateToCollections(this, user);
            }
            else
            {
                MessageBox.Show("La contraseña y el correo proporcionado no coinciden en los registros.", "Error de autenticación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}