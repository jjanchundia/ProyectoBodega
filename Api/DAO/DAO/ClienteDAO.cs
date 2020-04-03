using DAO.Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DAO.DAO
{
    public class ClienteDAO
    {
        public List<Clientes> ConsultarClientes()
        {
            List<Clientes> listaClientes = null;
            using (var bd = new BodegaContext())
            {
                listaClientes = (from cliente in bd.Cliente
                                 where cliente.Estado == 1
                                 select new Clientes
                                 {
                                     IdCliente = cliente.IdCliente,
                                     Nombres = cliente.Nombres,
                                     Apellidos = cliente.Apellidos,
                                     Cedula = cliente.Cedula,
                                     Estado = (int)cliente.Estado
                                 }).ToList();
            }

            return listaClientes;
        }

        public void GuardarCliente(Clientes model)
        {
            try
            {
                using (BodegaContext bd = new BodegaContext())
                {
                    var cliente = new Cliente();
                    cliente.Nombres = model.Nombres;
                    cliente.Apellidos = model.Apellidos;
                    cliente.Cedula = model.Cedula;
                    cliente.Estado = 1;

                    bd.Cliente.Add(cliente);
                    bd.SaveChanges();
                }
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
                using (BodegaContext bd = new BodegaContext())
                {
                    Cliente cliente = bd.Cliente.Where(i => i.IdCliente == model.IdCliente).FirstOrDefault();
                    cliente.Nombres = model.Nombres;
                    cliente.Apellidos = model.Apellidos;
                    cliente.Cedula = model.Cedula;

                    bd.SaveChanges();
                }
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
                using (BodegaContext bd = new BodegaContext())
                {
                    Cliente cliente = bd.Cliente.Where(i => i.IdCliente == idCliente).FirstOrDefault();
                    cliente.Estado = 0;

                    bd.SaveChanges();
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public List<Clientes> ConsultarClientePorNombres(string nombres)
        {
            List<Clientes> listaClientes = null;
            using (var bd = new BodegaContext())
            {
                listaClientes = (from cliente in bd.Cliente
                                 where cliente.Nombres.Contains(nombres)
                                 select new Clientes
                                 {
                                     IdCliente = cliente.IdCliente,
                                     Nombres = cliente.Nombres,
                                     Apellidos = cliente.Apellidos,
                                     Cedula = cliente.Cedula,
                                     Estado = (int)cliente.Estado
                                 }).ToList();

            }

            return listaClientes;
        }

        public Clientes ConsultarClientePorId(int idCliente)
        {
            Clientes listaClientes = null;
            using (var bd = new BodegaContext())
            {
                listaClientes = (from cliente in bd.Cliente
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

            }

            return listaClientes;
        }
                
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
    }
}