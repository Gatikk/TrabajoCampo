using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_502ag
{
    public class BE_FacturaTaller_502ag
    {
        public string CodFactura_502ag { get; set; }
        public string DNICliente_502ag { get; set; }
        public string NombreCliente_502ag { get; set; }
        public string ApellidoCliente_502ag { get; set; }
        public DateTime Fecha_502ag { get; set; }
        public TimeSpan Hora_502ag { get; set; }
        public string MetodoPago_502ag { get; set; }
        public decimal Monto_502ag { get; set; }
        public string DescripcionFinal_502ag { get; set; }

        public BE_FacturaTaller_502ag(string pCodFactura_502ag, string pDNICliente_502ag, string pMetodoPago_502ag, decimal pMonto_502ag, string pDescripcionFinal_502ag)
        {
            CodFactura_502ag = pCodFactura_502ag;
            DNICliente_502ag = pDNICliente_502ag;
            Fecha_502ag = DateTime.Now;
            Hora_502ag = DateTime.Now.TimeOfDay;
            MetodoPago_502ag = pMetodoPago_502ag;
            Monto_502ag = pMonto_502ag;
            DescripcionFinal_502ag = pDescripcionFinal_502ag;
        }


    }
}
