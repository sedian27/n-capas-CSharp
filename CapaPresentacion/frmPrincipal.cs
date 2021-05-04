using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnProducto_Click(object sender, EventArgs e)
        {
            this.Hide();

            frmProductos p = new frmProductos();
            p.Show();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            this.Hide();

            frmCliente c = new frmCliente();
            c.Show();
        }
    }
}
