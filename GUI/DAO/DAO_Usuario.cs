using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAO_Usuario
    {
        public static DataTable DevolverDTUsuario()
        {
            /*
            bool esValido = false;
            DAO_Conexion conexion = DAO_Conexion.DevolverInstancia();
            SqlConnection cx = conexion.DevolverCX();

            SqlDataAdapter ad = new SqlDataAdapter("SELECT * FROM Usuario", cx);

            DataTable dt = new DataTable();
            ad.Fill(dt);
            dt.PrimaryKey = new DataColumn[] { dt.Columns[0] };

            return esValido;*/

            DAO_Conexion conexion = DAO_Conexion.DevolverInstancia();
            SqlConnection cx = conexion.DevolverCX();
            SqlDataAdapter ad = new SqlDataAdapter("SELECT * FROM Usuario", cx);
            DataTable dtUsuario = new DataTable();  
            ad.Fill(dtUsuario);
            dtUsuario.PrimaryKey = new DataColumn[] { dtUsuario.Columns[0] };
            return dtUsuario;

        }
    }
}
