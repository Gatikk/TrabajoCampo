using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_Bitacora_502ag
    {
        public int ID_Bitacora { get; set; }
        public string NombreUsuario { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public string Modulo { get; set; }
        public string Descripcion { get; set; }
        public int Criticidad { get; set; } 

        public BE_Bitacora_502ag(string pNombreUsuario, DateTime pFecha, TimeSpan pHora, string pModulo, string pDescripcion, int pCriticidad)
        {
            NombreUsuario = pNombreUsuario;
            Fecha = pFecha;
            Hora = pHora;
            Modulo = pModulo;
            Descripcion = pDescripcion;
            Criticidad = pCriticidad;
        }
    }
}
