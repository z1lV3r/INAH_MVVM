using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INAH.Exceptions;
using INAH.Models;

namespace INAH.Services
{
    class WebConsumerService
    {

        public WebConsumerService()
        {

        }
        public Users Login(string email, string password)
        {
            return new Users(){Email = email, Password = password, Name = "Hugo Villanueva Jimenez"};
            //throw new InvalidLoginDataException();
        }
    }
}
