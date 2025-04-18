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
        private static DAO_Conexion_502ag instancia_502ag = null;
        private SqlConnection cx_502ag;

        private DAO_Conexion_502ag()
        {
            cx_502ag = new SqlConnection("Data Source=.;Initial Catalog=BD_502ag;Integrated Security=True");
        }
        public static DAO_Conexion_502ag DevolverInstancia_502ag()
        {
            if (instancia_502ag == null)
            {
                instancia_502ag = new DAO_Conexion_502ag();  
            }
            return instancia_502ag;
        }      
        public SqlConnection DevolverCX_502ag()
        {
            return cx_502ag;
        }

    }
}
