using System;
using System.Collections.Generic;

namespace DAO.Datos
{
    public partial class Bodegas
    {
        public Bodegas()
        {
            Categoria = new HashSet<Categoria>();
            ServicioAlojamiento = new HashSet<ServicioAlojamiento>();
        }

        public int IdBodega { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int? Estado { get; set; }

        public virtual ICollection<Categoria> Categoria { get; set; }
        public virtual ICollection<ServicioAlojamiento> ServicioAlojamiento { get; set; }
    }
}
