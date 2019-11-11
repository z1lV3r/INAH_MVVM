using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INAH.Exceptions
{
    class NotFloatInputException : BaseException
    {
        public NotFloatInputException(string name, Guid viewId)
        {
            ViewId = viewId;
            Severity = SeverityType.Error;
            Tittle = "Datos incorrectos";
            Description = "Los datos proporcionados en el campo " + name + " no son validos, verificar que sean númericos con decimales mayor a 0.";
        }
    }
}
