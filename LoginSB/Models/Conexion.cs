using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using MySql.Data.MySqlClient;

namespace LoginSB
{
    public class Conexion
    {
        public MySqlConnection con;
        public MySqlCommand cmd;
        public MySqlDataReader dr;
        public MySqlDataAdapter da;
        public DataTable dt;
        public string error;
        public DataRow fila;

        public void Conectar()
        {
            try //ejecucion normal, puede haber errores
            {
                string cadena = "Server=localhost;Database=Ser_ban;uid=root;pwd=;port=3306;";
                con = new MySqlConnection(cadena);
                con.Open();
            }

            catch (Exception ex) //ejecucion opcional
            {
                con.Close();
            }
        }

        public void desconectar()
        {
            con.Close();
        }
        public string Error
        {
            get { return error; } //obtener o consultar
            set { error = value; } //establecer el valor a la variable private
        }

        public bool LeerTablaDatos(string consulta) //bool retorna valor
        {
            try
            {
                this.Conectar();
                cmd = new MySqlCommand(consulta, con);
                cmd.ExecuteNonQuery();
                da = new MySqlDataAdapter(cmd);//consulta
                dt = new DataTable();//llena tabla segun la consulta
                da.Fill(dt);
                return true;//retorna los comandos en true, AVANZA
            }

            catch (Exception ex)
            {
                error = ex.Message; //mensaje del error 
                return false; //retorna los comandos en falso, NO AVANZA
            }
        }
    }
}
