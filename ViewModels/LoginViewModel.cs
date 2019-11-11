using INAH.Commands;
using INAH.Services;
using INAH.ViewModels.Abstracts;
using System;
using System.Windows;
using System.Windows.Controls;
using INAH.Exceptions;
using INAH.Models;
using INAH.Services.DataServices;

namespace INAH.ViewModels
{
    public class LoginViewModel : BaseWindowViewModel
    {
        public static Guid viewId;
        public override Guid ViewId => viewId;
        public string Email { get; set; }
        public RelayCommand LoginCommand { get; private set; }

        private SecurityService securityService;

        private WebConsumerService webConsumerService;

        private UsersDataService usersDataService;

        public LoginViewModel()
        {
            viewId = Guid.NewGuid();
            Title = "Inicio de sesión";
            LoginCommand = new RelayCommand(LoginCommandExec);
            securityService = new SecurityService();
            webConsumerService = new WebConsumerService();
            usersDataService = new UsersDataService();
        }

        public void LoginCommandExec(object args)
        {
            var passwordBox = args as PasswordBox;

            var password = securityService.CypherPass(passwordBox.Password);

            if (IsOnline)
            {
                var user = webConsumerService.Login(Email, password);
                usersDataService.Upsert(user);
            }

            var local = usersDataService.Find(new Users() {Email = Email, Password = password});
            if (local == null) throw new InvalidLoginDataException(viewId);

            navigatorService.NavigateToCollections(ViewId, local.Id);
        }
    }
}