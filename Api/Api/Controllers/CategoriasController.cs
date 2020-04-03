using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models;
using DAO.DAO;
using DAO.Datos;
using Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        CategoriaDAO categoria = new CategoriaDAO();
        Categorias oCategoria = new Categorias();

        [HttpPost]
        [Route("actualizarcategoria/")]
        public ActionResult ActualizarCategoria(CategoriaModel model)
        {
            oCategoria.IdCategoria = model.IdCategoria;
            oCategoria.IdBodega = model.IdBodega;
            oCategoria.Nombre = model.Nombre;
            oCategoria.Descripcion = model.Descripcion;

            categoria.ActualizarCategoria(oCategoria);

            return Ok("Exito Actualizado");
        }

        [HttpPost]
        public ActionResult Guardarcategoria(CategoriaModel model)
        {
            oCategoria.IdBodega = model.IdBodega;
            oCategoria.Nombre = model.Nombre;
            oCategoria.Descripcion = model.Descripcion;

            categoria.GuardarCategoria(oCategoria);

            return Ok("Exito");
        }

        [HttpGet]
        public ActionResult Consultarcategorias()
        {
            return Ok(categoria.ConsultarCategoria());
        }

        [HttpGet]
        [Route("consultarcategoriaporid/{idcategoria}")]
        public ActionResult ConsultarCategoriaPorId(int idcategoria)
        {
            return Ok(categoria.ConsultarCategoriaPorId(idcategoria));
        }

        [HttpGet]
        [Route("consultarcategoriapornombres/{nombres}")]
        public ActionResult ConsultarCategoriaPorNombres(string nombres)
        {
            return Ok(categoria.ConsultarCategoriaPorNombres(nombres));
        }

        [HttpGet]
        [Route("eliminarcategoria/{idCategoria}")]
        public ActionResult EliminarCatagoria(int idCategoria)
        {
            categoria.EliminarCategoria(idCategoria);
            return Ok("Exito");
        }

        [HttpGet]
        [Route("consultarcategorias")]
        public List<SelectListItem> ListaCategorias()
        {
            return categoria.ListaCategoria(); ;
        }
    }
}