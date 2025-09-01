using BE_502ag;
using BLLS_502ag;
using DAL_502ag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_502ag
{
    public class BLL_DiagnosticoFinal_502ag
    {
        public void GenerarDiagnosticoFinal_502ag(BE_OrdenTrabajo_502ag orden_502ag, string descripcion_502ag, decimal manoObra_502ag, decimal costoPartes_502ag)
        {
            DAL_DiagnosticoFinal_502ag dalDiagnosticoFinal_502ag = new DAL_DiagnosticoFinal_502ag();
            string codigo_502ag = orden_502ag.CodOrdenTrabajo_502ag;
            decimal costoManoObra_502ag = manoObra_502ag * 15000; // 15k sería el costo por hora de mano de obra
            BE_DiagnosticoFinal_502ag diagnosticoFinal_502Ag = new BE_DiagnosticoFinal_502ag(codigo_502ag, descripcion_502ag, costoManoObra_502ag, costoPartes_502ag);
            dalDiagnosticoFinal_502ag.GenerarDiagnosticoFinal_502ag(diagnosticoFinal_502Ag);
            BLL_OrdenTrabajo_502ag bllOrdenTrabajo_502ag = new BLL_OrdenTrabajo_502ag();
            bllOrdenTrabajo_502ag.ActualizarEstadoOrdenTrabajoAPendienteDePago_502ag(orden_502ag);
            BLLS_Evento_502ag bllsEvento_502ag = new BLLS_Evento_502ag();
            bllsEvento_502ag.AltaEvento_502ag("Taller", "Generar Diagnóstico Final", 3);

        }

        public BE_DiagnosticoFinal_502ag ObtenerDiagnosticoFinal_502ag(string codigo_502ag)
        {
            DAL_DiagnosticoFinal_502ag dalDiagnosticoFinal_502ag = new DAL_DiagnosticoFinal_502ag();
            return dalDiagnosticoFinal_502ag.ObtenerDiagnosticoFinal_502ag(codigo_502ag);
        }
    }
}
