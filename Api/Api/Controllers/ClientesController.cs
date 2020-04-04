using System.Collections.Generic;
using Api.Models;
using DAO.Services;
using Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ICliente _repo;
        public ClientesController(ICliente repo)
        {
            _repo = repo;
        }
        
        private Clientes PrepareCliente(ClienteModel model)
        {
            var oCliente = new Clientes();
            oCliente.IdCliente = model.IdCliente;
            oCliente.Nombres = model.Nombres;
            oCliente.Apellidos = model.Apellidos;
            oCliente.Cedula = model.Cedula;

            return oCliente;
        }
        public ActionResult ConsultarClientes()
        {
            return Ok(_repo.ConsultarClientes());
        }

        [HttpPost]
        [Route("actualizarcliente/")]
        public ActionResult ActualizarCliente(ClienteModel model)
        {            
            _repo.ActualizarCliente(PrepareCliente(model));
            return Ok("Exito Actualizado");
        }

        [HttpGet]
        [Route("eliminarcliente/{idCliente}")]
        public ActionResult EliminarCliente(int idCliente)
        {
            _repo.EliminarCliente(idCliente);
            return Ok();
        }

        [HttpPost]
        public ActionResult GuardarCliente(ClienteModel model)
        {
            _repo.GuardarCliente(PrepareCliente(model));
            return Ok("Exito");
        }

        [HttpGet]
        [Route("consultarclienteporid/{idCliente}")]
        public ActionResult ConsultarClientePorId(int idCliente)
        {
            return Ok(_repo.ConsultarClientePorId(idCliente));
        }

        [HttpGet]
        [Route("consultarclientepornombres/{nombres}")]
        public ActionResult ConsultarClientePorNombres(string nombres)
        {
            return Ok(_repo.ConsultarClientePorNombres(nombres));
        }

        [HttpGet]
        [Route("consultarclientes")]
        public List<SelectListItem> ListaClientes()
        {
            return _repo.ListaClientes();
        }
    }
}