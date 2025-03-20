using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipeApp.Exceptions.ExceptionsBase
{
    public class ErrorOnValidationException : MyRecipeAppException
    {
        public IList<string> ErrorMessages { get; set; }

        public ErrorOnValidationException(IList<string> errors)
        {
            ErrorMessages = errors;
        }
    }
}
