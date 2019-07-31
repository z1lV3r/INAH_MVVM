using INAH.Commands;
using INAH.Services;
using INAH.ViewModels.Abstracts;
using System;
using System.Windows;
using System.Windows.Controls;

namespace INAH.ViewModels
{
    public class LoginViewModel : BaseWindowViewModel
    {
        private static Guid viewId;
        public override Guid ViewId { get { return viewId; } }
        public string Email { get; set; }
        public RelayCommand LoginCommand { get; private set; }

        private SecurityService SecurityService;

        public LoginViewModel()
        {
            viewId = Guid.NewGuid();
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
                navigatorService.NativigateToCollections(ViewId, user);
            }
            else
            {
                MessageBox.Show("La contraseña y el correo proporcionado no coinciden en los registros.", "Error de autenticación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}