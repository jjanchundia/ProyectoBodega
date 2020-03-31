using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models;
using DAO.DAO;
using Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        [Route("api/clientes/actualizarcliente/")]
        public ActionResult ActualizarCliente(ClienteModel model)
        {
            try
            {
                oCliente.IdCliente = model.IdCliente;
                oCliente.Nombres = model.Nombres;
                oCliente.Apellidos = model.Apellidos;
                oCliente.Cedula = model.Cedula;

                cliente.ActualizarCliente(oCliente);
            }
            catch (Exception e)
            {
                throw e;
            }
            return Ok("Exito Actualizado");
        }

        [HttpGet]
        [Route("api/clientes/eliminarcliente/{idCliente}")]
        public ActionResult EliminarCliente(int idCliente)
        {
            cliente.EliminarCliente(idCliente);
            return Ok();
        }

        [HttpPost]
        public ActionResult GuardarCliente(ClienteModel model)
        {
            try
            {
                oCliente.Nombres = model.Nombres;
                oCliente.Apellidos = model.Apellidos;
                oCliente.Cedula = model.Cedula;

                cliente.GuardarCliente(oCliente);
            }
            catch (Exception e)
            {
                throw e;
            }
            return Ok("Exito");
        }

        [HttpGet]
        [Route("api/clientes/consultarclienteporid/{idCliente}")]
        public ActionResult ConsultarClientePorId(int idCliente)
        {
            return Ok(cliente.ConsultarClientePorId(idCliente));
        }

        [HttpGet]
        [Route("api/clientes/consultarclientepornombres/{nombres}")]
        public ActionResult ConsultarClientePorNombres(string nombres)
        {
            return Ok(cliente.ConsultarClientePorNombres(nombres));
        }
    }
}