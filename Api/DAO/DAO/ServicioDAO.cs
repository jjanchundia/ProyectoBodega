using DAO.Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using DAO.Services;

namespace DAO.DAO
{
    public class ServicioDAO : IServicio
    {
        protected readonly BodegaContext _context;
        public ServicioDAO(BodegaContext context)
        {
            _context = context;
        }

        public void GuardarServicio(Servicio model)
        {
            try
            {
                ServicioAlojamiento servicio = new ServicioAlojamiento();
                servicio.NombreServicio = model.NombreServicio;
                servicio.IdCliente = model.IdCliente;
                servicio.IdBodega = model.IdBodega;
                servicio.Estado = 1;

                _context.ServicioAlojamiento.Add(servicio);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void ActualizarServicio(Servicio model)
        {
            try
            {
                ServicioAlojamiento servicio = _context.ServicioAlojamiento.Where(i => i.IdServicio == model.IdServicio).FirstOrDefault();
                servicio.IdServicio = model.IdServicio;
                servicio.NombreServicio = model.NombreServicio;
                servicio.IdCliente = model.IdCliente;
                servicio.IdBodega = model.IdBodega;

                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Servicio> ConsultarServicios()
        {
            List<Servicio> listaServicios = null;

            listaServicios = (from servicio in _context.ServicioAlojamiento
                              join bodega in _context.Bodegas
                              on servicio.IdBodega equals bodega.IdBodega
                              join cliente in _context.Cliente
                              on servicio.IdCliente equals cliente.IdCliente
                              orderby servicio.IdServicio
                              where servicio.Estado == 1
                              select new Servicio
                              {
                                  IdServicio = (int)servicio.IdServicio,
                                  NombreServicio = servicio.NombreServicio,
                                  IdCliente = (int)servicio.IdCliente,
                                  NombreCliente = cliente.Nombres + " " + cliente.Apellidos,
                                  NombreBodega = bodega.Nombre,
                                  IdBodega = (int)servicio.IdBodega,
                              }).ToList();

            return listaServicios;
        }

        public List<Servicio> ConsultarServicioPorNombres(string nombres)
        {
            List<Servicio> listaServicios = null;

            listaServicios = (from servicio in _context.ServicioAlojamiento
                              join bodega in _context.Bodegas
                              on servicio.IdBodega equals bodega.IdBodega
                              join cliente in _context.Cliente
                              on servicio.IdCliente equals cliente.IdCliente
                              orderby servicio.IdServicio
                              where servicio.NombreServicio.Contains(nombres)
                              select new Servicio
                              {
                                  IdServicio = (int)servicio.IdServicio,
                                  NombreServicio = servicio.NombreServicio,
                                  IdCliente = (int)servicio.IdCliente,
                                  IdBodega = (int)servicio.IdBodega,
                              }).ToList();

            return listaServicios;
        }

        public Servicio ConsultarReporte(int idCliente, DateTime fecha)
        {
            Servicio reporte = null;

            fecha = DateTime.Now;
            DateTime fechaNueva = fecha.AddMonths(1);

            reporte = (from servicio in _context.ServicioAlojamiento
                       join bodega in _context.Bodegas
                       on servicio.IdBodega equals bodega.IdBodega
                       join cliente in _context.Cliente
                       on servicio.IdCliente equals cliente.IdCliente
                       join categoria in _context.Categoria
                       on bodega.IdBodega equals categoria.IdBodega
                       join producto in _context.Producto
                       on categoria.IdCategoria equals producto.IdCategoria
                       where servicio.IdCliente == idCliente
                       && (producto.FechaExpiracion <= fechaNueva)
                       orderby servicio.IdServicio
                       where servicio.Estado == 1
                       select new Servicio
                       {
                           NombreServicio = servicio.NombreServicio,
                           NombreCliente = cliente.Nombres + " " + cliente.Apellidos,
                           NombreBodega = bodega.Nombre,
                           NombreProducto = producto.Nombre,
                           FechaExpiracion = (DateTime)producto.FechaExpiracion,
                           NombreCategoria = categoria.Nombre,
                           Productos = ConsultarProductos(idCliente).ToList()
                       }).FirstOrDefault();

            return reporte;
        }

        public List<Productos> ConsultarProductos(int idCliente)
        {
            List<Productos> reporte = null;

            DateTime fecha = DateTime.Now;
            DateTime fechaNueva = fecha.AddMonths(1);

            reporte = (from servicio in _context.ServicioAlojamiento
                       join bodega in _context.Bodegas
                       on servicio.IdBodega equals bodega.IdBodega
                       join cliente in _context.Cliente
                       on servicio.IdCliente equals cliente.IdCliente
                       join categoria in _context.Categoria
                       on bodega.IdBodega equals categoria.IdBodega
                       join producto in _context.Producto
                       on categoria.IdCategoria equals producto.IdCategoria
                       where servicio.IdCliente == idCliente
                       && (producto.FechaExpiracion <= fechaNueva)
                       orderby servicio.IdServicio
                       where servicio.Estado == 1
                       select new Productos
                       {
                           Nombre = producto.Nombre,
                           FechaExpiracion = (DateTime)producto.FechaExpiracion,
                           NombreCategoria = categoria.Nombre,
                           Descripcion = producto.Descripcion
                       }).ToList();

            return reporte;
        }

        public Servicio ConsultarServiciosPorId(int idServicio)
        {
            Servicio listaServicios = null;

            listaServicios = (from servicio in _context.ServicioAlojamiento
                              join bodega in _context.Bodegas
                              on servicio.IdBodega equals bodega.IdBodega
                              join cliente in _context.Cliente
                              on servicio.IdCliente equals cliente.IdCliente
                              where servicio.IdServicio == idServicio
                              select new Servicio
                              {
                                  IdServicio = (int)servicio.IdServicio,
                                  NombreServicio = servicio.NombreServicio,
                                  IdCliente = (int)servicio.IdCliente,
                                  IdBodega = (int)servicio.IdBodega,
                              }).FirstOrDefault();

            return listaServicios;
        }
    }
}