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
        public override Guid ViewId => viewId;
        public string Email { get; set; }
        public RelayCommand LoginCommand { get; private set; }

        private SecurityService SecurityService;

        public LoginViewModel()
        {
            viewId = Guid.NewGuid();
            Title = "Inicio de sesión";
            LoginCommand = new RelayCommand(LoginCommandExec);
            SecurityService = new SecurityService();
        }

        public void LoginCommandExec(object args)
        {
            PasswordBox passwordBox = args as PasswordBox;

            var pass = SecurityService.cypherPass(passwordBox.Password);

            int userId;

            if (IsOnline)
            {
                SecurityService.authenticate(Email, pass);
                //upsert mail password
                Window window = Utils.GetWindowFromViewModelId(viewId);
                MessageBox.Show(window, "");
            }

            //select mail and password
            userId = 0;

            navigatorService.NativigateToCollections(ViewId, userId);
        }
    }
}