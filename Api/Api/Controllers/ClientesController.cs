using System.Collections.Generic;
using Api.Models;
using DAO.DAO;
using Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        ClienteDAO cliente = new ClienteDAO();
        Clientes oCliente = new Clientes();
        public ActionResult ConsultarClientes()
        {
            return Ok(cliente.ConsultarClientes());
        }

        [HttpPost]
        [Route("actualizarcliente/")]
        public ActionResult ActualizarCliente(ClienteModel model)
        {
            oCliente.IdCliente = model.IdCliente;
            oCliente.Nombres = model.Nombres;
            oCliente.Apellidos = model.Apellidos;
            oCliente.Cedula = model.Cedula;

            cliente.ActualizarCliente(oCliente);

            return Ok("Exito Actualizado");
        }

        [HttpGet]
        [Route("eliminarcliente/{idCliente}")]
        public ActionResult EliminarCliente(int idCliente)
        {
            cliente.EliminarCliente(idCliente);
            return Ok();
        }

        [HttpPost]
        public ActionResult GuardarCliente(ClienteModel model)
        {
            oCliente.Nombres = model.Nombres;
            oCliente.Apellidos = model.Apellidos;
            oCliente.Cedula = model.Cedula;

            cliente.GuardarCliente(oCliente);
            return Ok("Exito");
        }

        [HttpGet]
        [Route("consultarclienteporid/{idCliente}")]
        public ActionResult ConsultarClientePorId(int idCliente)
        {
            return Ok(cliente.ConsultarClientePorId(idCliente));
        }

        [HttpGet]
        [Route("consultarclientepornombres/{nombres}")]
        public ActionResult ConsultarClientePorNombres(string nombres)
        {
            return Ok(cliente.ConsultarClientePorNombres(nombres));
        }

        [HttpGet]
        [Route("consultarclientes")]
        public List<SelectListItem> ListaClientes()
        {
            return cliente.ListaClientes();
        }
    }
}