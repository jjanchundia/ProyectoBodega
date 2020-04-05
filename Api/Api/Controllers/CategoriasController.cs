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
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoria _repo;
        public CategoriasController(ICategoria repo)
        {
            _repo = repo;
        }

        private Categorias PrepareCategoria(CategoriaModel model)
        {
            var oCategoria = new Categorias();
            oCategoria.IdBodega = model.IdBodega;
            oCategoria.IdCategoria = model.IdCategoria;
            oCategoria.Nombre = model.Nombre;
            oCategoria.Descripcion = model.Descripcion;

            return oCategoria;
        }

        [HttpPost]
        [Route("actualizarcategoria/")]
        public ActionResult ActualizarCategoria(CategoriaModel model)
        {
            _repo.ActualizarCategoria(PrepareCategoria(model));
            return Ok();
        }

        [HttpPost]
        public ActionResult Guardarcategoria(CategoriaModel model)
        {
            _repo.GuardarCategoria(PrepareCategoria(model));
            return Ok();
        }

        [HttpGet]
        public ActionResult Consultarcategorias()
        {
            return Ok(_repo.ConsultarCategoria());
        }

        [HttpGet]
        [Route("consultarcategoriaporid/{idcategoria}")]
        public ActionResult ConsultarCategoriaPorId(int idcategoria)
        {
            return Ok(_repo.ConsultarCategoriaPorId(idcategoria));
        }

        [HttpGet]
        [Route("consultarcategoriapornombres/{nombres}")]
        public ActionResult ConsultarCategoriaPorNombres(string nombres)
        {
            return Ok(_repo.ConsultarCategoriaPorNombres(nombres));
        }

        [HttpGet]
        [Route("eliminarcategoria/{idCategoria}")]
        public ActionResult EliminarCatagoria(int idCategoria)
        {
            _repo.EliminarCategoria(idCategoria);
            return Ok();
        }

        [HttpGet]
        [Route("consultarcategorias")]
        public List<SelectListItem> ListaCategorias()
        {
            return _repo.ListaCategoria(); ;
        }
    }
}