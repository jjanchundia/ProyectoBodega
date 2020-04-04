using System.Collections.Generic;
using Api.Models;
using Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using DAO.Services;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BodegasController : ControllerBase
    {
        private readonly IBodega _repo;
        public BodegasController(IBodega repo)
        {
            _repo = repo;
        }
     
        private Bodega PrepareBodega(BodegaModel model)
        {
            var oBodega = new Bodega();
            oBodega.IdBodega = model.IdBodega;
            oBodega.Nombre = model.Nombre;
            oBodega.Descripcion = model.Descripcion;

            return oBodega;
        }

        [HttpPost]
        [Route("actualizarbodega/")]
        public ActionResult ActualizarBodega(BodegaModel model)
        {
            _repo.ActualizarBodega(PrepareBodega(model));
            return Ok("Exito Actualizado");
        }

        [HttpGet]
        [Route("eliminarbodegas/{idBodega}")]
        public ActionResult EliminarBodega(int idBodega)
        {
            _repo.EliminarBodega(idBodega);
            return Ok();
        }


        [HttpPost]
        public ActionResult GuardarBodega(BodegaModel model)
        {
            _repo.GuardarBodega(PrepareBodega(model));
            return Ok("Exito");
        }

        [HttpGet]
        public ActionResult ConsultarBodegas()
        {
            return Ok(_repo.ConsultarBodegas());
        }

        [HttpGet]
        [Route("consultarbodegaporid/{idBodega}")]
        public ActionResult ConsultarBodegaPorId(int idBodega)
        {
            return Ok(_repo.ConsultarBodegaPorId(idBodega));
        }

        [HttpGet]
        [Route("consultarbodegapornombres/{nombres}")]
        public ActionResult ConsultarBodegaPorNombres(string nombres)
        {
            return Ok(_repo.ConsultarBodegaPorNombres(nombres));
        }

        [HttpGet]
        [Route("consultarbodegas")]
        public List<SelectListItem> ListaBodega()
        {
            List<SelectListItem>  listaBodegas = _repo.ListaBodega();
            return listaBodegas;            
        }
    }
}