using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;


namespace DAL_502ag
{
    public class DAL_Conexion_502ag
    {
        public static SqlConnection ObtenerConexion_502ag()
        {
            string cadenaConexion_502ag = ObtenerCadenaConexion_502ag();
            return new SqlConnection(cadenaConexion_502ag);
            //return new SqlConnection("Data Source=.;Initial Catalog=BD_502ag;Integrated Security=True");
        }

        private static string ObtenerCadenaConexion_502ag()
        {
            string ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DAL.config");
            var configMap = new ExeConfigurationFileMap { ExeConfigFilename = ruta };
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
            return config.ConnectionStrings.ConnectionStrings["MiConexionDB_502ag"].ConnectionString;
        }
    }
}
