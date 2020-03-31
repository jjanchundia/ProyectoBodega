using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Servicio
    {
        public int IdServicio { get; set; }
        public string NombreServicio { get; set; }
        public int IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public int IdBodega { get; set; }
        public string NombreBodega { get; set; }
        //public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public List<Productos> Productos { get; set; }
        public DateTime FechaExpiracion { get; set; }
        //public int IdCategoria { get; set; }
        public string NombreCategoria { get; set; }
        public int Estado { get; set; }
    }
}