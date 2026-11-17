using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Entidades;

namespace Presentacion
{
    public partial class frmProductos : Form, IProductosView
    {
        private readonly ProductosPresenter _presenter;
        public frmProductos()
        {
            InitializeComponent();
            _presenter = new ProductosPresenter(this);
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            _presenter.CargarListaProductos();
        }

        public void MostrarProductos(List<E_Producto> productos)
        {
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = productos;

            // Personalizar los encabezados de las columnas
            if (dgvProductos.Columns["id"] != null) dgvProductos.Columns["id"].HeaderText = "ID";
            if (dgvProductos.Columns["nombre"] != null) dgvProductos.Columns["nombre"].HeaderText = "Producto";
            if (dgvProductos.Columns["precio"] != null)
            {
                dgvProductos.Columns["precio"].HeaderText = "Precio ($)";
                dgvProductos.Columns["precio"].DefaultCellStyle.Format = "C2"; // Formato moneda
            }
            if (dgvProductos.Columns["cantidad"] != null) dgvProductos.Columns["cantidad"].HeaderText = "Cantidad";
            if (dgvProductos.Columns["usuario"] != null) dgvProductos.Columns["usuario"].HeaderText = "Registrado por";
            if (dgvProductos.Columns["fecha_creacion"] != null) dgvProductos.Columns["fecha_creacion"].HeaderText = "Fecha de Registro";
        }
    }
}
