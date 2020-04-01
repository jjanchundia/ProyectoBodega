using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebBodega.Models
{
    public class ClienteModel
    {
        public int IdCliente { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Cedula { get; set; }
        public int Estado { get; set; }
    }
}
