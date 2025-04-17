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
    public class ORM_Bitacora_502ag
    {
        DAO_Bitacora_502ag daoBitacora = new DAO_Bitacora_502ag();
        public void Alta(BE_Bitacora_502ag entidad)
        {
            DataRow drBitacora = daoBitacora.DevolverDT().NewRow();
            drBitacora["NombreUsuario_502ag"] = entidad.NombreUsuario;
            drBitacora["Fecha_502ag"] = entidad.Fecha;
            drBitacora["Hora_502ag"] = entidad.Hora;
            drBitacora["Modulo_502ag"] = entidad.Modulo;
            drBitacora["Descripcion_502ag"] = entidad.Descripcion;
            drBitacora["Criticidad_502ag"] = entidad.Criticidad;
            daoBitacora.DevolverDT().Rows.Add(drBitacora);
            daoBitacora.Actualizar();
        }

        public List<BE_Bitacora_502ag> DevolverListaBitacora()
        {
            List<BE_Bitacora_502ag> listaBitacora = new List<BE_Bitacora_502ag>();

            DataView dvBitacora = new DataView(daoBitacora.DevolverDT(), "", "", DataViewRowState.Unchanged);
            
            foreach(DataRowView drv in dvBitacora)
            {
                BE_Bitacora_502ag bitacora = new BE_Bitacora_502ag(drv[1].ToString(), DateTime.Parse(drv[2].ToString()), TimeSpan.Parse(drv[3].ToString()), drv[4].ToString(), drv[5].ToString(), int.Parse(drv[6].ToString()));
                bitacora.ID_Bitacora = int.Parse(drv[0].ToString());
                listaBitacora.Add(bitacora);
            }

            return listaBitacora;
        }

    }
}
