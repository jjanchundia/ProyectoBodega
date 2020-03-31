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
            try
            {
                oProducto.IdProducto = model.IdProducto;
                oProducto.IdCategoria = model.IdCategoria;
                oProducto.Nombre = model.Nombre;
                oProducto.Descripcion = model.Descripcion;
                oProducto.FechaExpiracion = model.FechaExpiracion;

                producto.ActualizarProducto(oProducto);
            }
            catch (Exception e)
            {
                throw e;
            }
            return Ok("Exito Actualizado");
        }

        [HttpPost]
        [Route("eliminarproductos/{idProducto}")]
        public ActionResult EliminarBodega(int idProducto)
        {
            producto.EliminarProducto(idProducto);
            return Ok();
        }

        [HttpPost]
        public ActionResult GuardarProducto(ProductoModel model)
        {
            try
            {
                oProducto.IdCategoria = model.IdCategoria;
                oProducto.Nombre = model.Nombre;
                oProducto.Descripcion = model.Descripcion;
                oProducto.FechaExpiracion = model.FechaExpiracion;

                producto.GuardarProducto(oProducto);
            }
            catch (Exception e)
            {
                throw e;
            }
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

        [HttpGet]
        [Route("consultarcategorias")]
        public List<SelectListItem> ListaCategoria()
        {
            using (var bd = new BodegaContext())
            {
                var categorias = (from categoria in bd.Categoria
                                  select new SelectListItem
                                  {
                                      Text = categoria.Nombre,
                                      Value = categoria.IdCategoria.ToString()
                                  }).ToList();
                categorias.Insert(0, new SelectListItem { Text = "--Seleccione--", Value = "" });
                dynamic ViewBag = categorias;
                return ViewBag;
            }
        }
    }
}