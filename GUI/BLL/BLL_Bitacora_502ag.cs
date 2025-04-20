using BE;
using ORM;
using SERVICIOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_Bitacora_502ag
    {
        ORM_Bitacora_502ag ormBitacora = new ORM_Bitacora_502ag();

        public void AltaBitacora_502ag(string modulo, string descripcion, int criticidad)
        {
            if(SessionManager_502ag.GestorSessionManager_502ag.nombreUsuario_502ag != null)
            {
                BE_Bitacora_502ag bitacora = new BE_Bitacora_502ag(SessionManager_502ag.GestorSessionManager_502ag.nombreUsuario_502ag, DateTime.Now.Date, DateTime.Now.TimeOfDay, modulo, descripcion, criticidad);
                ormBitacora.Alta(bitacora);
            }
        }
        public List<BE_Bitacora_502ag> DevolverListaBitacora()
        {
            return ormBitacora.DevolverListaBitacora();
        }

    }
}
