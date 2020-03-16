using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaOrden1.Entidades
{
    public class Contenedor
    {
        public Orden orden { get; set; }
        public ProductoDetalle detalle { get; set; }

        public Contenedor()
        {
            orden = new Orden();
            detalle = new ProductoDetalle();
        }
    }
}
