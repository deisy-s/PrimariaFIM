using MySql.Data.MySqlClient;
using Org.BouncyCastle.Tls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReglasDeNegocio
{
    public class MainClass
    {
        public string sError, sConnection;
        private string sServer = "localhost";
        private string sUser = "root";
        private string sPass = "12345";

        public bool BDIniciarSesion()
        {
            bool bOk = false;
            try
            {
                // Crear el query para conectarse a la base de datos
                sConnection = $@"Server={sServer}; database=primariafim; UID={sUser}; password={sPass}";
                // Crear la conexión
                MySqlConnection conMySQL = new MySqlConnection(sConnection);
                conMySQL.Open(); // Abrir y cerrar la conexión
                conMySQL.Close();
                bOk = true;
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            return bOk;
        }
    }
}
