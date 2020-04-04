using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Entidades;

namespace DAO.Services
{
    public interface ICliente
    {
        List<Clientes> ConsultarClientes();
        void GuardarCliente(Clientes model);
        void ActualizarCliente(Clientes model);
        void EliminarCliente(int idCliente);
        List<Clientes> ConsultarClientePorNombres(string nombres);
        Clientes ConsultarClientePorId(int idCliente);
        List<SelectListItem> ListaClientes();
    }
}