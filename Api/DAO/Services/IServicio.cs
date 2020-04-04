using System;
using System.Collections.Generic;
using Entidades;
namespace DAO.Services
{
    public interface IServicio
    {
        void GuardarServicio(Servicio model);
        void ActualizarServicio(Servicio model);
        List<Servicio> ConsultarServicios();
        List<Servicio> ConsultarServicioPorNombres(string nombres);
        Servicio ConsultarReporte(int idCliente, DateTime fecha);
        List<Productos> ConsultarProductos(int idCliente);
        Servicio ConsultarServiciosPorId(int idServicio);
    }
}