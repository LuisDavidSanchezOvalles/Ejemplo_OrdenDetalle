using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Controls;

namespace PruebaOrden1.Validaciones
{
    public class NombresValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if(value != null)
            {
                string nombres = Convert.ToString(value);

                if (nombres.Length <= 0)
                    return new ValidationResult(false, "Debes poner un Nombre a La persona");

                foreach(char caracter in nombres)
                {
                    if (!char.IsLetter(caracter) && !char.IsWhiteSpace(caracter))
                    {
                        return new ValidationResult(false, "No Puede Contener Numeros");
                    }     
                }
                return ValidationResult.ValidResult;
            }
            return new ValidationResult(false, "Debe Tener un Campo");
        }
    }
}
