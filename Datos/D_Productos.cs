using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Entidades;

namespace Datos
{
    public class D_Productos : D_conexion
    {
        public static List<E_Producto> ObtenerProductos()
        {
            List<E_Producto> lista = new List<E_Producto>();

            try
            {
                using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    string query = "SELECT id, nombre, precio, cantidad, usuario, fecha_creacion FROM productos WHERE anulado = 0";

                    using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                E_Producto prod = new E_Producto
                                {
                                    id = reader.GetInt32("id"),
                                    nombre = reader.GetString("nombre"),
                                    precio = reader.GetDecimal("precio"),
                                    cantidad = reader.GetInt32("cantidad"),
                                    usuario = reader.IsDBNull(reader.GetOrdinal("usuario")) ? "" : reader.GetString("usuario"),
                                    fecha_creacion = reader.GetDateTime("fecha_creacion")
                                };
                                lista.Add(prod);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                // Retorna la lista vacía en caso de error
            }

            return lista;
        }
    }
}

