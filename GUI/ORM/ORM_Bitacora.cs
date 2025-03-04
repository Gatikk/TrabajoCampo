using BE;
using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class ORM_Bitacora
    {
        DAO_Bitacora daoBitacora = new DAO_Bitacora();

        public void Alta(BE_Bitacora entidad)
        {
            DataRow drBitacora = daoBitacora.DevolverDT().NewRow();
            drBitacora["NombreUsuario"] = entidad.NombreUsuario;
            drBitacora["Fecha"] = entidad.Fecha;
            drBitacora["Hora"] = entidad.Hora;
            drBitacora["Modulo"] = entidad.Modulo;
            drBitacora["Descripcion"] = entidad.Descripcion;
            drBitacora["Criticidad"] = entidad.Criticidad;
            daoBitacora.DevolverDT().Rows.Add(drBitacora);
            daoBitacora.Actualizar();
        }

        public List<BE_Bitacora> DevolverListaBitacora()
        {
            List<BE_Bitacora> listaBitacora = new List<BE_Bitacora>();

            DataView dvBitacora = new DataView(daoBitacora.DevolverDT(), "", "", DataViewRowState.Unchanged);
            
            foreach(DataRowView drv in dvBitacora)
            {
                BE_Bitacora bitacora = new BE_Bitacora(drv[1].ToString(), DateTime.Parse(drv[2].ToString()), TimeSpan.Parse(drv[3].ToString()), drv[4].ToString(), drv[5].ToString(), int.Parse(drv[6].ToString()));
                bitacora.ID_Bitacora = int.Parse(drv[0].ToString());
                listaBitacora.Add(bitacora);
            }

            return listaBitacora;
        }

    }
}
