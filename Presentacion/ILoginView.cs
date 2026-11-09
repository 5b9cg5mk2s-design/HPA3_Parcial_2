using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion
{
    public interface ILoginView
    {
        string Usuario { get; }
        string Password { get; }
        void MostrarMensajeExitoso(string mensaje);
        void MostrarMensajeError(string mensaje);
        void OcultarVista();
    }
}

