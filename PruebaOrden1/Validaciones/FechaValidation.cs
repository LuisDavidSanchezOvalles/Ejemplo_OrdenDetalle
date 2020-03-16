using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Controls;

namespace PruebaOrden1.Validaciones
{
    public class FechaValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if(value != null)
            {
                DateTime fecha;
                try
                {
                    fecha = Convert.ToDateTime(value);
                }
                catch(FormatException)
                {
                    return new ValidationResult(false, "Debe ser una Fecha en MM/DD/AAAA");
                }

                if (fecha <= DateTime.Now)
                    return ValidationResult.ValidResult;
                else
                    return new ValidationResult(false, "No puede Ser Mayor que la fecha Actual");                
            }
            return new ValidationResult(false, "Debe de haber una fecha");
        }
    }
}
