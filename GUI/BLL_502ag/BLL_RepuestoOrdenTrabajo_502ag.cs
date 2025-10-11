using BE_502ag;
using DAL_502ag;
using SERVICIOS_502ag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_502ag
{
    public class BLL_RepuestoOrdenTrabajo_502ag
    {


        public void AltaIntermedia_502ag(string codOT_502ag, int codRepuesto_502ag, int cantidad_502ag)
        {
            DAL_RepuestoOrdenTrabajo_502ag dalRepuestoOT_502ag = new DAL_RepuestoOrdenTrabajo_502ag();

            BLL_Repuesto_502ag bllRepuesto_502ag = new BLL_Repuesto_502ag();
            BE_Repuesto_502ag repuestoModificar_502ag = bllRepuesto_502ag.ObtenerRepuesto_502ag(codRepuesto_502ag);
            repuestoModificar_502ag.CantidadDisponible_502ag -= cantidad_502ag;
            //Se elimina de la tabla repuesto
            bllRepuesto_502ag.ModificarRepuesto_502ag(repuestoModificar_502ag, repuestoModificar_502ag.Descripcion_502ag, repuestoModificar_502ag.Precio_502ag, repuestoModificar_502ag.CantidadDisponible_502ag);
            
            //se agrega en la intermedia
            dalRepuestoOT_502ag.AltaIntermedia_502ag(codOT_502ag, codRepuesto_502ag, cantidad_502ag);

            BLL_DigitoVerificador_502ag bllDigitoVerificador_502ag = new BLL_DigitoVerificador_502ag();
            bllDigitoVerificador_502ag.ActualizarDigitoRepuestoOrdenTrabajo_502ag(CalcularDVH_502ag(), CalcularDVV_502ag());
        }

        public void ModificarIntermedia_502ag(string codOT_502, int codRepuesto_502ag, int cantidadNueva_502ag, int cantidadActual_502ag)
        {
            DAL_RepuestoOrdenTrabajo_502ag dalRepuestoOT_502ag = new DAL_RepuestoOrdenTrabajo_502ag();

            BLL_Repuesto_502ag bllRepuesto_502ag = new BLL_Repuesto_502ag();
            BE_Repuesto_502ag repuestoModificar_502ag = bllRepuesto_502ag.ObtenerRepuesto_502ag(codRepuesto_502ag);
            repuestoModificar_502ag.CantidadDisponible_502ag -= cantidadNueva_502ag;
            //Se elimina de la tabla repuesto
            bllRepuesto_502ag.ModificarRepuesto_502ag(repuestoModificar_502ag, repuestoModificar_502ag.Descripcion_502ag, repuestoModificar_502ag.Precio_502ag, repuestoModificar_502ag.CantidadDisponible_502ag);

            dalRepuestoOT_502ag.ModificarIntermedia_502ag(codOT_502, codRepuesto_502ag, cantidadNueva_502ag + cantidadActual_502ag);
            BLL_DigitoVerificador_502ag bllDigitoVerificador_502ag = new BLL_DigitoVerificador_502ag();
            bllDigitoVerificador_502ag.ActualizarDigitoRepuestoOrdenTrabajo_502ag(CalcularDVH_502ag(), CalcularDVV_502ag());

        }
        public void BajaIntermedia_502ag(string codOT_502ag, int codRepuesto_502ag, int cantidad_502ag)
        {
            DAL_RepuestoOrdenTrabajo_502ag dalRepuestoOT_502ag = new DAL_RepuestoOrdenTrabajo_502ag();
            BLL_Repuesto_502ag bllRepuesto_502ag = new BLL_Repuesto_502ag();
            BE_Repuesto_502ag repuestoModificar_502ag = bllRepuesto_502ag.ObtenerRepuesto_502ag(codRepuesto_502ag);
            repuestoModificar_502ag.CantidadDisponible_502ag += cantidad_502ag;
            bllRepuesto_502ag.ModificarRepuesto_502ag(repuestoModificar_502ag, repuestoModificar_502ag.Descripcion_502ag, repuestoModificar_502ag.Precio_502ag, repuestoModificar_502ag.CantidadDisponible_502ag);
            dalRepuestoOT_502ag.BajaIntermedia_502ag(codOT_502ag, codRepuesto_502ag);
            BLL_DigitoVerificador_502ag bllDigitoVerificador_502ag = new BLL_DigitoVerificador_502ag();
            bllDigitoVerificador_502ag.ActualizarDigitoRepuestoOrdenTrabajo_502ag(CalcularDVH_502ag(), CalcularDVV_502ag());
        }
        public List<BE_RepuestoOrdenTrabajo_502ag> ObtenerDatosIntermedia_502ag(string codOT_502ag)
        {
            DAL_RepuestoOrdenTrabajo_502ag dalRepuestoOT_502ag = new DAL_RepuestoOrdenTrabajo_502ag();
            return dalRepuestoOT_502ag.ObtenerDatosIntermedia_502ag(codOT_502ag);
        }
        public string CalcularDVH_502ag()
        {
            DAL_RepuestoOrdenTrabajo_502ag dalRepuestoOT_502ag = new DAL_RepuestoOrdenTrabajo_502ag();
            List<BE_RepuestoOrdenTrabajo_502ag> repuestosOT_502ag = dalRepuestoOT_502ag.ObtenerTodosLosDatosIntermedia_502ag();
            List<string> horizontales_502ag = new List<string>();
            Encryptador_502ag encryptador_502ag = new Encryptador_502ag();
            foreach (BE_RepuestoOrdenTrabajo_502ag repuestoOT_502ag in repuestosOT_502ag)
            {
                string horizontal_502ag = "";
                horizontal_502ag = repuestoOT_502ag.CodigoOT_502ag + repuestoOT_502ag.CodigoRepuesto_502ag + repuestoOT_502ag.Cantidad_502ag;
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
            DAL_RepuestoOrdenTrabajo_502ag dalRepuesto_502ag = new DAL_RepuestoOrdenTrabajo_502ag();
            List<BE_RepuestoOrdenTrabajo_502ag> repuestosOT_502ag = dalRepuesto_502ag.ObtenerTodosLosDatosIntermedia_502ag();
            List<string> horizontales_502ag = new List<string>();
            Encryptador_502ag encryptador_502ag = new Encryptador_502ag();
            string codigosOT_502ag = "";
            string codigosRepuesto_502ag = "";
            string cantidad_502ag = "";

            foreach(BE_RepuestoOrdenTrabajo_502ag repuestoOT_502ag in repuestosOT_502ag)
            {
                codigosOT_502ag += repuestoOT_502ag.CodigoOT_502ag;
                codigosRepuesto_502ag += repuestoOT_502ag.CodigoRepuesto_502ag;
                cantidad_502ag += repuestoOT_502ag.Cantidad_502ag;
            }

            string dvv_502ag = codigosOT_502ag + codigosRepuesto_502ag + cantidad_502ag;
            return encryptador_502ag.EncryptadorIrreversible_502ag(dvv_502ag);
        }

    }
}
