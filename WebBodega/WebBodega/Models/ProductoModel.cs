using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebBodega.Models
{
    public class ProductoModel
    {
        public int IdProducto { get; set; }
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string NombreCategoria { get; set; }
        //control fecha
        [DataType(DataType.Date)]
        //Para q nos permita registrar el formato de la fecha para no tener problemas al insertar
        [DisplayFormat(DataFormatString = "{0:yyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha Expiración")]
        public DateTime FechaExpiracion { get; set; }
        public int Estado { get; set; }
    }
}
