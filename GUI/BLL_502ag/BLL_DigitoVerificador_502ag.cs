using BE_502ag;
using DAL_502ag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_502ag
{
    public class BLL_DigitoVerificador_502ag
    {
        public void ActualizarDigitos_502ag()
        {
            ActualizarDigitoCliente_502ag();
            ActualizarDigitoFactura_502ag();
            ActualizarDigitoCombustible_502ag();
            ActualizarDigitoOrdenTrabajo_502ag();
            ActualizarDigitoVehiculo_502ag();
            ActualizarDigitoRepuesto_502ag();
            ActualizarDigitoFacturaTaller_502ag();
            ActualizarDigitoRepuestoOrdenTrabajo_502ag();
            ActualizarDigitoDiagnosticoFinal_502ag();
        }


        public void ActualizarDigitoCliente_502ag()
        {
            DAL_DigitoVerificador_502ag dalDigitoVerificador_502ag = new DAL_DigitoVerificador_502ag();
            BLL_Cliente_502ag bllCliente_502ag = new BLL_Cliente_502ag();
            string dvh_502ag = bllCliente_502ag.CalcularDVH_502ag();
            string dvv_502ag = bllCliente_502ag.CalcularDVV_502ag();
            dalDigitoVerificador_502ag.ActualizarDigitos_502ag("Cliente_502ag", dvh_502ag, dvv_502ag);
        }

        public bool CompararDigitoCliente_502ag()
        {
            DAL_DigitoVerificador_502ag dalDigitoVerificador_502ag = new DAL_DigitoVerificador_502ag();
            BLL_Cliente_502ag bllCliente_502ag = new BLL_Cliente_502ag();
            string dvhMemoria_502ag = bllCliente_502ag.CalcularDVH_502ag();
            string dvvMemoria_502ag = bllCliente_502ag.CalcularDVV_502ag();
            string dvhBD_502ag = dalDigitoVerificador_502ag.ObtenerDVH_502ag("Cliente_502ag");
            string dvvBD_502ag = dalDigitoVerificador_502ag.ObtenerDVV_502ag("Cliente_502ag");
            if(dvhMemoria_502ag == dvhBD_502ag && dvvMemoria_502ag == dvvBD_502ag)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ActualizarDigitoFactura_502ag()
        {
            DAL_DigitoVerificador_502ag dalDigitoVerificador_502ag = new DAL_DigitoVerificador_502ag();
            BLL_Factura_502ag bllFactura_502ag = new BLL_Factura_502ag();
            string dvh_502ag = bllFactura_502ag.CalcularDVH_502ag();
            string dvv_502ag = bllFactura_502ag.CalcularDVV_502ag();
            dalDigitoVerificador_502ag.ActualizarDigitos_502ag("Factura_502ag", dvh_502ag, dvv_502ag);
        }
        public bool CompararDigitoFactura_502ag()
        {
            DAL_DigitoVerificador_502ag dalDigitoVerificador_502ag = new DAL_DigitoVerificador_502ag();
            BLL_Factura_502ag bllFactura_502ag = new BLL_Factura_502ag();
            string dvhMemoria_502ag = bllFactura_502ag.CalcularDVH_502ag();
            string dvvMemoria_502ag = bllFactura_502ag.CalcularDVV_502ag();
            string dvhBD_502ag = dalDigitoVerificador_502ag.ObtenerDVH_502ag("Factura_502ag");
            string dvvBD_502ag = dalDigitoVerificador_502ag.ObtenerDVV_502ag("Factura_502ag");
            if (dvhMemoria_502ag == dvhBD_502ag && dvvMemoria_502ag == dvvBD_502ag)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void ActualizarDigitoCombustible_502ag()
        {
            DAL_DigitoVerificador_502ag dalDigitoVerificador_502ag = new DAL_DigitoVerificador_502ag();
            BLL_Combustible_502ag bllCombustible_502ag = new BLL_Combustible_502ag();
            string dvh_502ag = bllCombustible_502ag.CalcularDVH_502ag();
            string dvv_502ag = bllCombustible_502ag.CalcularDVV_502ag();
            dalDigitoVerificador_502ag.ActualizarDigitos_502ag("Combustible_502ag", dvh_502ag, dvv_502ag);
        }

        public bool CompararDigitoCombustible_502ag()
        {
            DAL_DigitoVerificador_502ag dalDigitoVerificador_502ag = new DAL_DigitoVerificador_502ag();
            BLL_Combustible_502ag bllCombustible_502ag = new BLL_Combustible_502ag();
            string dvhMemoria_502ag = bllCombustible_502ag.CalcularDVH_502ag();
            string dvvMemoria_502ag = bllCombustible_502ag.CalcularDVV_502ag();
            string dvhBD_502ag = dalDigitoVerificador_502ag.ObtenerDVH_502ag("Combustible_502ag");
            string dvvBD_502ag = dalDigitoVerificador_502ag.ObtenerDVV_502ag("Combustible_502ag");
            if (dvhMemoria_502ag == dvhBD_502ag && dvvMemoria_502ag == dvvBD_502ag)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ActualizarDigitoFacturaTaller_502ag()
        {
            
            DAL_DigitoVerificador_502ag dalDigitoVerificador_502ag = new DAL_DigitoVerificador_502ag();
            BLL_FacturaTaller_502ag bllFacturaTaller_50ag = new BLL_FacturaTaller_502ag();
            string dvh_502ag = bllFacturaTaller_50ag.CalcularDVH_502ag();
            string dvv_502ag = bllFacturaTaller_50ag.CalcularDVV_502ag();
            dalDigitoVerificador_502ag.ActualizarDigitos_502ag("FacturaTaller_502ag", dvh_502ag, dvv_502ag);
        }
        public bool CompararDigitoFacturaTaller_502ag()
        {
            DAL_DigitoVerificador_502ag dalDigitoVerificador_502ag = new DAL_DigitoVerificador_502ag();
            BLL_FacturaTaller_502ag bllFacturaTaller_502ag = new BLL_FacturaTaller_502ag();
            string dvhMemoria_502ag = bllFacturaTaller_502ag.CalcularDVH_502ag();
            string dvvMemoria_502ag = bllFacturaTaller_502ag.CalcularDVV_502ag();
            string dvhBD_502ag = dalDigitoVerificador_502ag.ObtenerDVH_502ag("FacturaTaller_502ag");
            string dvvBD_502ag = dalDigitoVerificador_502ag.ObtenerDVV_502ag("FacturaTaller_502ag");
            if (dvhMemoria_502ag == dvhBD_502ag && dvvMemoria_502ag == dvvBD_502ag)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public void ActualizarDigitoOrdenTrabajo_502ag()
        {

            DAL_DigitoVerificador_502ag dalDigitoVerificador_502ag = new DAL_DigitoVerificador_502ag();
            BLL_OrdenTrabajo_502ag bllOrdenTrabajo_502ag = new BLL_OrdenTrabajo_502ag();
            string dvh_502ag = bllOrdenTrabajo_502ag.CalcularDVH_502ag();
            string dvv_502ag = bllOrdenTrabajo_502ag.CalcularDVV_502ag();
            dalDigitoVerificador_502ag.ActualizarDigitos_502ag("OrdenTrabajo_502ag", dvh_502ag, dvv_502ag);
        }
        public bool CompararDigitoOrdenTrabajo_502ag()
        {
            DAL_DigitoVerificador_502ag dalDigitoVerificador_502ag = new DAL_DigitoVerificador_502ag();
            BLL_OrdenTrabajo_502ag bllOrdenTrabajo_502ag = new BLL_OrdenTrabajo_502ag();
            string dvhMemoria_502ag = bllOrdenTrabajo_502ag.CalcularDVH_502ag();
            string dvvMemoria_502ag = bllOrdenTrabajo_502ag.CalcularDVV_502ag();
            string dvhBD_502ag = dalDigitoVerificador_502ag.ObtenerDVH_502ag("OrdenTrabajo_502ag");
            string dvvBD_502ag = dalDigitoVerificador_502ag.ObtenerDVV_502ag("OrdenTrabajo_502ag");
            if (dvhMemoria_502ag == dvhBD_502ag && dvvMemoria_502ag == dvvBD_502ag)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void ActualizarDigitoRepuesto_502ag()
        {
            DAL_DigitoVerificador_502ag dalDigitoVerificador_502ag = new DAL_DigitoVerificador_502ag();
            BLL_Repuesto_502ag bllRepuesto_502ag = new BLL_Repuesto_502ag();
            string dvh_502ag = bllRepuesto_502ag.CalcularDVH_502ag();
            string dvv_502ag = bllRepuesto_502ag.CalcularDVV_502ag();
            dalDigitoVerificador_502ag.ActualizarDigitos_502ag("Repuesto_502ag", dvh_502ag, dvv_502ag);
        }
        public bool CompararDigitoRepuesto_502ag()
        {
            DAL_DigitoVerificador_502ag dalDigitoVerificador_502ag = new DAL_DigitoVerificador_502ag();
            BLL_Repuesto_502ag bllRepuesto_502ag = new BLL_Repuesto_502ag();
            string dvhMemoria_502ag = bllRepuesto_502ag.CalcularDVH_502ag();
            string dvvMemoria_502ag = bllRepuesto_502ag.CalcularDVV_502ag();
            string dvhBD_502ag = dalDigitoVerificador_502ag.ObtenerDVH_502ag("Repuesto_502ag");
            string dvvBD_502ag = dalDigitoVerificador_502ag.ObtenerDVV_502ag("Repuesto_502ag");
            if (dvhMemoria_502ag == dvhBD_502ag && dvvMemoria_502ag == dvvBD_502ag)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void ActualizarDigitoRepuestoOrdenTrabajo_502ag()
        {
            DAL_DigitoVerificador_502ag dalDigitoVerificador_502ag = new DAL_DigitoVerificador_502ag();
            BLL_RepuestoOrdenTrabajo_502ag bllRepuestoOrdenTrabajo_502ag = new BLL_RepuestoOrdenTrabajo_502ag();
            string dvh_502ag = bllRepuestoOrdenTrabajo_502ag.CalcularDVH_502ag();
            string dvv_502ag = bllRepuestoOrdenTrabajo_502ag.CalcularDVV_502ag();
            dalDigitoVerificador_502ag.ActualizarDigitos_502ag("RepuestoOrdenTrabajo_502ag", dvh_502ag, dvv_502ag);
        }
        public bool CompararDigitoRepuestoOrdenTrabajo_502ag()
        {
            DAL_DigitoVerificador_502ag dalDigitoVerificador_502ag = new DAL_DigitoVerificador_502ag();
            BLL_RepuestoOrdenTrabajo_502ag bllRepuestoOrdenTrabajo_502ag = new BLL_RepuestoOrdenTrabajo_502ag();
            string dvhMemoria_502ag = bllRepuestoOrdenTrabajo_502ag.CalcularDVH_502ag();
            string dvvMemoria_502ag = bllRepuestoOrdenTrabajo_502ag.CalcularDVV_502ag();
            string dvhBD_502ag = dalDigitoVerificador_502ag.ObtenerDVH_502ag("RepuestoOrdenTrabajo_502ag");
            string dvvBD_502ag = dalDigitoVerificador_502ag.ObtenerDVV_502ag("RepuestoOrdenTrabajo_502ag");
            if (dvhMemoria_502ag == dvhBD_502ag && dvvMemoria_502ag == dvvBD_502ag)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void ActualizarDigitoVehiculo_502ag()
        {
            DAL_DigitoVerificador_502ag dalDigitoVerificador_502ag = new DAL_DigitoVerificador_502ag();
            BLL_Vehiculo_502ag bllVehiculo_502ag = new BLL_Vehiculo_502ag();
            string dvh_502ag = bllVehiculo_502ag.CalcularDVH_502ag();
            string dvv_502ag = bllVehiculo_502ag.CalcularDVV_502ag();
            dalDigitoVerificador_502ag.ActualizarDigitos_502ag("Vehiculo_502ag", dvh_502ag, dvv_502ag);
        }
        public bool CompararDigitoVehiculo_502ag()
        {
            DAL_DigitoVerificador_502ag dalDigitoVerificador_502ag = new DAL_DigitoVerificador_502ag();
            BLL_Vehiculo_502ag bllVehiculo_502ag = new BLL_Vehiculo_502ag();
            string dvhMemoria_502ag = bllVehiculo_502ag.CalcularDVH_502ag();
            string dvvMemoria_502ag = bllVehiculo_502ag.CalcularDVV_502ag();
            string dvhBD_502ag = dalDigitoVerificador_502ag.ObtenerDVH_502ag("Vehiculo_502ag");
            string dvvBD_502ag = dalDigitoVerificador_502ag.ObtenerDVV_502ag("Vehiculo_502ag");
            if (dvhMemoria_502ag == dvhBD_502ag && dvvMemoria_502ag == dvvBD_502ag)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void ActualizarDigitoDiagnosticoFinal_502ag()
        {
            DAL_DigitoVerificador_502ag dalDigitoVerificador_502ag = new DAL_DigitoVerificador_502ag();
            BLL_DiagnosticoFinal_502ag bllDiagnosticoFinal_502ag = new BLL_DiagnosticoFinal_502ag();
            string dvh_502ag = bllDiagnosticoFinal_502ag.CalcularDVH_502ag();
            string dvv_502ag = bllDiagnosticoFinal_502ag.CalcularDVV_502ag();
            dalDigitoVerificador_502ag.ActualizarDigitos_502ag("DiagnosticoFinal_502ag", dvh_502ag, dvv_502ag);
        }
        public bool CompararDigitoDiagnosticoFinal_502ag()
        {
            DAL_DigitoVerificador_502ag dalDigitoVerificador_502ag = new DAL_DigitoVerificador_502ag();
            BLL_DiagnosticoFinal_502ag bllDiagnosticoFinal_502ag = new BLL_DiagnosticoFinal_502ag();
            string dvhMemoria_502ag = bllDiagnosticoFinal_502ag.CalcularDVH_502ag();
            string dvvMemoria_502ag = bllDiagnosticoFinal_502ag.CalcularDVV_502ag();
            string dvhBD_502ag = dalDigitoVerificador_502ag.ObtenerDVH_502ag("DiagnosticoFinal_502ag");
            string dvvBD_502ag = dalDigitoVerificador_502ag.ObtenerDVV_502ag("DiagnosticoFinal_502ag");
            if (dvhMemoria_502ag == dvhBD_502ag && dvvMemoria_502ag == dvvBD_502ag)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CompararDigitos()
        {
            if (CompararDigitoCliente_502ag() && CompararDigitoCombustible_502ag() && CompararDigitoFactura_502ag()&& CompararDigitoOrdenTrabajo_502ag() && CompararDigitoVehiculo_502ag() && CompararDigitoRepuesto_502ag() && CompararDigitoFacturaTaller_502ag() && CompararDigitoRepuestoOrdenTrabajo_502ag() && CompararDigitoDiagnosticoFinal_502ag())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
