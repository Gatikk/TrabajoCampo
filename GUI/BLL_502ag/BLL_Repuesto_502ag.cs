using BE_502ag;
using BLLS_502ag;
using DAL_502ag;
using SERVICIOS_502ag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL_502ag
{
    public class BLL_Repuesto_502ag
    {
        public BE_Repuesto_502ag ObtenerRepuesto_502ag(int codRepuesto_502ag)
        {
            DAL_Repuesto_502ag dalRepuesto_502ag = new DAL_Repuesto_502ag();
            return dalRepuesto_502ag.ObtenerRepuesto_502ag(codRepuesto_502ag);
        }

        public List<BE_Repuesto_502ag> ObtenerListaRepuestos_502ag()
        {
            DAL_Repuesto_502ag dalRepuesto_502ag = new DAL_Repuesto_502ag();
            return dalRepuesto_502ag.ObtenerRepuestos_502ag();
        }

        #region AltaRepuesto
        public void AltaRepuesto_502ag(string descripcion_502ag, decimal precio_502ag, int cantDisponible_502ag)
        {
            DAL_Repuesto_502ag dalRepuesto_502ag = new DAL_Repuesto_502ag();
            BE_Repuesto_502ag repuesto_502ag = new BE_Repuesto_502ag(descripcion_502ag, precio_502ag, cantDisponible_502ag);
            dalRepuesto_502ag.AltaRepuesto_502ag(repuesto_502ag);
            BLLS_Evento_502ag bllsEvento_502ag = new BLLS_Evento_502ag();
            bllsEvento_502ag.AltaEvento_502ag("Maestros", "Añadir Repuesto", 3);
            BLL_DigitoVerificador_502ag bllDigitoVerificador_502ag = new BLL_DigitoVerificador_502ag();
            bllDigitoVerificador_502ag.ActualizarDigitoRepuesto_502ag(CalcularDVH_502ag(), CalcularDVV_502ag());
        }
        #endregion

        public bool VerificarDecimalFormatoCorrecto_502ag(string decimal_502ag)
        {
            Regex reDecimal_502ag = new Regex(@"^\d+(?:[,]\d{1,2})?$");
            if (!reDecimal_502ag.IsMatch(decimal_502ag)) return false;
            return true;

        }

        #region ModificarRepuesto
        public void ModificarRepuesto_502ag(BE_Repuesto_502ag repuesto_502ag, string descripcion_502ag, decimal precio_502ag, int cantDisponible_502ag)
        {
            DAL_Repuesto_502ag dalRepuesto_502ag = new DAL_Repuesto_502ag();
            repuesto_502ag.Descripcion_502ag = descripcion_502ag;
            repuesto_502ag.Precio_502ag = precio_502ag;
            repuesto_502ag.CantidadDisponible_502ag = cantDisponible_502ag;
            dalRepuesto_502ag.ModificarRepuesto_502ag(repuesto_502ag);
            BLLS_Evento_502ag bllsEvento_502ag = new BLLS_Evento_502ag();
            bllsEvento_502ag.AltaEvento_502ag("Maestros", "Modificar Repuesto", 3);
            BLL_DigitoVerificador_502ag bllDigitoVerificador_502ag = new BLL_DigitoVerificador_502ag();
            bllDigitoVerificador_502ag.ActualizarDigitoRepuesto_502ag(CalcularDVH_502ag(), CalcularDVV_502ag());
        }
        #endregion

        #region BajaRepuesto
        public void BajaRepuesto_502ag(BE_Repuesto_502ag repuesto_502ag)
        {
            DAL_Repuesto_502ag dalRepuesto_502ag = new DAL_Repuesto_502ag();
            dalRepuesto_502ag.BajaRepuesto_502ag(repuesto_502ag);
            BLLS_Evento_502ag bllsEvento_502ag = new BLLS_Evento_502ag();
            bllsEvento_502ag.AltaEvento_502ag("Maestros", "Baja Repuesto", 3);
            BLL_DigitoVerificador_502ag bllDigitoVerificador_502ag = new BLL_DigitoVerificador_502ag();
            bllDigitoVerificador_502ag.ActualizarDigitoRepuesto_502ag(CalcularDVH_502ag(), CalcularDVV_502ag());
        }
        #endregion

        public string CalcularDVH_502ag()
        {
            DAL_Repuesto_502ag dalRepuesto_502ag = new DAL_Repuesto_502ag();
            List<BE_Repuesto_502ag> repuestos_502ag = dalRepuesto_502ag.ObtenerRepuestos_502ag();
            List<string> horizontales_502ag = new List<string>();
            Encryptador_502ag encryptador_502ag = new Encryptador_502ag();
            foreach (BE_Repuesto_502ag repuesto_502ag in repuestos_502ag)
            {
                string horizontal_502ag = "";
                horizontal_502ag = repuesto_502ag.Codigo_502ag + repuesto_502ag.Descripcion_502ag + repuesto_502ag.Precio_502ag + repuesto_502ag.CantidadDisponible_502ag;
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
            DAL_Repuesto_502ag dalRepuesto_502ag = new DAL_Repuesto_502ag();
            List<BE_Repuesto_502ag> repuestos_502ag = dalRepuesto_502ag.ObtenerRepuestos_502ag();
            List<string> horizontales_502ag = new List<string>();
            Encryptador_502ag encryptador_502ag = new Encryptador_502ag();
            string codigos_502ag = "";
            string descripciones_502ag = "";
            string precios_502ag = "";
            string cantidadesDisponibles_502ag = "";

            foreach (BE_Repuesto_502ag repuesto_502ag in repuestos_502ag)
            {
                codigos_502ag += repuesto_502ag.Codigo_502ag;
                descripciones_502ag += repuesto_502ag.Descripcion_502ag;
                precios_502ag += repuesto_502ag.Precio_502ag;
                cantidadesDisponibles_502ag += repuesto_502ag.CantidadDisponible_502ag;
            }

            string dvv_502ag = codigos_502ag + descripciones_502ag + precios_502ag + cantidadesDisponibles_502ag;
            return encryptador_502ag.EncryptadorIrreversible_502ag(dvv_502ag);
        }
    }
}