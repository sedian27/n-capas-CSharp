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
using CapaEntidad;
namespace CapaPresentacion
{
    public partial class frmCliente : Form
    {
        //Propiedades

        ClienteCN c = new ClienteCN();

        //Funciones

        public void actualizar()
        {
            dgvClientes.DataSource = c.listarCliente();
        }

        public void limpiar()
        {
            txtId.Text = "0";
            txtNombre.Text = "";
            txtNumRuc.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtBuscar.Text = "";
        }

        public frmCliente()
        {
            InitializeComponent();
            actualizar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string numruc = txtNumRuc.Text;
            string direccion = txtDireccion.Text;
            int telefono = Convert.ToInt32(txtTelefono.Text.Length == 9 ? txtTelefono.Text : "0");
            if(nombre.Length <= 0 && numruc.Length <= 0 && direccion.Length <= 0 && telefono <= 0)
            {
                MessageBox.Show("¡Por favor llene todos los campos!");
            }
            else{
                ClienteCE cliente = new ClienteCE(0, nombre, numruc, direccion, telefono);
                c.insertarCliente(cliente);
                actualizar();
                limpiar();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            if (id == 0)
            {
                MessageBox.Show("No se encontro ID");
            }
            else
            {
                string nombre = txtNombre.Text;
                string numruc = txtNumRuc.Text;
                string direccion = txtDireccion.Text;
                int telefono = Convert.ToInt32(txtTelefono.Text);
                ClienteCE cliente = new ClienteCE(id, nombre, numruc, direccion, telefono);
                c.actualizarCliente(cliente);
                actualizar();
                limpiar();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            
            if(id == 0)
            {
                MessageBox.Show("No se encontro ID");
            }
            else
            {
                ClienteCE cliente = new ClienteCE(id);
                c.eliminarCliente(cliente);
                actualizar();
                limpiar();
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string buscar = txtBuscar.Text;
            dgvClientes.DataSource = c.buscarCliente(buscar);
        }

        private void dgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            int cantFilasSeleccionadas = dgvClientes.SelectedRows.Count;
            if(cantFilasSeleccionadas > 0)
            {
                DataGridViewRow filaSel = dgvClientes.SelectedRows[0];

                int id = Convert.ToInt32(filaSel.Cells["id"].Value);
                string nombre = filaSel.Cells["nombre"].Value.ToString();
                string numruc = filaSel.Cells["numruc"].Value.ToString();
                string direccion = filaSel.Cells["direccion"].Value.ToString();
                int telefono = Convert.ToInt32(filaSel.Cells["telefono"].Value);

                txtId.Text = id.ToString();
                txtNombre.Text = nombre;
                txtNumRuc.Text = numruc;
                txtDireccion.Text = direccion;
                txtTelefono.Text = telefono.ToString();
            }
        }

        private void frmCliente_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmPrincipal p = new frmPrincipal();
            p.Show();
        }
    }
}
