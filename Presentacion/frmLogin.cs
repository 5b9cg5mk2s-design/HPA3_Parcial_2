using System;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmLogin : Form, ILoginView
    {
        private readonly LoginPresenter _presenter;
        public frmLogin()
        {
            InitializeComponent();
            _presenter = new LoginPresenter(this);
            // Configurar máscara de contraseña
            txtPassword.UseSystemPasswordChar = true;
        }

        public string Usuario => txtUsuario.Text.Trim();
        public string Password => txtPassword.Text.Trim();

        public void MostrarMensajeExitoso(string mensaje)
        {
            MessageBox.Show(mensaje, "Login Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void MostrarMensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Error de Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void OcultarVista()
        {
            this.Hide();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            _presenter.EjecutarLogin();
        }

        private void labelX_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
