using Entidades;
using Microsoft.AspNetCore.Mvc;
using DAO.Services;
using Api.Models;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioAlojamientoController : ControllerBase
    {
        private readonly IServicio _repo;
        public ServicioAlojamientoController(IServicio repo)
        {
            _repo = repo;
        }

        private Servicio PrepareProducto(ServiciosModel model)
        {
            var servicio = new Servicio();
            servicio.IdServicio = model.IdServicio;
            servicio.NombreServicio = model.NombreServicio;
            servicio.IdCliente = model.IdCliente;
            servicio.IdBodega = model.IdBodega;

            return servicio;
        }

        [HttpPost]
        [Route("actualizarservicio/")]
        public ActionResult ActualizarServicio(ServiciosModel model)
        {
            _repo.ActualizarServicio(PrepareProducto(model));
            return Ok();
        }

        [HttpPost]
        //aveces es bueno ser especifico asi que ponemos la atiqueta from body para que entienda que queremos el resultado del body 
        public IActionResult Guardarservicio([FromBody]ServiciosModel model)
        {
            _repo.GuardarServicio(PrepareProducto(model));
            return Ok();
        }

        [HttpGet]
        public ActionResult Consultarservicios()
        {
            return Ok(_repo.ConsultarServicios());
        }
               
        [HttpGet]
        [Route("reporte/{idCliente}")]
        public IActionResult ConsultarReporte(int idCliente)
        {
            return Ok(_repo.ConsultarProductos(idCliente));
        }
    }
}