using DAO.Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAO.DAO
{
    public class ServicioDAO
    {
        public void GuardarServicio(Servicio model)
        {
            try
            {
                using (BodegaContext bd = new BodegaContext())
                {
                    ServicioAlojamiento servicio = new ServicioAlojamiento();
                    servicio.IdServicio = model.IdServicio;
                    servicio.NombreServicio = model.NombreServicio;
                    servicio.IdCliente = model.IdCliente;
                    servicio.IdBodega = model.IdBodega;
                    servicio.Estado = 1;

                    bd.ServicioAlojamiento.Add(servicio);
                    bd.SaveChanges();
                }
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void ActualizarServicio(Servicio model)
        {
            try
            {
                using (BodegaContext bd = new BodegaContext())
                {
                    ServicioAlojamiento servicio = bd.ServicioAlojamiento.Where(i => i.IdServicio == model.IdServicio).FirstOrDefault();
                    servicio.IdServicio = model.IdServicio;
                    servicio.NombreServicio = model.NombreServicio;
                    servicio.IdCliente = model.IdCliente;
                    servicio.IdBodega = model.IdBodega;

                    bd.SaveChanges();
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public void EliminarServicio(int idServicio)
        {
            try
            {
                using (BodegaContext bd = new BodegaContext())
                {
                    ServicioAlojamiento servicio = bd.ServicioAlojamiento.Where(i => i.IdServicio == idServicio).FirstOrDefault();
                    servicio.Estado = 0;

                    bd.SaveChanges();
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public List<Servicio> ConsultarServicios()
        {
            List<Servicio> listaServicios = null;
            using (var bd = new BodegaContext())
            {
                listaServicios = (from servicio in bd.ServicioAlojamiento
                                  join bodega in bd.Bodegas
                                  on servicio.IdBodega equals bodega.IdBodega
                                  join cliente in bd.Cliente
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
            }

            return listaServicios;
        }

        public List<Servicio> ConsultarServicioPorNombres(string nombres)
        {
            List<Servicio> listaServicios = null;
            using (var bd = new BodegaContext())
            {
                listaServicios = (from servicio in bd.ServicioAlojamiento
                                  join bodega in bd.Bodegas
                                  on servicio.IdBodega equals bodega.IdBodega
                                  join cliente in bd.Cliente
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
            }

            return listaServicios;
        }

        public Servicio ConsultarReporte(int idCliente, DateTime fecha)
        {
            Servicio reporte = null;

            fecha = DateTime.Now;
            DateTime fechaNueva = fecha.AddMonths(1);

            using (var bd = new BodegaContext())
            {
                reporte = (from servicio in bd.ServicioAlojamiento
                           join bodega in bd.Bodegas
                           on servicio.IdBodega equals bodega.IdBodega
                           join cliente in bd.Cliente
                           on servicio.IdCliente equals cliente.IdCliente
                           join categoria in bd.Categoria
                           on bodega.IdBodega equals categoria.IdBodega
                           join producto in bd.Producto
                           on categoria.IdCategoria equals producto.IdCategoria
                           where servicio.IdCliente == idCliente
                           && (producto.FechaExpiracion <= fechaNueva)
                           orderby servicio.IdServicio
                           where servicio.Estado == 1
                           select new Servicio
                           {
                               //IdServicio = (int)servicio.IdServicio,
                               NombreServicio = servicio.NombreServicio,
                               NombreCliente = cliente.Nombres + " " + cliente.Apellidos,
                               NombreBodega = bodega.Nombre,
                               NombreProducto = producto.Nombre,
                               FechaExpiracion = (DateTime)producto.FechaExpiracion,
                               NombreCategoria = categoria.Nombre,
                               Productos = ConsultarProductos(idCliente).ToList()
                           }).FirstOrDefault();
            }

            return reporte;
        }

        public List<Productos> ConsultarProductos(int idCliente)
        {
            List<Productos> reporte = null;

            DateTime fecha = DateTime.Now;
            DateTime fechaNueva = fecha.AddMonths(1);


            using (var bd = new BodegaContext())
            {
                reporte = (from servicio in bd.ServicioAlojamiento
                           join bodega in bd.Bodegas
                           on servicio.IdBodega equals bodega.IdBodega
                           join cliente in bd.Cliente
                           on servicio.IdCliente equals cliente.IdCliente
                           join categoria in bd.Categoria
                           on bodega.IdBodega equals categoria.IdBodega
                           join producto in bd.Producto
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
            }

            return reporte;
        }

        public Servicio ConsultarServiciosPorId(int idServicio)
        {
            Servicio listaServicios = null;
            using (var bd = new BodegaContext())
            {
                listaServicios = (from servicio in bd.ServicioAlojamiento
                                  join bodega in bd.Bodegas
                                  on servicio.IdBodega equals bodega.IdBodega
                                  join cliente in bd.Cliente
                                  on servicio.IdCliente equals cliente.IdCliente
                                  where servicio.IdServicio == idServicio
                                  select new Servicio
                                  {
                                      IdServicio = (int)servicio.IdServicio,
                                      NombreServicio = servicio.NombreServicio,
                                      IdCliente = (int)servicio.IdCliente,
                                      IdBodega = (int)servicio.IdBodega,
                                  }).FirstOrDefault();
            }

            return listaServicios;
        }
    }
}