using System;
using System.Collections.Generic;

namespace RegistroInfraestructure.Data
{
    public partial class Cliente
    {
        public Cliente()
        {
        }

        public int IdCliente { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        
    }
}
