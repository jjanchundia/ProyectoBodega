using System.Collections.Generic;
using Entidades;

namespace DAO.Services
{
    public interface IProducto
    {
        void GuardarProducto(Productos model);
        void ActualizarProducto(Productos model);
        void EliminarProducto(int idProducto);
        List<Productos> ConsultarProductos();
        List<Productos> ConsultarProductoPorNombres(string nombres);
        Productos ConsultarProductosPorId(int idProducto);
    }
}