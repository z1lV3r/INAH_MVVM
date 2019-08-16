using INAH.Commands;
using INAH.Services;
using INAH.ViewModels.Abstracts;
using System;
using System.Windows;
using System.Windows.Controls;
using INAH.Exceptions;

namespace INAH.ViewModels
{
    public class LoginViewModel : BaseWindowViewModel
    {
        public static Guid viewId;
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
                throw new Ex(){Code = 500, Severity = BaseException.SeverityType.Warning, Tittle = "titulo", Description = "texto en el cuerpo"};
            }

            //select mail and password
            userId = 0;

            navigatorService.NativigateToCollections(ViewId, userId);
        }
    }
}