using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace LoginSB
{
    public class Producto: BaseDeDatos
    {
        private string nombre, descripcion, categoria;
        private int idProducto;

        public int IdProducto
        {
            get { return idProducto; }
            set { idProducto = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public string Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }

        public Producto()
        {

        }

        public Producto(string nombre, string descripcion, string categoria)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.categoria = categoria;
        }

        public Producto(int idProducto, string nombre, string descripcion, string categoria)
        {
            this.idProducto = idProducto;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.categoria = categoria;
        }

        public Producto(int idProducto)
        {
            this.idProducto = idProducto;
        }

        public bool GuardarDatos()
        {
            if (this.idProducto < 1)
            {
                return this.Agregar();
            }
            return this.Actualizar();
        }

        public bool MostrarTodasTablas()
        {
            return Consultar("SELECT idProducto AS Codigo, nombre AS Nombre, descripcion AS Descripcion, categoria AS Categoria FROM productos");
        }

        public bool ObtenerDatosBuscarPorNombre(string nombre)
        {
            return Consultar("SELECT idProducto AS Codigo, nombre AS Nombre, descripcion AS Descripcion, categoria AS Categoria From productos WHERE nombre like '" + nombre + "%' ");
        }
    
        public bool ObtenerDatosBuscarPorCategoria(string categoria)
        {
            return Consultar("SELECT idProducto AS Codigo, nombre AS Nombre, descripcion AS Descripcion, categoria AS Categoria From productos WHERE categoria like '" + categoria + "%' ");
        }

        public bool ObtenerDatosBuscarEliminarPorNombre(string nombre)
        {
            return Consultar("SELECT idProducto AS Codigo, nombre AS Nombre, descripcion AS Descripcion, categoria AS Categoria From productos WHERE nombre like '" + nombre + "%' ");
        }

        public bool Agregar()
        {
            this.Conectar();
            try
            {
                command = new MySqlCommand("INSERT INTO productos (nombre, descripcion, categoria) VALUES (@nombre, @descripcion, @categoria)", connection);
                command.Parameters.Add("@nombre", MySqlDbType.VarChar, 30).Value = nombre;
                command.Parameters.Add("@descripcion", MySqlDbType.VarChar, 70).Value = descripcion;
                command.Parameters.Add("@categoria", MySqlDbType.VarChar, 30).Value = categoria;
                command.ExecuteNonQuery();
                this.Desconnectar();
                return true;
            }
            catch (Exception exception)
            {
                this.exception = exception;
                return false;
            }
        }

        public bool Actualizar()
        {
            this.Conectar();
            try
            {
                command = new MySqlCommand("UPDATE productos SET nombre = @nombre, descripcion = @descripcion, categoria = @categoria WHERE idProducto = @idProducto", connection);
                command.Parameters.Add("@nombre", MySqlDbType.VarChar, 30).Value = nombre;
                command.Parameters.Add("@descripcion", MySqlDbType.VarChar, 70).Value = descripcion;
                command.Parameters.Add("@categoria", MySqlDbType.VarChar, 30).Value = categoria;
                command.Parameters.Add("@idProducto", MySqlDbType.Int16).Value = idProducto;
                command.ExecuteNonQuery();
                this.Desconnectar();
                return true;
            }
            catch (Exception exception)
            {
                this.exception = exception;
                return false;
            }
        }

        public bool Eliminar()
        {
            this.Conectar();
            try
            {
                command = new MySqlCommand("DELETE FROM productos WHERE idProducto = @idProducto", connection);
                command.Parameters.Add("@idProducto", MySqlDbType.Int16).Value = idProducto;
                command.ExecuteNonQuery();
                this.Desconnectar();
                return true;
            }
            catch (Exception exception)
            {
                this.exception = exception;
                return false;
            }
        }

        public static List<Producto> ObtenerTodo()
        {
            List<Producto> productos = new List<Producto>();
            try
            {
                string database = "Server=localhost;Database=Ser_ban;uid=root;pwd=;port=3306;";
                string query = "SELECT * FROM productos";

                MySqlConnection connection = new MySqlConnection(database);
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader dataReader;
                connection.Open();
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    int idProducto = Convert.ToInt32(dataReader.GetValue(0));
                    string nombre = Convert.ToString(dataReader.GetValue(1));
                    string descripcion = Convert.ToString(dataReader.GetValue(2));
                    string categoria = Convert.ToString(dataReader.GetValue(3));
                    Producto product = new Producto(idProducto, nombre, descripcion, categoria);
                    productos.Add(product);
                }
                connection.Close();
                return productos;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return productos;
            }
        }
    }
}
