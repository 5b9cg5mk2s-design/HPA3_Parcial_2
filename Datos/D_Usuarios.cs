using System;
using System.Data;
using MySql.Data.MySqlClient;
using Entidades;

namespace Datos
{
    public class D_Usuarios : D_conexion
    {
        public static E_Usuario Login(string strUsuario, string strPassword)
        {
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    using (MySqlCommand cmd = new MySqlCommand("sp_ValidarLoginHash", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Limpiamos parámetros previos por si acaso
                        cmd.Parameters.Clear();

                        // Agregamos los parámetros tal cual los espera el procedimiento almacenado
                        cmd.Parameters.Add("_dsUsuario", MySqlDbType.VarChar, 50).Value = strUsuario;
                        cmd.Parameters.Add("_dsPassword", MySqlDbType.VarChar, 50).Value = strPassword;

                        using (MySqlDataReader fReader = cmd.ExecuteReader())
                        {
                            // Cambiamos a 'if' porque solo esperamos un único usuario correcto
                            if (fReader.Read())
                            {
                                E_Usuario usuario = new E_Usuario();

                                // Mapeamos las columnas respetando las minúsculas y mayúsculas de tu consulta exitosa
                                usuario.id = fReader.GetInt32("id");
                                usuario.dsUsuario = fReader.GetString("dsUsuario");

                                return usuario; // Retorna el usuario logueado exitosamente
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Si ocurre un error inesperado de conexión o conversión, puedes inspeccionar 'ex.Message' al depurar
                return null;
            }
            return null; // Si no encontró filas, las credenciales no coinciden en C#
        }
    }
}
