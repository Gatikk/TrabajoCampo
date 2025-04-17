using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAO_Usuario_502ag
    {
        SqlDataAdapter ad;
        DataTable dtUsuario;

        public DAO_Usuario_502ag()
        {
            DAO_Conexion_502ag conexion = DAO_Conexion_502ag.DevolverInstancia();
            SqlConnection cx = conexion.DevolverCX();
            ad = new SqlDataAdapter("SELECT * FROM Usuario_502ag", cx);
            SqlCommandBuilder cmb = new SqlCommandBuilder(ad);
            ad.InsertCommand = cmb.GetInsertCommand();
            ad.DeleteCommand = cmb.GetDeleteCommand();
            ad.UpdateCommand = cmb.GetUpdateCommand();
            dtUsuario = new DataTable();
            ad.Fill(dtUsuario);
            dtUsuario.PrimaryKey = new DataColumn[] { dtUsuario.Columns[0] };
        }

        public DataTable DevolverDTUsuario()
        {
            return dtUsuario;

        }
        public void Actualizar()
        {
            ad.Update(dtUsuario);
        }
    }
}
