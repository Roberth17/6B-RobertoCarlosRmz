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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void Btn_Iniciar_Click_1(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Usuario = txt_user.Text;
            lg.Contraseña = txt_pass.Text;

            if (lg.ValidarLogin(lg.Usuario, lg.Contraseña))
            {
                Menu_ppal_Forma mp = new Menu_ppal_Forma();
                mp.Show();
                this.Hide();
            }
        }

        private void Btn_Salir_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PbxCualEs_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Los Usuarios son: \n Admin & Empleado");
        }

        private void btn_Salir_MouseEnter(object sender, EventArgs e)
        {
            btn_Salir.BackColor = Color.Red;
            btn_Salir.ForeColor = Color.White;
        }

        private void btn_Salir_MouseLeave(object sender, EventArgs e)
        {
            btn_Salir.BackColor = Color.Silver;
            btn_Salir.ForeColor = Color.Black;
        }

        private void btn_Iniciar_MouseEnter(object sender, EventArgs e)
        {
            btn_Iniciar.BackColor = Color.LightYellow;
        }

        private void btn_Iniciar_MouseLeave(object sender, EventArgs e)
        {
            btn_Iniciar.BackColor = Color.Silver;
        }

        private void txt_pass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==Convert.ToChar(Keys.Enter))
            {
                Login lg = new Login();
                lg.Usuario = txt_user.Text;
                lg.Contraseña = txt_pass.Text;

                if (lg.ValidarLogin(lg.Usuario, lg.Contraseña))
                {
                    Menu_ppal_Forma mp = new Menu_ppal_Forma();
                    mp.Show();
                    this.Hide();
                }
            }
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
