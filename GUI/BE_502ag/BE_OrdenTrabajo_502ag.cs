using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_502ag
{
    public class BE_OrdenTrabajo_502ag
    {
        public string CodOrdenTrabajo_502ag { get; set; }
        public string DNICliente_502ag { get; set; }
        public string PatenteVehiculo_502ag { get; set; }
        public DateTime Fecha_502ag { get; set; }
        public TimeSpan Hora_502ag { get; set; }
        public string Estado_502ag { get; set; }
        public string Observaciones_502ag { get; set; }

        public BE_OrdenTrabajo_502ag(string pCodOrdenTrabajo_502ag, string pDNICliente_502ag, string pPatenteVehiculo_502ag, string pEstado_502ag, string pObservaciones_502ag)
        {
            CodOrdenTrabajo_502ag = pCodOrdenTrabajo_502ag;
            DNICliente_502ag = pDNICliente_502ag;
            PatenteVehiculo_502ag = pPatenteVehiculo_502ag;
            Fecha_502ag = DateTime.Now.Date;
            Hora_502ag = DateTime.Now.TimeOfDay;
            Estado_502ag = pEstado_502ag;
            Observaciones_502ag = pObservaciones_502ag;
        }
    }
}
