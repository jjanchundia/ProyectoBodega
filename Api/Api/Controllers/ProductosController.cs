using Api.Models;
using Entidades;
using Microsoft.AspNetCore.Mvc;
using DAO.Services;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IProducto _repo;
        public ProductosController(IProducto repo)
        {
            _repo = repo;
        }

        private Productos PrepareProducto(ProductoModel model)
        {
            var producto = new Productos();
            producto.IdProducto = model.IdProducto;
            producto.IdCategoria = model.IdCategoria;
            producto.Nombre = model.Nombre;
            producto.Descripcion = model.Descripcion;
            producto.FechaExpiracion = model.FechaExpiracion;

            return producto;
        }

        [HttpPost]
        [Route("actualizarproducto/")]
        public ActionResult ActualizarProducto(ProductoModel model)
        {
            _repo.ActualizarProducto(PrepareProducto(model));
            return Ok("Exito Actualizado");
        }

        [HttpGet]
        [Route("eliminarproductos/{idProducto}")]
        public ActionResult EliminarBodega(int idProducto)
        {
            _repo.EliminarProducto(idProducto);
            return Ok();
        }

        [HttpPost]
        public ActionResult GuardarProducto(ProductoModel model)
        {
            _repo.GuardarProducto(PrepareProducto(model));         
            return Ok("Exito");
        }

        [HttpGet]
        public ActionResult ConsultarProductos()
        {
            return Ok(_repo.ConsultarProductos());
        }

        [HttpGet]
        [Route("consultarproductoporid/{idProducto}")]
        public ActionResult ConsultarProductoPorId(int idProducto)
        {
            return Ok(_repo.ConsultarProductosPorId(idProducto));
        }

        [HttpGet]
        [Route("consultarproductopornombres/{nombres}")]
        public ActionResult ConsultarProductoPorNombres(string nombres)
        {
            return Ok(_repo.ConsultarProductoPorNombres(nombres));
        }        
    }
}