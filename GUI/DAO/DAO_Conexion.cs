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
    public class DAO_Conexion
    {
        private static DAO_Conexion instancia = null;
        private SqlConnection cx;

        private DAO_Conexion()
        {
            cx = new SqlConnection("Data Source=.;Initial Catalog=BD_Provisoria;Integrated Security=True");
        }

        public static DAO_Conexion DevolverInstancia()
        {
            if (instancia == null)
            {
                instancia = new DAO_Conexion();  
            }
            return instancia;
        }
        
        public SqlConnection DevolverCX()
        {
            if(cx == null)
            {
                throw new Exception("La conexión es nula");
            }
            return cx;
        }

    }
}
