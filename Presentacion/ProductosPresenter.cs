using System.Collections.Generic;
using Entidades;
using Negocios;

namespace Presentacion
{
    public class ProductosPresenter
    {
        private readonly IProductosView _vista;

        public ProductosPresenter(IProductosView vista)
        {
            _vista = vista;
        }

        public void CargarListaProductos()
        {
            List<E_Producto> lista = N_Producto.ListarProductos();
            _vista.MostrarProductos(lista);
        }
    }
}
