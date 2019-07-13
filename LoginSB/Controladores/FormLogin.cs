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

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            Login Login = new Login();
            Login.Usuario = txtUser.Text;
            Login.Contraseña = txtPassword.Text;
            if (Login.ValidarLogin(Login.Usuario, Login.Contraseña)) 
            {
                FormMenu FormMenu = new FormMenu();
                FormMenu.Show();
                this.Hide();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pbxMostrarUsuarios_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Los Usuarios son: \n Admin & Empleado");
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Login Login = new Login();
                Login.Usuario = txtUser.Text;
                Login.Contraseña = txtPassword.Text;

                if (Login.ValidarLogin(Login.Usuario, Login.Contraseña))
                {
                    FormMenu MenuPrincipal = new FormMenu();
                    MenuPrincipal.Show();
                    this.Hide();
                }
            }
        }
    }
}
