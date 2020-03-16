using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Controls;

namespace PruebaOrden1.Validaciones
{
    public class CantidadValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value != null)
            {
                int cantidad = 0;
                try
                {
                    cantidad = Convert.ToInt32(value);
                }
                catch (FormatException)
                {
                    return new ValidationResult(false, "Debe ser un Numero Entero");
                }

                if (cantidad > 0)
                    return ValidationResult.ValidResult;
                else
                    return new ValidationResult(false, "Debe ser mayor que 0");
            }
            return new ValidationResult(false, "Debes Poner Id");
        }
    }
}
