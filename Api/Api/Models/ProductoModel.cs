using System;

namespace Api.Models
{
    public class ProductoModel
    {
        public int IdProducto { get; set; }
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaExpiracion { get; set; }
        public int Estado { get; set; }
    }
}
