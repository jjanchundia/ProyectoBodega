using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebBodega.Models
{
    public class ServicioModel
    {
        public string IdServicio { get; set; }
        public int Value { get; set; }
        public string NombreServicio { get; set; }
        public int IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public int IdBodega { get; set; }
        public string NombreBodega { get; set; }
        public int Estado { get; set; }
    }
}
