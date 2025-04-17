using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAO_Bitacora_502ag
    {
        SqlDataAdapter ad;
        DataTable dtBitacora;

        public DAO_Bitacora_502ag()
        {
            DAO_Conexion_502ag conexion = DAO_Conexion_502ag.DevolverInstancia();
            SqlConnection cx = conexion.DevolverCX();
            ad = new SqlDataAdapter("SELECT * FROM Bitacora_502ag", cx);
            SqlCommandBuilder cmb = new SqlCommandBuilder(ad);
            ad.InsertCommand = cmb.GetInsertCommand();
            ad.DeleteCommand = cmb.GetDeleteCommand();
            ad.UpdateCommand = cmb.GetUpdateCommand();
            dtBitacora = new DataTable();
            ad.Fill(dtBitacora);
            dtBitacora.PrimaryKey = new DataColumn[] { dtBitacora.Columns["NumeroBitacora_502ag"] };
            dtBitacora.Columns["NumeroBitacora_502ag"].AutoIncrement = true;
            dtBitacora.Columns["NumeroBitacora_502ag"].AutoIncrementSeed = dtBitacora.Rows.Count + 1;
            dtBitacora.Columns["NumeroBitacora_502ag"].AutoIncrementStep = 1;
        }

        public DataTable DevolverDT()
        {
            return dtBitacora;
        }

        public void Actualizar()
        {
            ad.Update(dtBitacora);
        }
    }
}
