using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class ServiciosModel
    {
        public int IdServicio { get; set; }
        public string NombreServicio { get; set; }
        public int IdCliente { get; set; }
        public int IdBodega { get; set; }
        public int Estado { get; set; }
    }
}