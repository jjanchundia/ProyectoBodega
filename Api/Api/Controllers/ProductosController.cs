using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models;
using DAO.DAO;
using DAO.Datos;
using Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        ProductoDAO producto = new ProductoDAO();
        Productos oProducto = new Productos();

        [HttpPost]
        [Route("actualizarproducto/")]
        public ActionResult ActualizarProducto(ProductoModel model)
        {
            oProducto.IdProducto = model.IdProducto;
            oProducto.IdCategoria = model.IdCategoria;
            oProducto.Nombre = model.Nombre;
            oProducto.Descripcion = model.Descripcion;
            oProducto.FechaExpiracion = model.FechaExpiracion;

            producto.ActualizarProducto(oProducto);

            return Ok("Exito Actualizado");
        }

        [HttpGet]
        [Route("eliminarproductos/{idProducto}")]
        public ActionResult EliminarBodega(int idProducto)
        {
            producto.EliminarProducto(idProducto);
            return Ok();
        }

        [HttpPost]
        public ActionResult GuardarProducto(ProductoModel model)
        {
            oProducto.IdCategoria = model.IdCategoria;
            oProducto.Nombre = model.Nombre;
            oProducto.Descripcion = model.Descripcion;
            oProducto.FechaExpiracion = model.FechaExpiracion;

            producto.GuardarProducto(oProducto);
         
            return Ok("Exito");
        }

        [HttpGet]
        public ActionResult ConsultarProductos()
        {
            return Ok(producto.ConsultarProductos());
        }

        [HttpGet]
        [Route("consultarproductoporid/{idProducto}")]
        public ActionResult ConsultarProductoPorId(int idProducto)
        {
            return Ok(producto.ConsultarProductosPorId(idProducto));
        }

        [HttpGet]
        [Route("consultarproductopornombres/{nombres}")]
        public ActionResult ConsultarProductoPorNombres(string nombres)
        {
            return Ok(producto.ConsultarProductoPorNombres(nombres));
        }        
    }
}