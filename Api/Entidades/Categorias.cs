using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Categorias
    {
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string BodegaNombre { get; set; }
        public int Estado { get; set; }
        public int IdBodega { get; set; }
    }
}
