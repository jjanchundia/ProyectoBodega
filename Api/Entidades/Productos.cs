using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Productos
    {
        public int IdProducto { get; set; }
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaExpiracion { get; set; }
        public int Estado { get; set; }
        public string NombreCategoria { get; set; }
    }
}
