using MySqlConnector;
using Newtonsoft.Json;
using RuteroApp.Models;
using System.Data;

namespace RuteroApp.Utilidades
{
    public class ConexionMySql
    {
        static string usuario = "root"; //Usuario de acceso a MySQL
        static string password = "3380"; //Contraseña de usuario de acceso a MySQL
        static string TimeOut = "5";

        public static async Task<MySqlConnection> GetConnection()
        {
            await GetConfig();

            string cadenaConexion = @"Database=" + MySqlDB.DataBase + ";Port=" + MySqlDB.Puerto + "; Data Source=" + MySqlDB.IP + "; User Id=" + usuario + ";" +
                " Password=" + password + "; AllowUserVariables=True;Connect Timeout=" + TimeOut + ";";

            MySqlConnection connection = new MySqlConnection
            {
                ConnectionString = cadenaConexion,
            };

            try
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                else
                {
                    connection.Open();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return connection;
        }
        public static async Task<bool> GetConfig()
        {
            var getFile = await SecureStorage.GetAsync("conexion.json"); ;
            if (getFile == null)
            {
                return false;
            }
            else
            {
                var conn = JsonConvert.DeserializeObject<Setings>(getFile.ToString());
                if (conn != null)
                {
                    MySqlDB.Puerto = conn.Puerto;
                    MySqlDB.IP = conn.IP;
                    MySqlDB.DataBase = conn.DataBase;
                }
            }
            return true;
        }
        public static async Task<string> TestConexion()
        {
            var getConnFile = await GetConfig();

            if (getConnFile)
            {
                var conn = GetConnection();
                if (conn == null)
                {
                    return "ERROR DE CONEXIÓN";
                }
                else
                {
                    return "CONEXIÓN EXITOSA!";
                }
            }
            else
            {
                return "ERROR CON EL ARCHIVO CONFIG";
            }
        }
    }
}
