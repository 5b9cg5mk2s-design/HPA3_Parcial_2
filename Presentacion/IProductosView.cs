using System.Collections.Generic;
using Entidades;

namespace Presentacion
{
    public interface IProductosView
    {
        void MostrarProductos(List<E_Producto> productos);
    }
}

