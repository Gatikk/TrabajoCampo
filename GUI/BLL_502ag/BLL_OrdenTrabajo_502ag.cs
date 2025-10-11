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
    public class BLL_OrdenTrabajo_502ag
    {
        public void GenerarOrdenTrabajo_502ag(BE_Vehiculo_502ag vehiculo_502ag, BE_Cliente_502ag cliente_502ag, string observaciones)
        {
            DAL_OrdenTrabajo_502ag dalOrdenTrabajo_502ag = new DAL_OrdenTrabajo_502ag();
            string fecha_502ag = DateTime.Now.ToString("ddMMyy");
            string ultCodigo_502ag = dalOrdenTrabajo_502ag.ObtenerUltimoCodigoDelDia_502ag(fecha_502ag);
            int numero_502ag = 1;
            if (!string.IsNullOrEmpty(ultCodigo_502ag))
            {
                numero_502ag = int.Parse(ultCodigo_502ag.Substring(fecha_502ag.Length)) + 1;
            }
            string cod_502ag = fecha_502ag + numero_502ag.ToString("D4");
            BE_OrdenTrabajo_502ag ordenTrabajo_502ag = new BE_OrdenTrabajo_502ag(cod_502ag, cliente_502ag.DNI_502ag, vehiculo_502ag.Patente_502ag, "Abierta", observaciones);
            dalOrdenTrabajo_502ag.GenerarOrdenTrabajo_502ag(ordenTrabajo_502ag);

            BLLS_Evento_502ag bllsEvento_502ag = new BLLS_Evento_502ag();
            bllsEvento_502ag.AltaEvento_502ag("Taller", "Generar OT", 3);
            BLL_DigitoVerificador_502ag bllDigitoVerificador_502ag = new BLL_DigitoVerificador_502ag();
            bllDigitoVerificador_502ag.ActualizarDigitoOrdenTrabajo_502ag(CalcularDVH_502ag(), CalcularDVV_502ag());
        }

        public List<BE_OrdenTrabajo_502ag> ObtenerOrdenesDeTrabajoAbierta_502ag()
        {
            DAL_OrdenTrabajo_502ag dalOrdenTrabajo_502ag = new DAL_OrdenTrabajo_502ag();
            return dalOrdenTrabajo_502ag.ObtenerOrdenesDeTrabajoAbierta_502ag();
        }
        public List<BE_OrdenTrabajo_502ag> ObtenerOrdenesDeTrabajoPendienteDePago_502ag()
        {
            DAL_OrdenTrabajo_502ag dalOrdenTrabajo_502ag = new DAL_OrdenTrabajo_502ag();
            return dalOrdenTrabajo_502ag.ObtenerOrdenesDeTrabajoPendienteDePago_502ag();
        }
        public List<BE_OrdenTrabajo_502ag> ObtenerOrdenesDeTrabajoCerrada_502ag()
        {
            DAL_OrdenTrabajo_502ag dalOrdenTrabajo_502ag = new DAL_OrdenTrabajo_502ag();
            return dalOrdenTrabajo_502ag.ObtenerOrdenesDeTrabajoCerrada_502ag();
        }

        public BE_OrdenTrabajo_502ag ObtenerOrdenDeTrabajo_502ag(string codigo_502ag)
        {
            DAL_OrdenTrabajo_502ag dalOrdenTrabajo_502ag = new DAL_OrdenTrabajo_502ag();
            return dalOrdenTrabajo_502ag.ObtenerOrdenDeTrabajo_502ag(codigo_502ag);
        }

        public void ActualizarEstadoOrdenTrabajoAPendienteDePago_502ag(BE_OrdenTrabajo_502ag orden_502ag)
        {
            DAL_OrdenTrabajo_502ag dalOrdenTrabajo_502ag = new DAL_OrdenTrabajo_502ag();
            orden_502ag.Estado_502ag = "Pendiente de Pago";
            dalOrdenTrabajo_502ag.ActualizarEstadoOrdenTrabajo_502ag(orden_502ag);
            BLL_DigitoVerificador_502ag bllDigitoVerificador_502ag = new BLL_DigitoVerificador_502ag();
            bllDigitoVerificador_502ag.ActualizarDigitoOrdenTrabajo_502ag(CalcularDVH_502ag(), CalcularDVV_502ag());
        }

        public void ActualizarEstadoOrdenTrabajoACerrada_502ag(BE_OrdenTrabajo_502ag orden_502ag)
        {
            DAL_OrdenTrabajo_502ag dalOrdenTrabajo_502ag = new DAL_OrdenTrabajo_502ag();
            orden_502ag.Estado_502ag = "Cerrada";
            dalOrdenTrabajo_502ag.ActualizarEstadoOrdenTrabajo_502ag(orden_502ag);
            BLL_DigitoVerificador_502ag bllDigitoVerificador_502ag = new BLL_DigitoVerificador_502ag();
            bllDigitoVerificador_502ag.ActualizarDigitoOrdenTrabajo_502ag(CalcularDVH_502ag(), CalcularDVV_502ag());
        }

        public string CalcularDVH_502ag()
        {
            DAL_OrdenTrabajo_502ag dalOrdenTrabajo_502ag = new DAL_OrdenTrabajo_502ag();
            List<BE_OrdenTrabajo_502ag> ordenesTrabajo_502ag = dalOrdenTrabajo_502ag.ObtenerOrdenesDeTrabajoAbierta_502ag();
            ordenesTrabajo_502ag.AddRange(dalOrdenTrabajo_502ag.ObtenerOrdenesDeTrabajoPendienteDePago_502ag());
            ordenesTrabajo_502ag.AddRange(dalOrdenTrabajo_502ag.ObtenerOrdenesDeTrabajoCerrada_502ag());    
            List<string> horizontales_502ag = new List<string>();
            Encryptador_502ag encryptador_502ag = new Encryptador_502ag();
            foreach (BE_OrdenTrabajo_502ag ordenTrabajo_502ag in ordenesTrabajo_502ag)
            {
                string horizontal_502ag = "";
                horizontal_502ag = ordenTrabajo_502ag.CodOrdenTrabajo_502ag + ordenTrabajo_502ag.DNICliente_502ag + ordenTrabajo_502ag.PatenteVehiculo_502ag + ordenTrabajo_502ag.Fecha_502ag + ordenTrabajo_502ag.Hora_502ag + ordenTrabajo_502ag.Estado_502ag + ordenTrabajo_502ag.Observaciones_502ag;
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
            DAL_OrdenTrabajo_502ag dalOrdenTrabajo_502ag = new DAL_OrdenTrabajo_502ag();
            List<BE_OrdenTrabajo_502ag> ordenesTrabajo_502ag = dalOrdenTrabajo_502ag.ObtenerOrdenesDeTrabajoAbierta_502ag();
            ordenesTrabajo_502ag.AddRange(dalOrdenTrabajo_502ag.ObtenerOrdenesDeTrabajoPendienteDePago_502ag());
            ordenesTrabajo_502ag.AddRange(dalOrdenTrabajo_502ag.ObtenerOrdenesDeTrabajoCerrada_502ag());
            List<string> horizontales_502ag = new List<string>();
            Encryptador_502ag encryptador_502ag = new Encryptador_502ag();
            string codsOrdenes_502ag = "";
            string dnisCliente_502ag = "";
            string patentes_502ag = "";
            string fechas_502ag = "";
            string horas_502ag = "";
            string estados_502ag = "";
            string observaciones_502ag = "";

            foreach (BE_OrdenTrabajo_502ag ordenTrabajo_502ag in ordenesTrabajo_502ag)
            {
                codsOrdenes_502ag += ordenTrabajo_502ag.CodOrdenTrabajo_502ag;
                dnisCliente_502ag += ordenTrabajo_502ag.DNICliente_502ag;
                patentes_502ag += ordenTrabajo_502ag.PatenteVehiculo_502ag;
                fechas_502ag += ordenTrabajo_502ag.Fecha_502ag;
                horas_502ag += ordenTrabajo_502ag.Hora_502ag;
                estados_502ag += ordenTrabajo_502ag.Estado_502ag;
                observaciones_502ag += ordenTrabajo_502ag.Observaciones_502ag;
            }

            string dvv_502ag = codsOrdenes_502ag + dnisCliente_502ag + patentes_502ag + fechas_502ag + horas_502ag + estados_502ag + observaciones_502ag;
            return encryptador_502ag.EncryptadorIrreversible_502ag(dvv_502ag);
        }


    }
}
