using System;
using Api.Models;
using DAO.DAO;
using Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BodegasController : ControllerBase
    {
        BodegaDAO Bodega = new BodegaDAO();
        Bodega oBodega = new Bodega();

        [HttpPost]
        [Route("actualizarbodega/")]
        public ActionResult ActualizarBodega(BodegaModel model)
        {
            try
            {
                oBodega.IdBodega = model.IdBodega;
                oBodega.Nombre = model.Nombre;
                oBodega.Descripcion = model.Descripcion;

                Bodega.ActualizarBodega(oBodega);
            }
            catch (Exception e)
            {
                throw e;
            }
            return Ok("Exito Actualizado");
        }

        [HttpPost]
        [Route("eliminarbodegas/{idBodega}")]
        public ActionResult EliminarBodega(int idBodega)
        {
            Bodega.EliminarBodega(idBodega);
            return Ok();
        }


        [HttpPost]
        public ActionResult GuardarBodega(BodegaModel model)
        {
            try
            {
                oBodega.IdBodega = model.IdBodega;
                oBodega.Nombre = model.Nombre;
                oBodega.Descripcion = model.Descripcion;

                Bodega.GuardarBodega(oBodega);
            }
            catch (Exception e)
            {
                throw e;
            }
            return Ok("Exito");
        }

        [HttpGet]
        public ActionResult ConsultarBodegas()
        {
            return Ok(Bodega.ConsultarBodegas());
        }

        [HttpGet]
        [Route("consultarbodegaporid/{idBodega}")]
        public ActionResult ConsultarBodegaPorId(int idBodega)
        {
            return Ok(Bodega.ConsultarBodegaPorId(idBodega));
        }

        [HttpGet]
        [Route("consultarbodegapornombres/{nombres}")]
        public ActionResult ConsultarBodegaPorNombres(string nombres)
        {
            return Ok(Bodega.ConsultarBodegaPorNombres(nombres));
        }
    }
}