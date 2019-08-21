using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INAH.Exceptions
{
    public class InvalidLoginDataException : BaseException
    {
        public InvalidLoginDataException()
        {
            Severity = SeverityType.Error;
            Tittle = "Datos incorrectos";
            Description = "Los datos proporcionados no son validos. Intente nuevamente.";
        }
    }
}
