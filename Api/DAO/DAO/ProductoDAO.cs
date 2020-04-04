using DAO.Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using DAO.Services;

namespace DAO.DAO
{
    public class ProductoDAO:IProducto
    {
        protected readonly BodegaContext _context;
        public ProductoDAO(BodegaContext context)
        {
            _context = context;
        }

        public void GuardarProducto(Productos model)
        {
            try
            {
                Producto producto = new Producto();

                producto.IdCategoria = model.IdCategoria;
                producto.Nombre = model.Nombre;
                producto.Descripcion = model.Descripcion;
                producto.FechaExpiracion = model.FechaExpiracion;
                producto.Estado = 1;

                _context.Producto.Add(producto);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void ActualizarProducto(Productos model)
        {
            try
            {
                Producto producto = _context.Producto.Where(i => i.IdProducto == model.IdProducto).FirstOrDefault();
                producto.IdCategoria = model.IdCategoria;
                producto.Nombre = model.Nombre;
                producto.Descripcion = model.Descripcion;
                producto.FechaExpiracion = model.FechaExpiracion;

                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void EliminarProducto(int idProducto)
        {
            try
            {
                Producto producto = _context.Producto.Where(i => i.IdProducto == idProducto).FirstOrDefault();
                producto.Estado = 0;

                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Productos> ConsultarProductos()
        {
            List<Productos> listaProductos = null;

            listaProductos = (from producto in _context.Producto
                              join categoria in _context.Categoria
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

            return listaProductos;
        }

        public List<Productos> ConsultarProductoPorNombres(string nombres)
        {
            List<Productos> listaProductos = null;

            listaProductos = (from producto in _context.Producto
                              join categoria in _context.Categoria
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

            return listaProductos;
        }

        public Productos ConsultarProductosPorId(int idProducto)
        {
            Productos listaProductos = null;

            listaProductos = (from producto in _context.Producto
                              join categoria in _context.Categoria
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

            return listaProductos;
        }
    }
}