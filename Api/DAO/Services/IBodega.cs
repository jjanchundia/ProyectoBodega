using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Entidades;

namespace DAO.Services
{
    public interface IBodega
    {
        void GuardarBodega(Entidades.Bodega model);
        void ActualizarBodega(Bodega model);
        void EliminarBodega(int idBodega);
        List<Bodega> ConsultarBodegas();
        List<SelectListItem> ListaBodega();
        List<Bodega> ConsultarBodegaPorNombres(string nombre);
        Bodega ConsultarBodegaPorId(int idBodega);
    }
}
