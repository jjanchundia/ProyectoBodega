using DAO.Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAO.DAO
{
    public class ProductoDAO
    {
        public void GuardarProducto(Productos model)
        {
            try
            {
                using (BodegaContext bd = new BodegaContext())
                {
                    Producto producto = new Producto();
                    producto.IdCategoria = model.IdCategoria;
                    producto.Nombre = model.Nombre;
                    producto.Descripcion = model.Descripcion;
                    producto.FechaExpiracion = model.FechaExpiracion;
                    producto.Estado = 1;

                    bd.Producto.Add(producto);
                    bd.SaveChanges();
                }
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void ActualizarProducto(Productos model)
        {
            try
            {
                using (BodegaContext bd = new BodegaContext())
                {
                    Producto producto = bd.Producto.Where(i => i.IdProducto == model.IdProducto).FirstOrDefault();
                    producto.IdCategoria = model.IdCategoria;
                    producto.Nombre = model.Nombre;
                    producto.Descripcion = model.Descripcion;
                    producto.FechaExpiracion = model.FechaExpiracion;

                    bd.SaveChanges();
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public void EliminarProducto(int idProducto)
        {
            try
            {
                using (BodegaContext bd = new BodegaContext())
                {
                    Producto producto = bd.Producto.Where(i => i.IdProducto == idProducto).FirstOrDefault();
                    producto.Estado = 0;

                    bd.SaveChanges();
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public List<Productos> ConsultarProductos()
        {
            List<Productos> listaProductos = null;
            using (var bd = new BodegaContext())
            {
                listaProductos = (from producto in bd.Producto
                                  join categoria in bd.Categoria
                                  on producto.IdCategoria equals categoria.IdCategoria
                                  orderby categoria.IdCategoria
                                  where producto.Estado == 1
                                  select new Productos
                                  {
                                      IdProducto = (int)producto.IdProducto,
                                      IdCategoria = (int)producto.IdCategoria,
                                      Nombre = producto.Nombre,
                                      Descripcion = producto.Descripcion,
                                      FechaExpiracion = (DateTime)producto.FechaExpiracion,
                                      NombreCategoria = categoria.Nombre
                                  }).ToList();

            }

            return listaProductos;
        }

        public List<Productos> ConsultarProductoPorNombres(string nombres)
        {
            List<Productos> listaProductos = null;
            using (var bd = new BodegaContext())
            {
                listaProductos = (from producto in bd.Producto
                                  join categoria in bd.Categoria
                                  on producto.IdCategoria equals categoria.IdCategoria
                                  where producto.Nombre.Contains(nombres)
                                  select new Productos
                                  {
                                      IdProducto = (int)producto.IdProducto,
                                      IdCategoria = (int)producto.IdCategoria,
                                      Nombre = producto.Nombre,
                                      Descripcion = producto.Descripcion,
                                      FechaExpiracion = (DateTime)producto.FechaExpiracion,
                                      NombreCategoria = categoria.Nombre
                                  }).ToList();

            }

            return listaProductos;
        }

        public Productos ConsultarProductosPorId(int idProducto)
        {
            Productos listaProductos = null;
            using (var bd = new BodegaContext())
            {
                listaProductos = (from producto in bd.Producto
                                  join categoria in bd.Categoria
                                  on producto.IdCategoria equals categoria.IdCategoria
                                  where producto.IdProducto == idProducto
                                  select new Productos
                                  {
                                      IdProducto = (int)producto.IdProducto,
                                      IdCategoria = (int)producto.IdCategoria,
                                      Nombre = producto.Nombre,
                                      Descripcion = producto.Descripcion,
                                      FechaExpiracion = (DateTime)producto.FechaExpiracion,
                                      NombreCategoria = categoria.Nombre
                                  }).FirstOrDefault();
            }

            return listaProductos;
        }
    }
}