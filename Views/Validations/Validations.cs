using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using INAH.Exceptions;

namespace INAH.Views.Validations
{
    public class Validations
    {
        public static void IntegerValidation(Guid viewId, string name, string value)
        {
            if (!string.IsNullOrEmpty(value) && !value.All(char.IsDigit)) throw new NotNumberInputException(name, viewId);
        }

        public static void NotNullValidation(Guid viewId, string name, string value)
        {
            if (string.IsNullOrEmpty(value)) throw new RequiredInputException(name, viewId);
        }

        public static void FloatValidation(Guid viewId, string name, string value)
        {
            var regex = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");
            if (!string.IsNullOrEmpty(value) && (!regex.IsMatch(value) || float.Parse(value)<=0f)) throw new NotFloatInputException(name, viewId);
        }
    }
}
