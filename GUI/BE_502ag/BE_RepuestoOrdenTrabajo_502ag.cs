using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_502ag
{
    public class BE_RepuestoOrdenTrabajo_502ag
    {
        public string CodigoOT_502ag { get; set; }
        public int CodigoRepuesto_502ag { get; set; }
        public int Cantidad_502ag { get; set; }

        public BE_RepuestoOrdenTrabajo_502ag(string pCodigoOT_502ag, int pCodigoRepuesto_502ag, int pCantidad_502ag)
        {
            CodigoOT_502ag = pCodigoOT_502ag;
            CodigoRepuesto_502ag = pCodigoRepuesto_502ag;
            Cantidad_502ag = pCantidad_502ag;
        }
    }
}
