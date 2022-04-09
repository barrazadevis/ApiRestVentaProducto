using System;
using System.Collections.Generic;

namespace RegistroInfraestructure.Data
{
    public partial class Producto
    {
        public Producto()
        {
        }

        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public decimal? ValorUnitario { get; set; }

    }
}
