using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebBodega.Models
{
    public class ClienteModel
    {
        public int IdCliente { get; set; }
        [Required(ErrorMessage ="Ingrese Nombres:")]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "Ingrese Apellidos:")]
        public string Apellidos { get; set; }
        [Required(ErrorMessage = "Ingrese Cedula:")]
        public string Cedula { get; set; }
        public int Estado { get; set; }
    }
}
