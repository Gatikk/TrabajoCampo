using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SE_502ag
{
    public class SE_Evento_502ag
    {
        public string Codigo_502ag { get;set; }
        public string Usuario_502ag { get; set; }
        public DateTime Fecha_502ag { get; set; }
        public TimeSpan Hora_502ag { get; set; }
        public string Modulo_502ag { get; set; }    
        public string Evento_502ag { get; set; }
        public int Criticidad_502ag { get; set; }   
        public SE_Evento_502ag(string pCodigo_502ag, string pUsuario_502ag, DateTime pFecha_502ag, TimeSpan pHora_502ag, string pModulo_502ag, string pEvento_502ag, int pCriticidad_502ag)
        {
            Codigo_502ag = pCodigo_502ag;
            Usuario_502ag = pUsuario_502ag;
            Fecha_502ag = pFecha_502ag;
            Hora_502ag = pHora_502ag;
            Modulo_502ag = pModulo_502ag;
            Evento_502ag = pEvento_502ag;
            Criticidad_502ag = pCriticidad_502ag;
        }
    }
}
