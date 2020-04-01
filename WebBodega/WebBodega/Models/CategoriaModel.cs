using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebBodega.Models
{
    public class CategoriaModel
    {
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Estado { get; set; }
        public int IdBodega { get; set; }
        public string BodegaNombre { get; set; }
    }
}
