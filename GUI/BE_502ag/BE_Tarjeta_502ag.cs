using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_502ag
{
    public class BE_Tarjeta_502ag
    {
        public string Tipo_502ag { get; set; } 
        public string NumeroTarjeta_502ag { get; set; }
        public string CodigoSeguridad_502ag { get; set; }
        public string FechaCaducidad_502ag { get; set; }
        public string Titular_502ag { get; set; }
        public BE_Tarjeta_502ag(string pTipo_502ag, string pNumeroTarjeta_502ag, string pCodigoSeguridad_502ag, string pFechaCaducidad_502ag, string pTitular_502ag)
        {
            Tipo_502ag = pTipo_502ag;
            NumeroTarjeta_502ag = pNumeroTarjeta_502ag;
            CodigoSeguridad_502ag = pCodigoSeguridad_502ag;
            FechaCaducidad_502ag = pFechaCaducidad_502ag;
            Titular_502ag = pTitular_502ag;
        }
    }
}
