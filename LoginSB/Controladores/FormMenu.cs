using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginSB
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            pbAcerca.Visible = false;
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void pbxProductos_Click(object sender, EventArgs e)
        {
            FormProductos productos = new FormProductos();
            this.Hide();
            productos.Show();
        }

        private void pbxAcerca_Click(object sender, EventArgs e)
        {
            pbAcerca.Visible = true;
        }

        private void pbxAcerca_DoubleClick(object sender, EventArgs e)
        {
            pbAcerca.Visible = false;
        }

        private void PbxHome_Click(object sender, EventArgs e)
        {
            FormLogin Login = new FormLogin();
            this.Hide();
            Login.Show();
        }
    }
}
