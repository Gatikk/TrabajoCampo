using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_502ag;
using BLLS_502ag;
using DAL_502ag;

namespace BLL_502ag
{
    public class BLL_FacturaTaller_502ag
    {
        public void GenerarFacturaTaller_502ag(BE_OrdenTrabajo_502ag ordenTrabajo_502ag, string metodoPago_502ag)
        {
            string codigo_502ag = ordenTrabajo_502ag.CodOrdenTrabajo_502ag;
            string dniCliente_502ag = ordenTrabajo_502ag.DNICliente_502ag;
            BLL_Cliente_502ag bllCliente_502ag = new BLL_Cliente_502ag();
            BE_Cliente_502ag cliente_502ag = bllCliente_502ag.ObtenerCliente_502ag(dniCliente_502ag);
            string nombreCliente_502ag = cliente_502ag.Nombre_502ag;
            string apellidoCliente_502ag = cliente_502ag.Apellido_502ag;
            BLL_DiagnosticoFinal_502ag bLL_DiagnosticoFinal_502ag= new BLL_DiagnosticoFinal_502ag();
            BE_DiagnosticoFinal_502ag diagnosticoFinal_502ag = bLL_DiagnosticoFinal_502ag.ObtenerDiagnosticoFinal_502ag(codigo_502ag);
            decimal monto_502ag = diagnosticoFinal_502ag.CostoManoObra_502ag + diagnosticoFinal_502ag.CostoRepuestos_502ag;
            
            BE_FacturaTaller_502ag factura_502ag = new BE_FacturaTaller_502ag(codigo_502ag, dniCliente_502ag, nombreCliente_502ag, apellidoCliente_502ag, metodoPago_502ag, monto_502ag, diagnosticoFinal_502ag.Descripcion_502ag);
            DAL_FacturaTaller_502ag dalFacturaTaller_502ag = new DAL_FacturaTaller_502ag();
            dalFacturaTaller_502ag.GenerarFacturaTaller_502ag(factura_502ag);

            BLLS_Evento_502ag bllsEvento_502ag = new BLLS_Evento_502ag();
            bllsEvento_502ag.AltaEvento_502ag("Taller", "Generar Factura", 3);
        }

        public List<BE_FacturaTaller_502ag> ObtenerFacturasTaller_502ag()
        {
            DAL_FacturaTaller_502ag dalFacturaTaller_502ag = new DAL_FacturaTaller_502ag();
            return dalFacturaTaller_502ag.ObtenerFacturasTaller_502ag();
        }

        public BE_FacturaTaller_502ag ObtenerFactura_502ag(string codigo_502ag)
        {
            DAL_FacturaTaller_502ag dalFacturaTaller_502ag = new DAL_FacturaTaller_502ag();
            return dalFacturaTaller_502ag.ObtenerFactura_502ag(codigo_502ag);
        }
    }
}
