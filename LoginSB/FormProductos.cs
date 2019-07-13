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
    public partial class FormProductos : Form
    {
        public FormProductos()
        {
            InitializeComponent();
        }

        Productos p;

        void LlenarGrid()
        {
            p = new Productos();

            if (p.Leer())
            {
                dgv.DataSource = p.dt;
            }

            else
            {
                MessageBox.Show(p.error);
            }
        }
        void LlenarGrid2()
        {
            p = new Productos();

            if (p.Leer())
            {
                dgv2.DataSource = p.dt;
            }

            else
            {
                MessageBox.Show(p.error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
            if (p.Agregar() == 0)
            {
                MessageBox.Show("Producto Registrado Correctamente", "Insertado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LlenarGrid();
                LlenarGrid2();
            }

            else
            {
                MessageBox.Show("No se pudo registrar el Producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Menu_ppal_Forma mp = new Menu_ppal_Forma();
            this.Hide();
            mp.Show();
        }

        private void btnGuardar_Ag_MouseEnter(object sender, EventArgs e)
        {
            btnGuardar_Ag.BackColor = Color.Green;
        }

        private void btnGuardar_Ag_MouseLeave(object sender, EventArgs e)
        {
            btnGuardar_Ag.BackColor = Color.Silver;
        }

        private void btnRealizarCambio_Mo_MouseEnter(object sender, EventArgs e)
        {
            btnRealizarCambio_Mo.BackColor = Color.GreenYellow;
        }

        private void btnRealizarCambio_Mo_MouseLeave(object sender, EventArgs e)
        {
            btnRealizarCambio_Mo.BackColor = Color.Silver;
        }

        private void btnEliminar_MouseEnter(object sender, EventArgs e)
        {
            btnEliminar.BackColor = Color.Red;
            btnEliminar.ForeColor = Color.White;
        }

        private void btnEliminar_MouseLeave(object sender, EventArgs e)
        {
            btnEliminar.BackColor = Color.Silver;
            btnEliminar.ForeColor = Color.Black;
        }

        private void FormProductos_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnGuardar_Ag_Click(object sender, EventArgs e)
        {
           
        }

        private void FormProductos_Load(object sender, EventArgs e)
        {
            LlenarGrid();
            LlenarGrid2();
        }

        private void btnGuardar_Ag_MouseEnter_1(object sender, EventArgs e)
        {
            btnGuardar_Ag.BackColor = Color.Green;
            btnGuardar_Ag.ForeColor = Color.White;
        }

        private void btnGuardar_Ag_MouseLeave_1(object sender, EventArgs e)
        {
            btnGuardar_Ag.BackColor = Color.Silver;
            btnGuardar_Ag.ForeColor = Color.Black;
        }

        private void btnLimpiar_Ag_Click(object sender, EventArgs e)
        {
            txtCategoria_Ag.Clear();
            txtCodigo_Ag.Clear();
            txtDescripcion_Ag.Clear();
            txtNombre_Ag.Clear();
        }

        private void btnLimpiar_Mo_Click(object sender, EventArgs e)
        {
            txtCategoria_Mo.Clear();
            txtCodigo_Mo.Clear();
            txtDescripcion_Mo.Clear();
            txtNombre_Mo.Clear();
        }

        private void btnGuardar_Ag_Click_1(object sender, EventArgs e)
        {
            p = new Productos(txtNombre_Ag.Text, txtDescripcion_Ag.Text, txtCategoria_Ag.Text);

            if (p.Agregar() == 0)
            {
                MessageBox.Show("Registrado Correctamente", "Insertado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LlenarGrid();
                LlenarGrid2();
            }

            else
            {
                MessageBox.Show("No se pudo registrar el Producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRealizarCambio_Mo_Click(object sender, EventArgs e)
        {
            p = new Productos(int.Parse(txtCodigo_Mo.Text), txtNombre_Mo.Text, txtDescripcion_Mo.Text, txtCategoria_Mo.Text);
            if (p.Actualizar() == 0)
            {
                MessageBox.Show("Se ha Modificado Correctamente", "Insertado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LlenarGrid();
                LlenarGrid2();
            }
            else
            {
                MessageBox.Show("No se modifico los Datos. Vuelva a intentarlo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult Eliminar = MessageBox.Show("¿Realmente quieres eliminar el Producto?", "Eliminar Producto", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (Eliminar == DialogResult.Yes)
            {
                p = new Productos(int.Parse(txtCodigo_El.Text));
                if (p.Eliminar() == true)
                {
                    MessageBox.Show("Se ha eliminado satisfactoriamente ", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LlenarGrid();
                    LlenarGrid2();
                }
                else
                {
                    MessageBox.Show("No se pudo Eliminar. Vuelva a intentarlo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
        public void BuscarRegistro()
        {
            p = new Productos(int.Parse(txtCodigo_El.Text));
            if (p.Buscar(txtNombre_E))
            {
                dgv2.DataSource = p.dt;
            }
            else
            {
                MessageBox.Show("No se encontro el Cajero. Vuelva a intentarlo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre_E.Clear();
            }
        }

        private void pbxBuscar_Click(object sender, EventArgs e)
        {
            BuscarRegistro();
        }
    }
}
