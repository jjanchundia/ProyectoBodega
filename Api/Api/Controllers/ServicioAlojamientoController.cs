using Api.Models;
using Entidades;
using Microsoft.AspNetCore.Mvc;
using DAO.Services;

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
            return Ok("Exito Actualizado");
        }

        [HttpPost]
        public ActionResult Guardarservicio(ServiciosModel model)
        {
            _repo.GuardarServicio(PrepareProducto(model));
            return Ok("Exito");
        }

        [HttpGet]
        public ActionResult Consultarservicios()
        {
            return Ok(_repo.ConsultarServicios());
        }

        [HttpGet]
        [Route("consultarservicioporid/{idservicio}")]
        public ActionResult ConsultarservicioPorId(int idservicio)
        {
            return Ok(_repo.ConsultarServiciosPorId(idservicio));
        }

        [HttpGet]
        [Route("consultarserviciopornombres/{nombres}")]
        public ActionResult ConsultarservicioPorNombres(string nombres)
        {
            return Ok(_repo.ConsultarServicioPorNombres(nombres));
        }
               
        [HttpGet]
        [Route("reporte/{idCliente}")]
        public ActionResult ConsultarReporte(int idCliente)
        {
            return Ok(_repo.ConsultarProductos(idCliente));
        }
    }
}