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
            try
            {
                oServicio.IdServicio = model.IdServicio;
                oServicio.NombreServicio = model.NombreServicio;
                oServicio.IdCliente = model.IdCliente;
                oServicio.IdBodega = model.IdBodega;

                servicio.ActualizarServicio(oServicio);
            }
            catch (Exception e)
            {
                throw e;
            }
            return Ok("Exito Actualizado");
        }

        [HttpPost]
        public ActionResult Guardarservicio(ServiciosModel model)
        {
            try
            {
                //oServicio.IdServicio = model.IdServicio;
                oServicio.IdBodega = model.IdBodega;
                oServicio.NombreServicio = model.NombreServicio;
                oServicio.IdCliente = model.IdCliente;

                servicio.GuardarServicio(oServicio);
            }
            catch (Exception e)
            {
                throw e;
            }
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
        [Route("consultarbodegas")]
        public List<SelectListItem> ListaBodega()
        {
            using (var bd = new BodegaContext())
            {
                var bodegas = (from bodega in bd.Bodegas
                               where bodega.Estado == 1
                               select new SelectListItem
                               {
                                   Text = bodega.Nombre,
                                   Value = bodega.IdBodega.ToString()
                               }).ToList();
                bodegas.Insert(0, new SelectListItem { Text = "--Seleccione--", Value = "" });
                dynamic ViewBag = bodegas;
                return ViewBag;
            }
        }

        [HttpGet]
        [Route("consultarclientes")]
        public List<SelectListItem> ListaClientes()
        {
            using (var bd = new BodegaContext())
            {
                var bodegas = (from cliente in bd.Cliente
                               where cliente.Estado == 1
                               select new SelectListItem
                               {
                                   Text = cliente.Nombres + " " + cliente.Apellidos,
                                   Value = cliente.IdCliente.ToString()
                               }).ToList();
                bodegas.Insert(0, new SelectListItem { Text = "--Seleccione--", Value = "" });
                dynamic ViewBag = bodegas;
                return ViewBag;
            }
        }

        [HttpGet]
        [Route("reporte/{idCliente}")]
        public ActionResult ConsultarReporte(int idCliente)
        {
            return Ok(servicio.ConsultarProductos(idCliente));
        }
    }
}