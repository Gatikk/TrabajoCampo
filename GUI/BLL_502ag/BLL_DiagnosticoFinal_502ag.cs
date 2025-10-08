using BE_502ag;
using BLLS_502ag;
using DAL_502ag;
using SERVICIOS_502ag;
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
            BLL_DigitoVerificador_502ag bllDigitoVerificador_502ag = new BLL_DigitoVerificador_502ag();
            bllDigitoVerificador_502ag.ActualizarDigitoDiagnosticoFinal_502ag();

        }

        public BE_DiagnosticoFinal_502ag ObtenerDiagnosticoFinal_502ag(string codigo_502ag)
        {
            DAL_DiagnosticoFinal_502ag dalDiagnosticoFinal_502ag = new DAL_DiagnosticoFinal_502ag();
            return dalDiagnosticoFinal_502ag.ObtenerDiagnosticoFinal_502ag(codigo_502ag);
        }

        public string CalcularDVH_502ag()
        {
            DAL_DiagnosticoFinal_502ag dalDiagnosticoFinal_502ag = new DAL_DiagnosticoFinal_502ag();
            List<BE_DiagnosticoFinal_502ag> diagnosticosFinales_502ag = dalDiagnosticoFinal_502ag.ObtenerDiagnosticosFinales_502ag();
            List<string> horizontales_502ag = new List<string>();
            Encryptador_502ag encryptador_502ag = new Encryptador_502ag();
            foreach (BE_DiagnosticoFinal_502ag diagnosticoFinal_502ag in diagnosticosFinales_502ag)
            {
                string horizontal_502ag = "";
                horizontal_502ag = diagnosticoFinal_502ag.CodDiagnosticoFinal_502ag + diagnosticoFinal_502ag.Descripcion_502ag + diagnosticoFinal_502ag.CostoRepuestos_502ag + diagnosticoFinal_502ag.CostoManoObra_502ag;
                horizontal_502ag = encryptador_502ag.EncryptadorIrreversible_502ag(horizontal_502ag);
                horizontales_502ag.Add(horizontal_502ag);
            }
            string dvh_502ag = "";
            foreach (string horizontal_502ag in horizontales_502ag)
            {
                dvh_502ag += horizontal_502ag;
            }
            return encryptador_502ag.EncryptadorIrreversible_502ag(dvh_502ag);
        }

        public string CalcularDVV_502ag()
        {
            DAL_DiagnosticoFinal_502ag dalDiagnosticoFinal_502ag = new DAL_DiagnosticoFinal_502ag();
            List<BE_DiagnosticoFinal_502ag> diagnosticosFinales_502ag = dalDiagnosticoFinal_502ag.ObtenerDiagnosticosFinales_502ag();
            List<string> horizontales_502ag = new List<string>();
            Encryptador_502ag encryptador_502ag = new Encryptador_502ag();
            string codigos_502ag = "";
            string descripciones_502ag = "";
            string costos_502ag = "";
            string manosDeObra_502ag = "";

            foreach (BE_DiagnosticoFinal_502ag diagnosticoFinal_502ag in diagnosticosFinales_502ag)
            {
                codigos_502ag += diagnosticoFinal_502ag.CodDiagnosticoFinal_502ag;
                descripciones_502ag += diagnosticoFinal_502ag.Descripcion_502ag;
                costos_502ag += diagnosticoFinal_502ag.CostoRepuestos_502ag;
                manosDeObra_502ag += diagnosticoFinal_502ag.CostoManoObra_502ag;
            }

            string dvv_502ag = codigos_502ag + descripciones_502ag + costos_502ag + manosDeObra_502ag;
            return encryptador_502ag.EncryptadorIrreversible_502ag(dvv_502ag);
        }


    }
}
