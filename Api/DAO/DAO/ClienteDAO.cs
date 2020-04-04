using DAO.Datos;
using Entidades;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using DAO.Services;

namespace DAO.DAO
{
    public class ClienteDAO : ICliente
    {
        protected readonly BodegaContext _context;
        public ClienteDAO(BodegaContext context)
        {
            _context = context;
        }
        public List<Clientes> ConsultarClientes()
        {
            List<Clientes> listaClientes = null;

            listaClientes = (from cliente in _context.Cliente
                             where cliente.Estado == 1
                             select new Clientes
                             {
                                 IdCliente = cliente.IdCliente,
                                 Nombres = cliente.Nombres,
                                 Apellidos = cliente.Apellidos,
                                 Cedula = cliente.Cedula,
                                 Estado = (int)cliente.Estado
                             }).ToList();

            return listaClientes;
        }

        public void GuardarCliente(Clientes model)
        {
            try
            {
                var cliente = new Cliente();
                cliente.Nombres = model.Nombres;
                cliente.Apellidos = model.Apellidos;
                cliente.Cedula = model.Cedula;
                cliente.Estado = 1;

                _context.Cliente.Add(cliente);
                _context.SaveChanges();
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public void ActualizarCliente(Clientes model)
        {
            try
            {
                Cliente cliente = _context.Cliente.Where(i => i.IdCliente == model.IdCliente).FirstOrDefault();
                cliente.Nombres = model.Nombres;
                cliente.Apellidos = model.Apellidos;
                cliente.Cedula = model.Cedula;

                _context.SaveChanges();

            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public void EliminarCliente(int idCliente)
        {
            try
            {
                Cliente cliente = _context.Cliente.Where(i => i.IdCliente == idCliente).FirstOrDefault();
                cliente.Estado = 0;

                _context.SaveChanges();

            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public List<Clientes> ConsultarClientePorNombres(string nombres)
        {
            List<Clientes> listaClientes = null;

            listaClientes = (from cliente in _context.Cliente
                             where cliente.Nombres.Contains(nombres)
                             select new Clientes
                             {
                                 IdCliente = cliente.IdCliente,
                                 Nombres = cliente.Nombres,
                                 Apellidos = cliente.Apellidos,
                                 Cedula = cliente.Cedula,
                                 Estado = (int)cliente.Estado
                             }).ToList();

            return listaClientes;
        }

        public Clientes ConsultarClientePorId(int idCliente)
        {
            Clientes listaClientes = null;

            listaClientes = (from cliente in _context.Cliente
                             where cliente.IdCliente == idCliente
                             && cliente.Estado == 1
                             select new Clientes
                             {
                                 IdCliente = cliente.IdCliente,
                                 Nombres = cliente.Nombres,
                                 Apellidos = cliente.Apellidos,
                                 Cedula = cliente.Cedula,
                                 Estado = (int)cliente.Estado
                             }).FirstOrDefault();

            return listaClientes;
        }

        public List<SelectListItem> ListaClientes()
        {
            var bodegas = (from cliente in _context.Cliente
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
}