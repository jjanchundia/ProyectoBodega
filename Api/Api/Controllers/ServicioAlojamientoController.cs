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
    public class ServicioAlojamientoController : ControllerBase
    {
        ServicioDAO servicio = new ServicioDAO();
        Servicio oServicio = new Servicio();

        [HttpPost]
        [Route("actualizarservicio/")]
        public ActionResult ActualizarServicio(ServiciosModel model)
        {
            oServicio.IdServicio = model.IdServicio;
            oServicio.NombreServicio = model.NombreServicio;
            oServicio.IdCliente = model.IdCliente;
            oServicio.IdBodega = model.IdBodega;

            servicio.ActualizarServicio(oServicio);

            return Ok("Exito Actualizado");
        }

        [HttpPost]
        public ActionResult Guardarservicio(ServiciosModel model)
        {
            oServicio.IdServicio = model.IdServicio;
            oServicio.IdBodega = model.IdBodega;
            oServicio.NombreServicio = model.NombreServicio;
            oServicio.IdCliente = model.IdCliente;

            servicio.GuardarServicio(oServicio);

            return Ok("Exito");
        }

        [HttpGet]
        public ActionResult Consultarservicios()
        {
            return Ok(servicio.ConsultarServicios());
        }

        [HttpGet]
        [Route("consultarservicioporid/{idservicio}")]
        public ActionResult ConsultarservicioPorId(int idservicio)
        {
            return Ok(servicio.ConsultarServiciosPorId(idservicio));
        }

        [HttpGet]
        [Route("consultarserviciopornombres/{nombres}")]
        public ActionResult ConsultarservicioPorNombres(string nombres)
        {
            return Ok(servicio.ConsultarServicioPorNombres(nombres));
        }

        [HttpPost]
        [Route("eliminarservicio/{idservicio}")]
        public ActionResult EliminarServicio(int idservicio)
        {
            servicio.EliminarServicio(idservicio);
            return Ok("Exito");
        }
       
        [HttpGet]
        [Route("reporte/{idCliente}")]
        public ActionResult ConsultarReporte(int idCliente)
        {
            return Ok(servicio.ConsultarProductos(idCliente));
        }
    }
}