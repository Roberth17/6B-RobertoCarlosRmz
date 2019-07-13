using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginSB
{
    public partial class FormProductos : Form
    {
        Producto producto;
        public FormProductos()
        {
            InitializeComponent();
        }
   
        public bool ValidarDatosAgregar()
        {
            if (txtNombreAgregar.Text == "" || txtCategoriaAgreagar.Text == "")
            {
                if (txtNombreAgregar.Text == "")
                {
                    ErrorProvider.SetError(txtNombreAgregar, "Ingresa un Nombre valido!!!");
                    txtNombreAgregar.Focus();
                    return false;
                }
                else if (txtCategoriaAgreagar.Text == "")
                {
                    ErrorProvider.SetError(txtCategoriaAgreagar, "Ingresa una categoria valido!!!");
                    txtCategoriaAgreagar.Focus();
                    return false;
                }
            }
            ErrorProvider.SetError(txtNombreAgregar, "");
            ErrorProvider.SetError(txtCategoriaAgreagar, "");
            return true;
        }

        public bool ValidarDatosModificar()
        {
            if (txtNombreModificar.Text == "" || txtCategoriaModificar.Text == "")
            {
                if (txtNombreModificar.Text == "")
                {
                    ErrorProvider.SetError(txtNombreModificar, "Ingresa un Nombre valido!!!");
                    txtNombreModificar.Focus();
                    return false;
                }
                else if (txtCategoriaModificar.Text == "")
                {
                    ErrorProvider.SetError(txtCategoriaModificar, "Ingresa una categoria valido!!!");
                    txtCategoriaModificar.Focus();
                    return false;
                }
            }
            ErrorProvider.SetError(txtNombreModificar, "");
            ErrorProvider.SetError(txtCategoriaModificar, "");
            return true;
        }

        public bool ValidarIDModificar(ref int idProducto)
        {
            if (!int.TryParse(txtCodigoModificar.Text, out idProducto))
            {
                ErrorProvider.SetError(txtCodigoModificar, "Ingresa un Codigo Valido!!!");
                txtCodigoModificar.Focus();
                return false;
            }
            ErrorProvider.SetError(txtCodigoModificar, "");
            return true;
        }

        void LlenarGridAgregarDatos()
        {
            producto = new Producto();
            if (producto.MostrarTodasTablas())
            {
                dgvAgregar.DataSource = producto.dataTable;
            }
            else
            {
                MessageBox.Show(producto.error);
            }
        }

        void LlenarGridEliminarDatos()
        {
            producto = new Producto();
            if (producto.MostrarTodasTablas())
            {
                dgvEliminar.DataSource = producto.dataTable;
            }
            else
            {
                MessageBox.Show(producto.error);
            }
        }

        void LlenarGridModificarDatos()
        {
            producto = new Producto();
            if (producto.MostrarTodasTablas())
            {
                dgvModificar.DataSource = producto.dataTable;
            }
            else
            {
                MessageBox.Show(producto.error);
            }
        }

        private void FormProductos_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void FormProductos_Load(object sender, EventArgs e)
        {
            LlenarGridAgregarDatos();
            LlenarGridEliminarDatos();
            LlenarGridModificarDatos();
        }

        private void btnRealizarCambio_Click(object sender, EventArgs e)
        {
            int idProducto = 0;

            if (ValidarDatosModificar() == false)
            {
                return;
            }

            if (ValidarIDModificar(ref idProducto) == false)
            {
                return;
            }

            producto = new Producto(int.Parse(txtCodigoModificar.Text), txtNombreModificar.Text, txtDescripcionModificar.Text, txtCategoriaModificar.Text);

            if (producto.Actualizar())
            {
                MessageBox.Show("Se ha Modificado Correctamente", "Insertado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LlenarGridAgregarDatos();
                LlenarGridEliminarDatos();
                LlenarGridModificarDatos();
            }
            else
            {
                MessageBox.Show("No se modifico los Datos. Vuelva a intentarlo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            txtCategoriaModificar.Clear();
            txtDescripcionModificar.Clear();
            txtNombreModificar.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult Eliminar = MessageBox.Show("¿Realmente quieres eliminar el Producto?", "Eliminar Producto", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (Eliminar == DialogResult.Yes)
            {
                producto = new Producto(int.Parse(txtCodigoEliminar.Text));

                if (producto.Eliminar())
                {
                    MessageBox.Show("Se ha eliminado satisfactoriamente ", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LlenarGridAgregarDatos();
                    LlenarGridEliminarDatos();
                    LlenarGridModificarDatos();
                }
                else
                {
                    MessageBox.Show("No se pudo Eliminar. Vuelva a intentarlo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void GridMostrarTablaEliminar()
        {
            try
            {
                producto = new Producto();

                if (producto.ObtenerDatosBuscarEliminarPorNombre(txtNombreEliminar.Text))
                {
                    dgvEliminar.DataSource = producto.dataTable;
                }
                else
                {
                    MessageBox.Show(producto.error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(producto.error);
            }
        }

        void GridBuscarNombreTablaAgregar()
        {
            Producto producto = new Producto();

            try
            {
                if (producto.ObtenerDatosBuscarPorNombre(txtBuscarAgregarNombre.Text))
                {
                    dgvAgregar.DataSource = producto.dataTable;
                }
                else
                {
                    MessageBox.Show(producto.error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(producto.error);
            }
        }

        void GridBuscarCategoriaTablaModificar()
        {
            try
            {
                producto = new Producto();
                if (producto.ObtenerDatosBuscarPorCategoria(txtBuscarModificarCategoria.Text))
                {
                    dgvModificar.DataSource = producto.dataTable;
                }
                else
                {
                    MessageBox.Show(producto.error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(producto.error);
            }
        }

        private void pbxBuscar_Click(object sender, EventArgs e)
        {
            GridMostrarTablaEliminar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
            if (ValidarDatosAgregar() == false)
            {
                return;
            }

            Producto producto = new Producto(txtNombreAgregar.Text, txtDescripcionAgreagar.Text, txtCategoriaAgreagar.Text);

            if (producto.Agregar())
            {
                MessageBox.Show("Se ha Insertado Correctamente", "Insertado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LlenarGridAgregarDatos();
                LlenarGridEliminarDatos();
                LlenarGridModificarDatos();
            }
            else
            {
                MessageBox.Show("No se inserto los Datos. Vuelva a intentarlo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            txtCategoriaAgreagar.Clear();
            txtDescripcionAgreagar.Clear();
            txtNombreAgregar.Clear();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
             FormMenu MenuPrincipal = new FormMenu();
            this.Hide();
            MenuPrincipal.Show();
        }
        
        private void dgvEliminar_DoubleClick(object sender, EventArgs e)
        {
            if (dgvEliminar.Rows.Count != 0)
            {
                int posicion;
                posicion = dgvEliminar.CurrentRow.Index;
                txtCodigoEliminar.Text = dgvEliminar[0, posicion].Value.ToString();
                txtNombreEliminar.Text = dgvEliminar[1, posicion].Value.ToString();
            }
        }

        private void dgvRegistros_DoubleClick(object sender, EventArgs e)
        {
            if (dgvAgregar.Rows.Count != 0)
            {
                int posicion;
                posicion = dgvAgregar.CurrentRow.Index;
                txtCodigoModificar.Text = dgvAgregar[0, posicion].Value.ToString();
                txtNombreModificar.Text = dgvAgregar[1, posicion].Value.ToString();
                txtDescripcionModificar.Text = dgvAgregar[2, posicion].Value.ToString();
                txtCategoriaModificar.Text = dgvAgregar[3, posicion].Value.ToString();
            }
        }

        private void btnLimpiarAgregar_Click(object sender, EventArgs e)
        {
            txtCategoriaAgreagar.Clear();
            txtDescripcionAgreagar.Clear();
            txtNombreAgregar.Clear();
            txtBuscarAgregarNombre.Clear();
        }

        private void dgvModificar_DoubleClick(object sender, EventArgs e)
        {
            if (dgvModificar.Rows.Count != 0)
            {
                int posicion;
                posicion = dgvModificar.CurrentRow.Index;
                txtCodigoModificar.Text = dgvModificar[0, posicion].Value.ToString();
                txtNombreModificar.Text = dgvModificar[1, posicion].Value.ToString();
                txtDescripcionModificar.Text = dgvModificar[2, posicion].Value.ToString();
                txtCategoriaModificar.Text = dgvModificar[3, posicion].Value.ToString();
            }
        }

        private void dgvAgregar_DoubleClick(object sender, EventArgs e)
        {
            if (dgvAgregar.Rows.Count != 0)
            {
                int posicion;
                posicion = dgvAgregar.CurrentRow.Index;
                txtBuscarAgregarNombre.Text = dgvAgregar[0, posicion].Value.ToString();
                txtNombreAgregar.Text = dgvAgregar[1, posicion].Value.ToString();
                txtDescripcionAgreagar.Text = dgvAgregar[2, posicion].Value.ToString();
                txtCategoriaAgreagar.Text = dgvAgregar[3, posicion].Value.ToString();
            }
        }

        private void btnLlenarTablaAgregar_Click(object sender, EventArgs e)
        {
            LlenarGridAgregarDatos();
            txtCategoriaAgreagar.Clear();
            txtDescripcionAgreagar.Clear();
            txtNombreAgregar.Clear();
            txtBuscarAgregarNombre.Clear();
        }

        private void pbxBuscarAgregar_Click(object sender, EventArgs e)
        {
            GridBuscarNombreTablaAgregar();
        }

        private void btnLimpiarModificar_Click(object sender, EventArgs e)
        {
            txtCategoriaModificar.Clear();
            txtDescripcionModificar.Clear();
            txtNombreModificar.Clear();
            txtBuscarModificarCategoria.Clear();
            txtCodigoModificar.Clear();
        }

        private void btnLlenarTablasModificar_Click(object sender, EventArgs e)
        {
            LlenarGridModificarDatos();
            txtCategoriaModificar.Clear();
            txtDescripcionModificar.Clear();
            txtNombreModificar.Clear();
            txtBuscarModificarCategoria.Clear();
            txtCodigoModificar.Clear();
        }

        private void pbxBuscarModificar_Click(object sender, EventArgs e)
        {
                GridBuscarCategoriaTablaModificar();
        }

        private void btnLlenarTablaEliminar_Click(object sender, EventArgs e)
        {
            LlenarGridEliminarDatos();
            txtNombreEliminar.Clear();
            txtCodigoEliminar.Clear();
        }
    }
}
