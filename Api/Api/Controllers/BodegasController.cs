using System;
using System.Collections.Generic;
using Api.Models;
using DAO.DAO;
using Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            oBodega.IdBodega = model.IdBodega;
            oBodega.Nombre = model.Nombre;
            oBodega.Descripcion = model.Descripcion;

            Bodega.ActualizarBodega(oBodega);

            return Ok("Exito Actualizado");
        }

        [HttpGet]
        [Route("eliminarbodegas/{idBodega}")]
        public ActionResult EliminarBodega(int idBodega)
        {
            Bodega.EliminarBodega(idBodega);
            return Ok();
        }


        [HttpPost]
        public ActionResult GuardarBodega(BodegaModel model)
        {
            oBodega.IdBodega = model.IdBodega;
            oBodega.Nombre = model.Nombre;
            oBodega.Descripcion = model.Descripcion;

            Bodega.GuardarBodega(oBodega);

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

        [HttpGet]
        [Route("consultarbodegas")]
        public List<SelectListItem> ListaBodega()
        {
            List<SelectListItem>  listaBodegas = Bodega.ListaBodega();
            return listaBodegas;            
        }
    }
}