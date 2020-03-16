using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PruebaOrden1.Entidades
{
    public class ProductoDetalle
    {
        [Key]
        public int ProductoId { get; set; }
        public int OrdenId { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public decimal Monto { get; set; }
        public int Cantidad { get; set; }

        public ProductoDetalle() { }

        public ProductoDetalle(int ordenId, string descripcion, decimal precio, decimal monto, int cantidad)
        {
            ProductoId = 0;
            OrdenId = ordenId;
            Descripcion = descripcion;
            Precio = precio;
            Monto = monto;
            Cantidad = cantidad;
        }
    }
}
