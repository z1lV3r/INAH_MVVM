using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INAH.Exceptions
{
    class RequiredInputException : BaseException
    {
        public RequiredInputException(string name, Guid viewId)
        {
            ViewId = viewId;
            Severity = SeverityType.Error;
            Tittle = "Datos incorrectos";
            Description = "Los datos marcados con * son obligatorios.\nVerifica el campo " + name + ".";
        }
    }
}
