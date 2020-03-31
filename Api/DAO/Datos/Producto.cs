using System;
using System.Collections.Generic;

namespace DAO.Datos
{
    public partial class Producto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime? FechaExpiracion { get; set; }
        public int? IdCategoria { get; set; }
        public int? Estado { get; set; }

        public virtual Categoria IdCategoriaNavigation { get; set; }
    }
}
