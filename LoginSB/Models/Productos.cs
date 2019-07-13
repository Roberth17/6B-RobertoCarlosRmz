using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LoginSB
{
    public class Productos:Conexion
    {
        private string nombre, descripcion, categoria;
        private int id_producto;
        

        public int Id_Producto
        {
            get { return id_producto; }
            set { id_producto = value; }
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

        public Productos()
        {

        }

        public Productos(string Nombre, string Descripcion, string Categoria)
        {
            this.nombre = Nombre;
            this.descripcion = Descripcion;
            this.categoria = Categoria;
        }

        public Productos(int id_producto, string Nombre, string Descripcion, string Categoria)
        {
            this.id_producto = id_producto;
            this.nombre = Nombre;
            this.descripcion = Descripcion;
            this.categoria = Categoria;
        }

        public Productos(int id_producto)
        {
            this.id_producto = id_producto;
        }

        public bool Leer()
        {
            return LeerTablaDatos("select id_producto as Codigo, nombre as Nombre, descripcion as Descripcion, categoria as Categoria from productos");
        }

        Conexion conex = new Conexion();

        public bool Agregar(string nombre, string descripcion, string categoria)
        {
            Conectar();
            try
            {
                cmd = new MySqlCommand("insert into productos (nombre, descripcion, categoria) values (@nombre, @descripcion, @categoria)", con);
                cmd.Parameters.Add("@nombre", MySqlDbType.VarChar, 30).Value = Nombre;
                cmd.Parameters.Add("@descripcion", MySqlDbType.VarChar, 70).Value = descripcion;
                cmd.Parameters.Add("@categoria", MySqlDbType.VarChar, 30).Value = categoria;
                cmd.ExecuteNonQuery();
                return true;
            }

            catch (Exception ex)
            {
                return false;
            }
            desconectar();
        }

        public bool Actualizar(int id_producto, string nombre, string descripcion, string categoria)
        {
            Conectar();
            try
            {
                cmd = new MySqlCommand("update productos set nombre = @nombre, descripcion = @descripcion, categoria = @categoria where id_producto = @id_producto", con);
                cmd.Parameters.Add("@nombre", MySqlDbType.VarChar, 30).Value = Nombre;
                cmd.Parameters.Add("@descripcion", MySqlDbType.VarChar, 70).Value = Descripcion;
                cmd.Parameters.Add("@categoria", MySqlDbType.VarChar, 30).Value = Categoria;
                cmd.Parameters.Add("@id_producto", MySqlDbType.Int16).Value = id_producto;
                cmd.ExecuteNonQuery();
                return true;
            }

            catch (Exception ex)
            {
                return false;
            }

            desconectar();
        }

        public bool Eliminar(int id_producto)
        {
            Conectar();
            try
            {
                cmd = new MySqlCommand("delete from productos where id_producto = @id_producto", con);
                cmd.Parameters.Add("@id_producto", MySqlDbType.Int16).Value = id_producto;
                cmd.ExecuteNonQuery();
                return true;
            }

            catch (Exception ex)
            {
                return false;
            }

            desconectar();
        }

        public bool Buscar(TextBox txtNombre_E)
        {
            bool bandera = false;
            Conectar();

            try
            {
                cmd = new MySqlCommand("select Id_producto as Codigo, nombre as Nombre, descripcion as Descripcion, categoria as Categoria from productos where id_producto = @id_producto", con);
                cmd.Parameters.Add("@id_producto", MySqlDbType.Int16).Value = id_producto;

                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    txtNombre_E.Text = dr["Nombre"].ToString();

                    bandera = true;
                }
                dr.Close();

                return bandera;
            }

            catch (Exception ex)
            {
                return false;
            }

            desconectar();
        }
    }
}
