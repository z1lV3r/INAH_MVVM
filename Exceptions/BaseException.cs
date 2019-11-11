using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INAH.Exceptions
{
    public abstract class BaseException : Exception
    {
        public enum SeverityType
        {
            Info,
            Warning,
            Error
        }

        public SeverityType Severity { get; set; }
        public string Tittle { get; set; }
        public string Description { get; set; }
        public Guid? ViewId { get; set; }

    }
}
