using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Controls;
using PruebaOrden1.Entidades;

namespace PruebaOrden1.Validaciones
{
    public class DetalleValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if(value != null)
            {
                return ValidationResult.ValidResult;
            }
            return new ValidationResult(false, "debe Agregar un campo para Guardar");
        }
    }
}
