using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace DAL_502ag
{
    public class DAL_Conexion_502ag
    {
        public static SqlConnection ObtenerConexion_502ag()
        {
            string cadenaConexion_502ag = ConfigurationManager.ConnectionStrings["BD_502ag"].ConnectionString;
            return new SqlConnection(cadenaConexion_502ag);
            //return new SqlConnection("Data Source=.;Initial Catalog=BD_502ag;Integrated Security=True");
        }
    }
}
