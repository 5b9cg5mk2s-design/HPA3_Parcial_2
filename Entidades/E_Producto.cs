using System;

namespace Entidades
{
    public class E_Producto
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public decimal precio { get; set; }
        public int cantidad { get; set; }
        public string usuario { get; set; }
        public DateTime fecha_creacion { get; set; }
    }
}
