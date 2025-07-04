using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_502ag
{
    public class DAL_Conexion_502ag
    {
        public static SqlConnection ObtenerConexion_502ag()
        {
            return new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=BD_502ag;User ID=sa;Password=.;");

            //return new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=BD_502ag;Integrated Security=True");
        }
    }
}
