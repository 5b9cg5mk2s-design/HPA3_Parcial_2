using System.Collections.Generic;
using Entidades;
using Datos;

namespace Negocios
{
    public class N_Producto
    {
        public static List<E_Producto> ListarProductos()
        {
            return D_Productos.ObtenerProductos();
        }
    }
}

