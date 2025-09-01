using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_502ag
{
    public class BE_DiagnosticoFinal_502ag
    {
        public string CodDiagnosticoFinal_502ag { get; set; }
        public string Descripcion_502ag { get; set; }
        public decimal CostoManoObra_502ag { get; set; }
        public decimal CostoRepuestos_502ag { get; set; }
        public BE_DiagnosticoFinal_502ag(string pCodDiagnosticoFinal_502ag, string pDescripcion_502ag, decimal pCostoManoObra_502ag, decimal pCostoRepuestos_502ag)
        {
            CodDiagnosticoFinal_502ag = pCodDiagnosticoFinal_502ag;
            Descripcion_502ag = pDescripcion_502ag;
            CostoManoObra_502ag = pCostoManoObra_502ag;
            CostoRepuestos_502ag = pCostoRepuestos_502ag;
        }
    }
}
