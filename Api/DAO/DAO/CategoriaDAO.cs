using DAO.Datos;
using Entidades;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using DAO.Services;

namespace DAO.DAO
{
    public class CategoriaDAO: ICategoria
    {
        protected readonly BodegaContext _context;
        public CategoriaDAO(BodegaContext context)
        {
            _context = context;
        }

        public void GuardarCategoria(Categorias model)
        {
            try
            {
                var categoria = new Categoria();

                categoria.Nombre = model.Nombre;
                categoria.Descripcion = model.Descripcion;
                categoria.IdBodega = model.IdBodega;
                categoria.Estado = 1;

                _context.Categoria.Add(categoria);
                _context.SaveChanges();
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public void ActualizarCategoria(Categorias model)
        {
            try
            {
                Categoria categoria = _context.Categoria.Where(i => i.IdCategoria == model.IdCategoria).FirstOrDefault();
                categoria.Nombre = model.Nombre;
                categoria.Descripcion = model.Descripcion;
                categoria.IdBodega = model.IdBodega;

                _context.SaveChanges();
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public List<Categorias> ConsultarCategoria()
        {
            List<Categorias> listaCategoria = null;

            listaCategoria = (from categoria in _context.Categoria
                              join bodega in _context.Bodegas
                              on categoria.IdBodega equals bodega.IdBodega
                              where categoria.Estado == 1
                              select new Categorias
                              {
                                  IdCategoria = categoria.IdCategoria,
                                  IdBodega = (int)categoria.IdBodega,
                                  Nombre = categoria.Nombre,
                                  Descripcion = categoria.Descripcion,
                                  BodegaNombre = bodega.Nombre,
                                  Estado = (int)categoria.Estado
                              }).ToList();

            return listaCategoria;
        }

        public List<Categorias> ConsultarCategoriaPorNombres(string nombre)
        {
            List<Categorias> listaCategoria = null;

            listaCategoria = (from categoria in _context.Categoria
                              join bodega in _context.Bodegas
                              on categoria.IdBodega equals bodega.IdBodega
                              where categoria.Nombre.Contains(nombre)
                              select new Categorias
                              {
                                  IdCategoria = categoria.IdCategoria,
                                  IdBodega = (int)categoria.IdBodega,
                                  Nombre = categoria.Nombre,
                                  Descripcion = categoria.Descripcion,
                                  BodegaNombre = bodega.Nombre,
                                  Estado = (int)categoria.Estado
                              }).ToList();

            return listaCategoria;
        }

        public void EliminarCategoria(int idCategoria)
        {
            try
            {

                Categoria categoria = _context.Categoria.Where(i => i.IdCategoria == idCategoria).FirstOrDefault();
                categoria.Estado = 0;

                _context.SaveChanges();

            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public Categorias ConsultarCategoriaPorId(int idCategoria)
        {
            Categorias listaBodega = null;
            
                listaBodega = (from categoria in _context.Categoria
                               join bodega in _context.Bodegas
                               on categoria.IdBodega equals bodega.IdBodega
                               where categoria.IdCategoria == idCategoria
                               && categoria.Estado == 1
                               select new Categorias
                               {
                                   IdBodega = (int)categoria.IdBodega,
                                   IdCategoria = categoria.IdCategoria,
                                   Nombre = categoria.Nombre,
                                   Descripcion = categoria.Descripcion,
                                   BodegaNombre = bodega.Nombre,
                                   Estado = (int)categoria.Estado
                               }).FirstOrDefault();

            
            return listaBodega;
        }

        public List<Categorias> ConsultarCategoriaBodega()
        {
            List<Categorias> listaBodega = null;

            listaBodega = (from categoria in _context.Categoria
                           join bodega in _context.Bodegas
                           on categoria.IdCategoria equals bodega.IdBodega
                           where categoria.Estado == 1
                           select new Categorias
                           {
                               IdBodega = (int)categoria.IdBodega,
                               IdCategoria = categoria.IdCategoria,
                               Nombre = categoria.Nombre,
                               Descripcion = categoria.Descripcion,
                               Estado = (int)categoria.Estado
                           }).ToList();

            return listaBodega;
        }

        public List<SelectListItem> ListaCategoria()
        {
            var categorias = (from categoria in _context.Categoria
                              select new SelectListItem
                              {
                                  Text = categoria.Nombre,
                                  Value = categoria.IdCategoria.ToString()
                              }).ToList();
            categorias.Insert(0, new SelectListItem { Text = "--Seleccione--", Value = "" });
            
            dynamic ViewBag = categorias;
         
            return ViewBag;
        }
    }
}