using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}