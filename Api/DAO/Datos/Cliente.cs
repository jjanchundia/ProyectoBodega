using System;
using System.Collections.Generic;

namespace DAO.Datos
{
    public partial class Cliente
    {
        public Cliente()
        {
            ServicioAlojamiento = new HashSet<ServicioAlojamiento>();
        }

        public int IdCliente { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Cedula { get; set; }
        public int? Estado { get; set; }

        public virtual ICollection<ServicioAlojamiento> ServicioAlojamiento { get; set; }
    }
}
