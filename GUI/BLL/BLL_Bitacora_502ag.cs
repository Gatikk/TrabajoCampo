using BE_502ag;
using DAL_502ag;
using SERVICIOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_502ag
{
    public class BLL_Bitacora_502ag
    {
        DAL_Bitacora_502ag dalBitacora_502ag = new DAL_Bitacora_502ag();
        public void AltaBitacora_502ag(string modulo, string descripcion, int criticidad)
        {
            BE_Bitacora_502ag bitacora = new BE_Bitacora_502ag(0, SessionManager_502ag.GestorSessionManager_502ag.sesion_502ag.NombreUsuario_502ag, DateTime.Now.Date, DateTime.Now.TimeOfDay, modulo, descripcion, criticidad);
            dalBitacora_502ag.AltaBitacora_502ag(bitacora);
        }
        public List<BE_Bitacora_502ag> ObtenerBitacora_502ag()
        {
            return dalBitacora_502ag.ObtenerBitacora_502ag();
        }
    }
}
