using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebBodega.Models
{
    public class BodegaModel
    {
        public int IdBodega { get; set; }
        [Required(ErrorMessage = "Ingrese Nombre:")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Ingrese Descripción:")]
        public string Descripcion { get; set; }
        public int Estado { get; set; }
    }
}
