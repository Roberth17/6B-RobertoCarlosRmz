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
    public class BDConexion
    {
        public MySqlConnection connection;
        public MySqlCommand command;
        public MySqlDataReader dataReader;
        public MySqlDataAdapter dataAdapter;
        public DataTable dataTable;
        public string error;
        public DataRow fila;
        protected Exception exception = null;

        public void ConectarBD()
        {
            try 
            {
                string cadena = "Server=localhost;Database=Ser_ban;uid=root;pwd=;port=3306;";
                connection = new MySqlConnection(cadena);
                connection.Open();
            }

            catch (Exception exception) 
            {
                connection.Close();
            }
        }

        public Exception Exception
        {
            get { return this.exception; }
            set { this.exception = value; }
        }

        protected void Desconnectar()
        {
            this.connection.Close();
        }

        public string Error
        {
            get { return error; } 
            set { error = value; } 
        }

        public bool Consultar(string consulta) 
        {
            try
            {
                this.ConectarBD();
                command = new MySqlCommand(consulta, connection);
                command.ExecuteNonQuery();
                dataAdapter = new MySqlDataAdapter(command);
                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                this.Desconnectar();
                return true;
            }
            catch (Exception exception)
            {
                error = exception.Message; 
                return false; 
            }
        }
    }
}
