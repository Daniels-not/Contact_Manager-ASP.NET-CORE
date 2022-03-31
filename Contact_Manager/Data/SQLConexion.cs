using System.Data.SqlClient;

namespace Contact_Manager.Data
{
    public class SQLConexion
    {
        private string conexionSQL = string.Empty;

        public SQLConexion()
        {
            
            // Connecting the data base with the appsettings.json witch contain the database config 

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            conexionSQL = builder.GetSection("ConnectionStrings:SQLCONEXION").Value;

        }
            
        public string getConexionSQL()
        {
            return conexionSQL;
        }
    }
}
