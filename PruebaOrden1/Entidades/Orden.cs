using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PruebaOrden1.Entidades
{
    public class Orden
    {
        [Key]
        public int OrdenId { get; set; }
        public string Nombres { get; set; }
        public DateTime Fecha { get; set; }

        [ForeignKey("OrdenId")]
        public virtual List<ProductoDetalle> Productos { get; set; }

        public Orden()
        {
            OrdenId = 0;
            Nombres = string.Empty;
            Fecha = DateTime.Now;

            Productos = new List<ProductoDetalle>();
        }
    }
}
