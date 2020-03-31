using DAO.Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DAO.DAO
{
    public class BodegaDAO
    {
        public void GuardarBodega(Bodega model)
        {
            try
            {
                using (BodegaContext bd = new BodegaContext())
                {
                    var bodega = new Bodegas();
                    bodega.Nombre = model.Nombre;
                    bodega.Descripcion = model.Descripcion;
                    bodega.Estado = 1;

                    bd.Bodegas.Add(bodega);
                    bd.SaveChanges();
                }
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
                using (BodegaContext bd = new BodegaContext())
                {
                    Bodegas bodega = bd.Bodegas.Where(i => i.IdBodega == model.IdBodega).FirstOrDefault();
                    bodega.Nombre = model.Nombre;
                    bodega.Descripcion = model.Descripcion;

                    bd.SaveChanges();
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }


        public void EliminarBodega(int idBodega)
        {
            try
            {
                using (BodegaContext bd = new BodegaContext())
                {
                    Bodegas bodega = bd.Bodegas.Where(i => i.IdBodega == idBodega).FirstOrDefault();
                    bodega.Estado = 0;

                    bd.SaveChanges();
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
        public List<Bodega> ConsultarBodegas()
        {
            List<Bodega> listaBodegas = null;
            using (var bd = new BodegaContext())
            {
                listaBodegas = (from bodega in bd.Bodegas
                                where bodega.Estado == 1
                                select new Bodega
                                {
                                    IdBodega = bodega.IdBodega,
                                    Nombre = bodega.Nombre,
                                    Descripcion = bodega.Descripcion,
                                    Estado = (int)bodega.Estado
                                }).ToList();

            }

            return listaBodegas;
        }

        public List<Bodega> ConsultarBodegaPorNombres(string nombre)
        {
            List<Bodega> listaBodegas = null;
            using (var bd = new BodegaContext())
            {
                listaBodegas = (from bodega in bd.Bodegas
                                where bodega.Nombre.Contains(nombre)
                                && bodega.Estado == 1
                                select new Bodega
                                {
                                    IdBodega = bodega.IdBodega,
                                    Nombre = bodega.Nombre,
                                    Descripcion = bodega.Descripcion,
                                    Estado = (int)bodega.Estado
                                }).ToList();

            }

            return listaBodegas;
        }

        public Bodega ConsultarBodegaPorId(int idBodega)
        {
            Bodega listaBodega = null;
            using (var bd = new BodegaContext())
            {
                listaBodega = (from bodega in bd.Bodegas
                               where bodega.IdBodega == idBodega
                               && bodega.Estado == 1
                               select new Bodega
                               {
                                   IdBodega = bodega.IdBodega,
                                   Nombre = bodega.Nombre,
                                   Descripcion = bodega.Descripcion,
                               }).FirstOrDefault();

            }

            return listaBodega;
        }
    }
}