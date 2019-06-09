using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Servicio_de_Banquetes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-IBA1JGT\SQLEXPRESS;Initial Catalog=SQLQuery1; Integrated Security=True");

        private void pictureBoxEnter_Click(object sender, EventArgs e)
        {
            logear(txtUsuario.Text, txtContrasena.Text);
            Inicio i = new Inicio();
            this.Dispose();
            i.Show();
        }

        public void logear(string usuario, string contraseña)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Nombre From Usuarios WHERE Nombre = @usu AND Contraseña = @cont", con);
                cmd.Parameters.AddWithValue("@usu", usuario);
                cmd.Parameters.AddWithValue("@cont", contraseña);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count == 1)
                {
                    this.Hide();
                    Inicio ini = new Inicio();
                    ini.ShowDialog();
                }

                else
                {
                    MessageBox.Show("Usuario y/o Contraseña incorrecta");
                }
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            finally
            {
                con.Close();
            }
        }
    }
}
