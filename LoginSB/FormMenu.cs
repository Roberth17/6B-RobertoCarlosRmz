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
    public partial class Menu_ppal_Forma : Form
    {
        public Menu_ppal_Forma()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            FormProductos pro = new FormProductos();
            this.Hide();
            pro.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            FormLogin f1 = new FormLogin();
            this.Hide();
            f1.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pbAcerca.Visible = true;
        }

        private void Menu_ppal_Load(object sender, EventArgs e)
        {
            pbAcerca.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pbAcerca.Visible = false;
        }

        private void pictureBox3_DoubleClick(object sender, EventArgs e)
        {
            pbAcerca.Visible = false;
        }

        private void PbxProductos_MouseEnter(object sender, EventArgs e)
        {
            pbxProductos.BackColor = Color.BlueViolet;
        }

        private void pbxProductos_MouseLeave(object sender, EventArgs e)
        {
            pbxProductos.BackColor = Color.Silver;
        }

        private void BtnSalir_MouseEnter(object sender, EventArgs e)
        {
            BtnSalir.BackColor = Color.Tomato;
            BtnSalir.ForeColor = Color.Black;
        }

        private void BtnSalir_MouseLeave(object sender, EventArgs e)
        {
            BtnSalir.BackColor = Color.Red;
            BtnSalir.ForeColor = Color.White;
        }

        private void Menu_ppal_Forma_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
