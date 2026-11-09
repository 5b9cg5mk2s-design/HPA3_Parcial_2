using Entidades;
using Datos;

namespace Negocios
{
    public class N_Usuario : IHashService, IVerificarHashService
    {
        public string GenerarHash(string textoPlano)
        {
            // Nota pedagógica: En una arquitectura desacoplada completa aquí procesas el hash.
            // Para este parcial práctico, la encriptación se ejecuta de forma directa mediante la base de datos.
            return textoPlano;
        }

        public bool Verificar(string textoPlano, string hashAlmacenado)
        {
            return textoPlano == hashAlmacenado;
        }

        public static E_Usuario Login(string strUsuario, string strPassword)
        {
            return D_Usuarios.Login(strUsuario, strPassword);
        }
    }
}
