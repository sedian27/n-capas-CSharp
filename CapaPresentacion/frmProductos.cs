using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class frmProductos : Form
    {
        ProductoCN p = new ProductoCN();

        // Funciones:

        public void actualizar()
        {
            dgvProductos.DataSource = p.listarProducto();
            dgvProductos.Columns["precio"].DefaultCellStyle.Format = "c";
            dgvProductos.Columns["precio"].DefaultCellStyle.FormatProvider = System.Globalization.CultureInfo.CreateSpecificCulture("es-PE");
        }
        public void limpiar()
        {
            txtId.Text = "0";
            txtDescripcion.Text = "";
            txtCategoria.Text = "";
            txtPrecio.Text = "0.00";
            txtBuscar.Text = "";
        }

        public frmProductos()
        {
            InitializeComponent();
            actualizar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            string descripcion = txtDescripcion.Text;
            string categoria = txtCategoria.Text;
            double precio = Convert.ToDouble(txtPrecio.Text);
            if(descripcion.Length <= 0 && categoria.Length <= 0 && precio <= 0)
            {
                MessageBox.Show("¡Por favor llene todos los campos!");

            }
            else
            {
                p.insertarProducto(descripcion, categoria, precio);
                actualizar();
                limpiar();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            string descripcion = txtDescripcion.Text;
            string categoria = txtCategoria.Text;
            double precio = Convert.ToDouble(txtPrecio.Text);
            if(id == 0)
            {
                MessageBox.Show("No se encontro ID");
            }
            else
            {
                p.actualizarProducto(id, descripcion, categoria, precio);
                actualizar();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            if (id == 0)
            {
                MessageBox.Show("No se encontro ID");
            }
            else
            {
                p.eliminarProducto(id);
                actualizar();
            }
        }
        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            //Metodo que se ejecuta cuando se selecciona una fila del GRID
            //Cantidad de Filas Seleccionadas
            int canFilasSeleccionadas = dgvProductos.SelectedRows.Count;
            if (canFilasSeleccionadas > 0)
            {
                DataGridViewRow filaSel = dgvProductos.SelectedRows[0];

                int id = Convert.ToInt32(filaSel.Cells["id"].Value);
                string descripcion = Convert.ToString(filaSel.Cells["descripcion"].Value);
                string categoria = Convert.ToString(filaSel.Cells["categoria"].Value);
                double precio = Convert.ToDouble(filaSel.Cells["Precio"].Value);

                txtId.Text = id.ToString();
                txtDescripcion.Text = descripcion;
                txtCategoria.Text = categoria;
                txtPrecio.Text = precio.ToString("0.00");
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string buscar = txtBuscar.Text;
            dgvProductos.DataSource = p.buscarProducto(buscar);
        }

        private void frmProductos_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmPrincipal p = new frmPrincipal();
            p.Show();
        }
    }
}
