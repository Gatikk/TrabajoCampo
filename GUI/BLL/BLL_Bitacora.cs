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
    public class BLL_Bitacora
    {
        ORM_Bitacora ormBitacora = new ORM_Bitacora();

        public void AltaBitacora(string modulo, string descripcion, int criticidad)
        {
            if(SessionManager.GestorSessionManager().sesion != null)
            {
                BE_Bitacora bitacora = new BE_Bitacora(SessionManager.GestorSessionManager().sesion.NombreUsuario, DateTime.Now.Date, DateTime.Now.TimeOfDay, modulo, descripcion, criticidad);
                ormBitacora.Alta(bitacora);
            }
        }
        public List<BE_Bitacora> DevolverListaBitacora()
        {
            return ormBitacora.DevolverListaBitacora();
        }

    }
}
