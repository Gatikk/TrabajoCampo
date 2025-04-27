using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_502ag
{
    public class BE_Bitacora_502ag
    {
        public int CodBitacora_502ag { get; set; }
        public string NombreUsuario_502ag { get; set; }
        public DateTime Fecha_502ag { get; set; }
        public TimeSpan Hora_502ag { get; set; }
        public string Modulo_502ag { get; set; }
        public string Descripcion_502ag { get; set; }
        public int Criticidad_502ag { get; set; } 

        public BE_Bitacora_502ag(int pCodBitacora_502ag, string pNombreUsuario_502ag, DateTime pFecha_502ag, TimeSpan pHora_502ag, string pModulo_502ag, string pDescripcion_502ag, int pCriticidad_502ag)
        {
            CodBitacora_502ag = pCodBitacora_502ag;
            NombreUsuario_502ag = pNombreUsuario_502ag;
            Fecha_502ag = pFecha_502ag;
            Hora_502ag = pHora_502ag;
            Modulo_502ag = pModulo_502ag;
            Descripcion_502ag = pDescripcion_502ag;
            Criticidad_502ag = pCriticidad_502ag;
        }
    }
}
