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
        [Required(ErrorMessage = "Seleccione Categoria:")]
        public int? IdCategoria { get; set; }
        [Required(ErrorMessage = "Ingrese Nombre:")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Ingrese Descripción:")]
        public string Descripcion { get; set; }
        public string NombreCategoria { get; set; }
        //control fecha
        [DataType(DataType.Date)]
        //Para q nos permita registrar el formato de la fecha para no tener problemas al insertar
        [DisplayFormat(DataFormatString = "{0:yyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha Expiración")]
        [Required(ErrorMessage = "Ingrese Fecha:")]
        public DateTime? FechaExpiracion { get; set; }
        public int Estado { get; set; }
    }
}
