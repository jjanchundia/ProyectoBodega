using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebBodega.Models
{
    public class ServicioModel
    {
        public string IdServicio { get; set; }
        [Required(ErrorMessage = "Ingrese Nombre")]
        public string NombreServicio { get; set; }
        [Required(ErrorMessage = "Seleccione Cliente")]
        public int? IdCliente { get; set; }
        public string NombreCliente { get; set; }
        [Required(ErrorMessage = "Seleccione Bodega")]
        public int? IdBodega { get; set; }
        public string NombreBodega { get; set; }




        public int Estado { get; set; }

    }
}
