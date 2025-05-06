using DAL_502ag;
using SE_502ag;
using SERVICIOS_502ag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICIOS_502ag
{
    public class SER_GestorBitacora_502ag
    {
        DAL_Bitacora_502ag dalBitacora_502ag = new DAL_Bitacora_502ag();
        public void AltaBitacora_502ag(string modulo, string descripcion, int criticidad)
        { 
            SE_Bitacora_502ag bitacora = new SE_Bitacora_502ag(0, SER_GestorSesion_502ag.GestorSesion_502ag.sesion_502ag.NombreUsuario_502ag, DateTime.Now.Date, DateTime.Now.TimeOfDay, modulo, descripcion, criticidad);
            dalBitacora_502ag.AltaBitacora_502ag(bitacora);
        }
        public List<SE_Bitacora_502ag> ObtenerBitacora_502ag()
        {
            return dalBitacora_502ag.ObtenerBitacora_502ag();
        }

    }
}
