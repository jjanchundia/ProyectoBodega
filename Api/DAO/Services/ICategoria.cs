using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DAO.Services
{
    public interface ICategoria
    {
        void GuardarCategoria(Categorias model);
        void ActualizarCategoria(Categorias model);
        List<Categorias> ConsultarCategoria();
        List<Categorias> ConsultarCategoriaPorNombres(string nombre);
        void EliminarCategoria(int idCategoria);
        Categorias ConsultarCategoriaPorId(int idCategoria);
        List<Categorias> ConsultarCategoriaBodega();
        List<SelectListItem> ListaCategoria();
    }
}
