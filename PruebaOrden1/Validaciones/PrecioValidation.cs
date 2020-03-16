using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Controls;

namespace PruebaOrden1.Validaciones
{
    public class PrecioValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value != null)
            {
                decimal precio = 0;
                try
                {
                    precio = Convert.ToDecimal(value);
                }
                catch (FormatException)
                {
                    return new ValidationResult(false, "Debe ser un Numero");
                }

                if (precio >= 0)
                    return ValidationResult.ValidResult;
                else
                    return new ValidationResult(false, "Debe ser igual o mayor que 0");
            }
            return new ValidationResult(false, "Debes Poner Precio");
        }
    }
}
