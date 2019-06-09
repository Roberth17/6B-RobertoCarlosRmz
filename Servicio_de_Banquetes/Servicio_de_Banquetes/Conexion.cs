using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;

namespace Servicio_de_Banquetes
{
    class Conexion
    {
        private string Cadena = @"Data Source=DESKTOP-UU2NPB7\SQLEXPRESS;Initial Catalog=loginSB;Integrated Security=True";
        public SqlConnection cn;
        public SqlCommand cmd;
        public SqlDataReader dr;
        public SqlDataAdapter da;
        public DataTable dt;
        public string error;
        public DataRow fila;

        public void conectar()
        {
            try
            {
                cn = new SqlConnection(Cadena);
                cn.Open();
            }

            catch (Exception e)
            {
                cn.Close();
            }
        }

        public string ERROR
        {
            get { return error; }
            set { error = value; }
        }

        public bool LeerTablaDatos(string consulta)
        {
            try
            {
                this.conectar();
                cmd = new SqlCommand(consulta, cn);
                cmd.ExecuteNonQuery();
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                return true;
            }

            catch (Exception e)
            {
                error = e.Message;
                return false;
            }
        }
    }
}
