using System;
using System.Collections.Generic;

namespace DAO.Datos
{
    public partial class Categoria
    {
        public Categoria()
        {
            Producto = new HashSet<Producto>();
        }

        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int? IdBodega { get; set; }
        public int? Estado { get; set; }

        public virtual Bodegas IdBodegaNavigation { get; set; }
        public virtual ICollection<Producto> Producto { get; set; }
    }
}
