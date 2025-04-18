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
        SqlDataAdapter sqlDataAdapter_502ag;
        DataTable dtUsuario_502ag;

        public DAO_Usuario_502ag()
        {
            DAO_Conexion_502ag conexion_502ag = DAO_Conexion_502ag.DevolverInstancia_502ag();
            SqlConnection cx_502ag = conexion_502ag.DevolverCX_502ag();
            sqlDataAdapter_502ag = new SqlDataAdapter("SELECT * FROM Usuario_502ag", cx_502ag);
            SqlCommandBuilder cmb_502ag = new SqlCommandBuilder(sqlDataAdapter_502ag);
            sqlDataAdapter_502ag.InsertCommand = cmb_502ag.GetInsertCommand();
            sqlDataAdapter_502ag.DeleteCommand = cmb_502ag.GetDeleteCommand();
            sqlDataAdapter_502ag.UpdateCommand = cmb_502ag.GetUpdateCommand();
            dtUsuario_502ag = new DataTable();
            sqlDataAdapter_502ag.Fill(dtUsuario_502ag);
            dtUsuario_502ag.PrimaryKey = new DataColumn[] { dtUsuario_502ag.Columns["DNI_502ag"] };
        }

        public DataTable DevolverDTUsuario_502ag()
        {
            return dtUsuario_502ag;

        }
        public void Actualizar_502ag()
        {
            sqlDataAdapter_502ag.Update(dtUsuario_502ag);
        }
    }
}
