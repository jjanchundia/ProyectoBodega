using System;
using System.Collections.Generic;

namespace DAO.Datos
{
    public partial class ServicioAlojamiento
    {
        public int IdServicio { get; set; }
        public string NombreServicio { get; set; }
        public int? IdCliente { get; set; }
        public int? IdBodega { get; set; }
        public int? Estado { get; set; }

        public virtual Bodegas IdBodegaNavigation { get; set; }
        public virtual Cliente IdClienteNavigation { get; set; }
    }
}
