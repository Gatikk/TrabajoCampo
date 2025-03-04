using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAO_Bitacora
    {
        SqlDataAdapter ad;
        DataTable dtBitacora;

        public DAO_Bitacora()
        {
            DAO_Conexion conexion = DAO_Conexion.DevolverInstancia();
            SqlConnection cx = conexion.DevolverCX();
            ad = new SqlDataAdapter("SELECT * FROM Bitacora", cx);
            SqlCommandBuilder cmb = new SqlCommandBuilder(ad);
            ad.InsertCommand = cmb.GetInsertCommand();
            ad.DeleteCommand = cmb.GetDeleteCommand();
            ad.UpdateCommand = cmb.GetUpdateCommand();
            dtBitacora = new DataTable();
            ad.Fill(dtBitacora);
            dtBitacora.PrimaryKey = new DataColumn[] { dtBitacora.Columns[0] };
            dtBitacora.Columns["ID_Bitacora"].AutoIncrement = true;
            dtBitacora.Columns["ID_Bitacora"].AutoIncrementSeed = dtBitacora.Rows.Count + 1;
            dtBitacora.Columns["ID_Bitacora"].AutoIncrementStep = 1;
        }

        public DataTable DevolverDT()
        {
            return dtBitacora;
        }

        public void Actualizar()
        {
            ad.Update(dtBitacora);
            //dtBitacora.Clear();
            //ad.Fill(dtBitacora);
        }
    }
}
