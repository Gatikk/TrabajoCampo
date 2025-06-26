using BE_502ag;
using DAL_502ag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_502ag
{
    public class BLL_Factura_502ag
    {
        #region DefinicionFactura
        //AltaFactura
        public BE_Factura_502ag AltaFactura_502ag(string codCombustible_502ag, string nomCombustible_502ag)
        {
            DAL_Factura_502ag dalFactura_502ag = new DAL_Factura_502ag();
            BE_Factura_502ag factura_502ag = new BE_Factura_502ag(0, int.Parse(codCombustible_502ag), nomCombustible_502ag);
            factura_502ag.IsFacturado_502ag = false;
            factura_502ag.EstadoFactura_502ag = 1;
            factura_502ag.Fecha_502ag = DateTime.Now.Date;
            factura_502ag.Hora_502ag = DateTime.Now.TimeOfDay;
            return dalFactura_502ag.AltaFactura_502ag(factura_502ag);
            
        }
        //CargaFinalizada
        public void ActualizarFacturaCargaFinalizada_502ag(BE_Factura_502ag factura_502ag)
        {
            DAL_Factura_502ag dalFactura_502ag = new DAL_Factura_502ag();
            dalFactura_502ag.ActualizarFacturaRecienCargada_502ag(factura_502ag);
        }
        //ClienteIdentificado
        public void ActualizarFacturaClienteIdentificado_502ag(BE_Factura_502ag factura_502ag)
        {
            DAL_Factura_502ag dalFactura_502ag = new DAL_Factura_502ag();
            dalFactura_502ag.ActualizarFacturaClienteIdentificado_502ag(factura_502ag);
        }
        //FacturaFinalizada
        public void ActualizarFacturaFinalizada_502ag(BE_Factura_502ag factura_502ag)
        {
            DAL_Factura_502ag dalFactura_502ag = new DAL_Factura_502ag();
            dalFactura_502ag.ActualizarFacturaFinalizada_502ag(factura_502ag);
        }
        #endregion
        public List<BE_Factura_502ag> ObtenerListaFacturasNoFacturadas_502ag()
        {
            DAL_Factura_502ag dalFactura_502ag = new DAL_Factura_502ag();
            return dalFactura_502ag.ObtenerListaFacturasNoFacturadas_502ag();
        }
        public BE_Factura_502ag ObtenerFactura_502ag(int codFactura_502ag)
        {
            DAL_Factura_502ag dalFactura_502ag = new DAL_Factura_502ag();
            return dalFactura_502ag.ObtenerFactura_502ag(codFactura_502ag);
        }
        public List<BE_Factura_502ag> ObtenerListaFacturas_502ag()
        {
            DAL_Factura_502ag dalFactura_502ag = new DAL_Factura_502ag();
            return dalFactura_502ag.ObtenerListaFacturas_502ag();
        }
        public void EliminarFacturasEstadoPendienteDeCarga_502ag(int codCombustible_502ag)
        {
            DAL_Factura_502ag dalFactura_502ag = new DAL_Factura_502ag();
            dalFactura_502ag.EliminarFacturasEstadoPendienteDeCarga_502ag(codCombustible_502ag);
        }

    }
}
