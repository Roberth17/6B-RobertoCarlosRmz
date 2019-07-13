using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace LoginSB
{
    public class Login
    {
        #region "atributos"
        string usuario, contraseña;
        #endregion

        #region "propiedades"
        public string Usuario
        {
            set { usuario = value; }
            get { return usuario; }
        }

        public string Contraseña
        {
            set { contraseña = value; }
            get { return contraseña; }
        }
        #endregion
         
        #region "Funciones"
        public bool ValidarLogin(string usuario, string contrasena)
        {
            string cadena = "Server=localhost;Database=Ser_ban;uid=root;pwd=;port=3306;";
            MySqlConnection connection = new MySqlConnection(cadena);
            connection.Open();
            MySqlCommand command;
            MySqlDataReader dataReader;
            string sql = "SELECT * FROM usuarios WHERE usuario = '" + usuario + "' AND contrasena = '" + contrasena + "' ";
            command = new MySqlCommand(sql, connection);
            dataReader = command.ExecuteReader();
            dataReader.Read();

            if (dataReader.HasRows)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Usuario y/o contraseña no incorrectos");
                return false;
            }
        }
        #endregion
    }
}
