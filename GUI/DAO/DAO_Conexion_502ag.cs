using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAO_Conexion_502ag
    {
        private static DAO_Conexion_502ag instancia = null;
        private SqlConnection cx;

        private DAO_Conexion_502ag()
        {
            cx = new SqlConnection("Data Source=.;Initial Catalog=BD_502ag;Integrated Security=True");
        }
        public static DAO_Conexion_502ag DevolverInstancia()
        {
            if (instancia == null)
            {
                instancia = new DAO_Conexion_502ag();  
            }
            return instancia;
        }      
        public SqlConnection DevolverCX()
        {
            return cx;
        }

    }
}
