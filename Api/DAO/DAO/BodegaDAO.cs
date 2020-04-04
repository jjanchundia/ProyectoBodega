using DAO.Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using DAO.Services;

namespace DAO.DAO
{
    public class BodegaDAO : IBodega
    {
        protected readonly BodegaContext _context;
        public BodegaDAO(BodegaContext context)
        {
            _context = context;
        }

        public void GuardarBodega(Bodega model)
        {
            try
            {
                var bodega = new Bodegas();

                bodega.Nombre = model.Nombre;
                bodega.Descripcion = model.Descripcion;
                bodega.Estado = 1;

                _context.Bodegas.Add(bodega);
                _context.SaveChanges();

            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public void ActualizarBodega(Bodega model)
        {
            try
            {
                Bodegas bodega = _context.Bodegas.Where(i => i.IdBodega == model.IdBodega).FirstOrDefault();
                bodega.Nombre = model.Nombre;
                bodega.Descripcion = model.Descripcion;

                _context.SaveChanges();

            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public void EliminarBodega(int idBodega)
        {
            try
            {
                Bodegas bodega = _context.Bodegas.Where(i => i.IdBodega == idBodega).FirstOrDefault();
                bodega.Estado = 0;

                _context.SaveChanges();

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<Bodega> ConsultarBodegas()
        {
            List<Bodega> listaBodegas = null;

            listaBodegas = (from bodega in _context.Bodegas
                            where bodega.Estado == 1
                            select new Bodega
                            {
                                IdBodega = bodega.IdBodega,
                                Nombre = bodega.Nombre,
                                Descripcion = bodega.Descripcion,
                                Estado = (int)bodega.Estado
                            }).ToList();

            return listaBodegas;
        }

        public List<SelectListItem> ListaBodega()
        {
            var bodegas = (from bodega in _context.Bodegas
                           where bodega.Estado == 1
                           select new SelectListItem
                           {
                               Text = bodega.Nombre,
                               Value = bodega.IdBodega.ToString()
                           }).ToList();
            bodegas.Insert(0, new SelectListItem { Text = "--Seleccione--", Value = "" });
            dynamic ViewBag = bodegas;
            return ViewBag;

        }

        public List<Bodega> ConsultarBodegaPorNombres(string nombre)
        {
            List<Bodega> listaBodegas = null;

            listaBodegas = (from bodega in _context.Bodegas
                            where bodega.Nombre.Contains(nombre)
                            && bodega.Estado == 1
                            select new Bodega
                            {
                                IdBodega = bodega.IdBodega,
                                Nombre = bodega.Nombre,
                                Descripcion = bodega.Descripcion,
                                Estado = (int)bodega.Estado
                            }).ToList();
         
            return listaBodegas;
        }

        public Bodega ConsultarBodegaPorId(int idBodega)
        {
            Bodega listaBodega = null;
            
                listaBodega = (from bodega in _context.Bodegas
                               where bodega.IdBodega == idBodega
                               && bodega.Estado == 1
                               select new Bodega
                               {
                                   IdBodega = bodega.IdBodega,
                                   Nombre = bodega.Nombre,
                                   Descripcion = bodega.Descripcion,
                               }).FirstOrDefault();

            return listaBodega;
        }
    }
}