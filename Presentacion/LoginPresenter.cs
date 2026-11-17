using System;
using System.Text.RegularExpressions;
using Entidades;
using Negocios;

namespace Presentacion
{
    public class LoginPresenter
    {
        private readonly ILoginView _vista;

        public LoginPresenter(ILoginView vista)
        {
            _vista = vista;
        }

        public bool EjecutarLogin()
        {
            string user = _vista.Usuario;
            string pass = _vista.Password;

            // 1. Validación de campos vacíos
            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(pass))
            {
                _vista.MostrarMensajeError("Error: Todos los campos son obligatorios y no pueden contener solo espacios.");
                return false;
            }

            // 2. Validación de caracteres permitidos (Alfanumérico básico para evitar SQL Injection)
            if (!Regex.IsMatch(user, @"^[a-zA-Z0-9_]+$"))
            {
                _vista.MostrarMensajeError("Error: El nombre de usuario contiene caracteres no permitidos. Solo use letras, números o guiones bajos.");
                return false;
            }

            // 3. Validación de longitud mínima
            if (pass.Length < 4)
            {
                _vista.MostrarMensajeError("Error: La contraseña debe tener al menos 4 caracteres.");
                return false;
            }

            // Intento de Login si pasa las validaciones de interfaz
            E_Usuario usuario = N_Usuario.Login(user, pass);

            if (usuario != null && usuario.id > 0)
            {
                _vista.MostrarMensajeExitoso($"¡Bienvenido, {usuario.dsUsuario}!");
                _vista.OcultarVista();

                frmPrincipal principalForm = new frmPrincipal(usuario);
                principalForm.Show();
                return true;
            }
            else
            {
                _vista.MostrarMensajeError("Usuario o contraseña incorrectos.");
                return false;
            }
        }
    }
}


