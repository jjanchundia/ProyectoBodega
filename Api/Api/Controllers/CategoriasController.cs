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
            try
            {
                oCategoria.IdCategoria = model.IdCategoria;
                oCategoria.IdBodega = model.IdBodega;
                oCategoria.Nombre = model.Nombre;
                oCategoria.Descripcion = model.Descripcion;

                categoria.ActualizarCategoria(oCategoria);
            }
            catch (Exception e)
            {
                throw e;
            }
            return Ok("Exito Actualizado");
        }

        [HttpPost]
        public ActionResult Guardarcategoria(CategoriaModel model)
        {
            try
            {
                oCategoria.IdBodega = model.IdBodega;
                oCategoria.Nombre = model.Nombre;
                oCategoria.Descripcion = model.Descripcion;

                categoria.GuardarCategoria(oCategoria);
            }
            catch (Exception e)
            {
                throw e;
            }
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
        [Route("consultarbodegas")]
        public List<SelectListItem> ListaBodega()
        {
            using (var bd = new BodegaContext())
            {
                var bodegas = (from bodega in bd.Bodegas
                               select new SelectListItem
                               {
                                   Text = bodega.Nombre,
                                   Value = bodega.IdBodega.ToString()
                               }).ToList();
                bodegas.Insert(0, new SelectListItem { Text = "--Seleccione--", Value = "" });
                dynamic ViewBag = bodegas;
                return ViewBag;
            }
        }
    }
}