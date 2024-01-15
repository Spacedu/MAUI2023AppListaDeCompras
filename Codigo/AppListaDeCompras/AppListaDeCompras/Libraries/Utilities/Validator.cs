using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppListaDeCompras.Libraries.Utilities
{
    public class Validator
    {
        public static string ShowErrorMessage(ValidationResult result)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var failure in result.Errors)
            {
                sb.AppendLine($"{failure.ErrorMessage}");
            }
            return sb.ToString();
        }
    }
}
