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
    public class BaseDeDatos
    {
        public MySqlConnection connection;
        public MySqlCommand command;
        public MySqlDataReader dataReader;
        public MySqlDataAdapter dataAdapter;
        public DataTable dataTable;
        public string error;
        protected Exception exception = null;

        public Exception Exception
        {
            get { return this.exception; }
            set { this.exception = value; }
        }

        public string Error
        {
            get { return error; }
            set { error = value; }
        }

        public void Conectar()
        {
            try 
            {
                string cadena = "Server=localhost;Database=Ser_ban;uid=root;pwd=;port=3306;";
                connection = new MySqlConnection(cadena);
                connection.Open();
            }
            catch (Exception) 
            {
                connection.Close();
            }
        }

        protected void Desconnectar()
        {
            this.connection.Close();
        }

        public bool Consultar(string consulta) 
        {
            try
            {
                this.Conectar();
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
