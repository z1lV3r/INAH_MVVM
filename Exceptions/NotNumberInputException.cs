using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INAH.Exceptions
{
    class NotNumberInputException : BaseException
    {
        public NotNumberInputException(string name)
        {
            Severity = SeverityType.Error;
            Tittle = "Datos incorrectos";
            Description = "Los datos proporcionados en el campo " + name + " no son validos, verificar que sean númericos.";
        }
    }
}
