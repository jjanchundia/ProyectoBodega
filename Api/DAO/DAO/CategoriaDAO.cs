using DAO.Datos;
using Entidades;
using System.Collections.Generic;
using System.Linq;

namespace DAO.DAO
{
    public class CategoriaDAO
    {
        public void GuardarCategoria(Categorias model)
        {
            try
            {
                using (BodegaContext bd = new BodegaContext())
                {
                    var categoria = new Categoria();
                    categoria.Nombre = model.Nombre;
                    categoria.Descripcion = model.Descripcion;
                    categoria.IdBodega = model.IdBodega;
                    categoria.Estado = 1;

                    bd.Categoria.Add(categoria);
                    bd.SaveChanges();
                }
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
                using (BodegaContext bd = new BodegaContext())
                {
                    Categoria categoria = bd.Categoria.Where(i => i.IdCategoria == model.IdCategoria).FirstOrDefault();
                    categoria.Nombre = model.Nombre;
                    categoria.Descripcion = model.Descripcion;
                    categoria.IdBodega = model.IdBodega;

                    bd.SaveChanges();
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public List<Categorias> ConsultarCategoria()
        {
            List<Categorias> listaCategoria = null;
            using (var bd = new BodegaContext())
            {
                listaCategoria = (from categoria in bd.Categoria
                                  join bodega in bd.Bodegas
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
            }

            return listaCategoria;
        }

        public List<Categorias> ConsultarCategoriaPorNombres(string nombre)
        {
            List<Categorias> listaCategoria = null;
            using (var bd = new BodegaContext())
            {
                listaCategoria = (from categoria in bd.Categoria
                                  join bodega in bd.Bodegas
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
            }

            return listaCategoria;
        }

        public void EliminarCategoria(int idCategoria)
        {
            try
            {
                using (BodegaContext bd = new BodegaContext())
                {
                    Categoria categoria = bd.Categoria.Where(i => i.IdCategoria == idCategoria).FirstOrDefault();
                    categoria.Estado = 0;

                    bd.SaveChanges();
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public Categorias ConsultarCategoriaPorId(int idCategoria)
        {
            Categorias listaBodega = null;
            using (var bd = new BodegaContext())
            {
                listaBodega = (from categoria in bd.Categoria
                               join bodega in bd.Bodegas
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

            }

            return listaBodega;
        }

        public List<Categorias> ConsultarCategoriaBodega()
        {
            List<Categorias> listaBodega = null;
            using (var bd = new BodegaContext())
            {
                listaBodega = (from categoria in bd.Categoria
                               join bodega in bd.Bodegas
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
            }

            return listaBodega;
        }
    }
}