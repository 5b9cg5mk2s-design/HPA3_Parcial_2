using System;

namespace Entidades
{
    public class E_Usuario
    {
        public int id { get; set; }
        public string dsId { get; set; }
        public string dsUsuario { get; set; }
        public byte[] dsPassword { get; set; } // Tipo byte[] ya que en BD es varbinary
        public char dsEstado { get; set; }
        public string dsUsuarioCreacion { get; set; }
        public DateTime dtFechaCreacion { get; set; }
        public string dsUsuarioModificacion { get; set; }
        public DateTime dtFechaModificacion { get; set; }
    }
}
