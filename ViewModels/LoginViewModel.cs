using System.Windows.Media;

namespace INAH.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }


        public LoginViewModel()
        {
            Tittle = "Inicio de sesión";
            IsOnline = false;
        }
    }
}