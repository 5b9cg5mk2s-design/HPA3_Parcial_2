using System;
using System.Windows.Forms;
using Entidades;

namespace Presentacion
{
    public partial class frmPrincipal : Form
    {
        private E_Usuario _usuarioLogueado;
        public frmPrincipal(E_Usuario usuario)
        {
            InitializeComponent();
            _usuarioLogueado = usuario;
            //this.IsMdiContainer = true; // Activa el comportamiento MDI requerido
            //CargarDatosSesion();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            // 1. Cargar la información del usuario en la parte baja del menú izquierdo
            if (_usuarioLogueado != null)
            {
                lblSesionUsuario.Text = $"Usuario: {_usuarioLogueado.dsUsuario}\nConectado";
            }
            else
            {
                lblSesionUsuario.Text = "Usuario: Temporal\nSin iniciar";
            }

            // 2. Iniciar reloj y colocar fecha inicial en grande en el panel derecho
            ActualizarFechaYHora();
            timerHora.Start();
        }

        /*private void CargarDatosSesion()
        {
            // Muestra en la parte inferior los datos del usuario que inició sesión
            lblSesionUsuario.Text = $"Sesión activa: {_usuarioLogueado.dsUsuario} (ID: {_usuarioLogueado.id})";
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }*/

        private void timerHora_Tick(object sender, EventArgs e)
        {
            // El timer se ejecuta cada 1 segundo (Interval = 1000) actualizando la interfaz
            ActualizarFechaYHora();
        }

        private void ActualizarFechaYHora()
        {
            // Formato de hora digital gigante (Ej: 06:46:14 pm)
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss tt");

            // Formato de fecha larga centrada (Ej: domingo, 21 de enero de 2018)
            // Usamos "es-PA" o la cultura del sistema para asegurar que salga en español
            lblFecha.Text = DateTime.Now.ToString("dddd, d 'de' MMMM 'de' yyyy");
        }

        private void frmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Finaliza la aplicación al cerrar la ventana principal
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Módulo de Productos en desarrollo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Módulo de Ventas en desarrollo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
