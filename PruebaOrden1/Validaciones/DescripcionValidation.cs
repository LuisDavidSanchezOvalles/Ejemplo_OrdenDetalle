using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Controls;

namespace PruebaOrden1.Validaciones
{
    public class DescripcionValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value != null)
            {
                string descripcion = Convert.ToString(value);

                if (descripcion.Length <= 0)
                    return new ValidationResult(false, "Debes poner un Nombre al producto");

                foreach (char caracter in descripcion)
                {
                    if (!char.IsLetter(caracter) && !char.IsWhiteSpace(caracter) && !char.IsDigit(caracter))
                    {
                        return new ValidationResult(false, "No puede tener caracteres expeciales");
                    }
                }
                return ValidationResult.ValidResult;
            }
            return new ValidationResult(false, "Debe Tener un Campo");
        }
    }
}
