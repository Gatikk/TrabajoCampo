using BE_502ag;
using BLLS_502ag;
using DAL_502ag;
using SERVICIOS_502ag;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL_502ag
{
    public class BLL_Combustible_502ag
    {
        public BE_Combustible_502ag ObtenerCombustible_502ag(string codCombustible_502ag)
        {
            DAL_Combustible_502ag dalCombustible_502ag = new DAL_Combustible_502ag();
            return dalCombustible_502ag.ObtenerCombustible_502ag(codCombustible_502ag);
        }

        public List<BE_Combustible_502ag> ObtenerListaCombustibles_502ag()
        {
            DAL_Combustible_502ag dalCombustible_502ag = new DAL_Combustible_502ag();
            return dalCombustible_502ag.ObtenerListaCombustibles_502ag();
        }

        #region AltaCombustible
        public void AltaCombustible_502ag(string codCombustible_502ag, string nombre_502ag, decimal cantDisponible_502ag, decimal precioPorLitro_502ag)
        {
            DAL_Combustible_502ag dalCombustible_502ag = new DAL_Combustible_502ag();
            BE_Combustible_502ag combustible_502ag = new BE_Combustible_502ag(codCombustible_502ag, nombre_502ag, cantDisponible_502ag, precioPorLitro_502ag);
            dalCombustible_502ag.AltaCombustible_502ag(combustible_502ag);
            BLLS_Evento_502ag bllsEvento_502ag = new BLLS_Evento_502ag();
            bllsEvento_502ag.AltaEvento_502ag("Maestros", "Añadir Combustible", 2);
            BLL_DigitoVerificador_502ag bllDigitoVerificador_502ag = new BLL_DigitoVerificador_502ag();
            bllDigitoVerificador_502ag.ActualizarDigitoCombustible_502ag();
        }
        public bool VerificarDatosIngresadosAlta_502ag(string codCombustible_502ag, string nombre_502ag, string cantDisponible_502ag, string precioPorLitro_502ag)
        {
            bool esValido_502ag = true;
            Regex reCodigo_502ag = new Regex(@"^\d{3}$");
            Regex reDecimal_502ag = new Regex(@"^\d+(?:[,]\d{1,2})?$");
            if (!reCodigo_502ag.IsMatch(codCombustible_502ag)) esValido_502ag = false;
            if (!reDecimal_502ag.IsMatch(cantDisponible_502ag))
            {
                esValido_502ag = false;
            }
            else
            {
                if (decimal.Parse(cantDisponible_502ag) < 0 || decimal.Parse(cantDisponible_502ag) > 50000) esValido_502ag = false;
            }
            if (!reDecimal_502ag.IsMatch(precioPorLitro_502ag))
            {
                esValido_502ag = false;
            }
            else
            {
                if(decimal.Parse(precioPorLitro_502ag) < 0) { esValido_502ag=false;}
            }
            return esValido_502ag;
        }
        #endregion

        public bool VerificarCodigo_502ag (string codCombustible_502ag)
        {
            Regex reCodigo_502ag = new Regex(@"^\d{3}$");
            if (!reCodigo_502ag.IsMatch(codCombustible_502ag)) return false;
            return true;
        }
        public bool VerificarDecimalFormatoCorrecto_502ag(string decimal_502ag)
        {
            Regex reDecimal_502ag = new Regex(@"^\d+(?:[,]\d{1,2})?$");
            if (!reDecimal_502ag.IsMatch(decimal_502ag)) return false;
            return true;

        }
        public bool VerificarCantidadCombustibleCorrecta_502ag(string cantCombustible_502ag) 
        {
            if (decimal.Parse(cantCombustible_502ag) < 0 || decimal.Parse(cantCombustible_502ag) > 50000) return false;
            return true;
        }
        public bool VerificarPrecioPorLitroCorrecto_502ag(string precioPorLitro_502ag)
        {
            if (decimal.Parse(precioPorLitro_502ag) < 0) return false;
            return true;
        }

        #region ModificarCombustible
        public void ModificarCombustible_502ag(BE_Combustible_502ag combustible_502ag, string nombre_502ag, decimal cantDisponible_502ag, decimal precioPorLitro_502ag)
        {
            DAL_Combustible_502ag dalCombustible_502ag = new DAL_Combustible_502ag();
            combustible_502ag.Nombre_502ag = nombre_502ag;
            combustible_502ag.CantDisponible_502ag = cantDisponible_502ag;
            combustible_502ag.PrecioPorLitro_502ag = precioPorLitro_502ag;
            dalCombustible_502ag.ModificarCombustible_502ag(combustible_502ag);
            BLLS_Evento_502ag bllsEvento_502ag = new BLLS_Evento_502ag();
            bllsEvento_502ag.AltaEvento_502ag("Maestros", "Modificar Combustible", 2);
            BLL_DigitoVerificador_502ag bllDigitoVerificador_502ag = new BLL_DigitoVerificador_502ag();
            bllDigitoVerificador_502ag.ActualizarDigitoCombustible_502ag();
        }
        public bool VerificarDatosIngresadosModificar_502ag(string nombre_502ag, string cantDisponible_502ag, string precioPorLitro_502ag)
        {
            bool esValido_502ag = true;
            Regex reDecimal_502ag = new Regex(@"^\d+(?:[,]\d{1,2})?$");
            if (!reDecimal_502ag.IsMatch(cantDisponible_502ag))
            {
                esValido_502ag = false;
            }
            else
            {
                if (decimal.Parse(cantDisponible_502ag) < 0 || decimal.Parse(cantDisponible_502ag) > 50000) esValido_502ag = false;
            }
            if (!reDecimal_502ag.IsMatch(precioPorLitro_502ag))
            {
                esValido_502ag = false;
            }
            else
            {
                if (decimal.Parse(precioPorLitro_502ag) < 0) { esValido_502ag = false; }
            }
            return esValido_502ag;
        }
        #endregion

        #region BajaCombustible
        public void BajaCombustible_502ag(BE_Combustible_502ag combustible_502ag)
        {
            DAL_Combustible_502ag dalCombustible_502ag = new DAL_Combustible_502ag();
            BLL_Factura_502ag bllFactura_502ag = new BLL_Factura_502ag();
            dalCombustible_502ag.BajaCombustible_520ag(combustible_502ag);
            bllFactura_502ag.EliminarFacturasEstadoPendienteDeCarga_502ag(int.Parse(combustible_502ag.CodCombustible_502ag));
            BLLS_Evento_502ag bllsEvento_502ag = new BLLS_Evento_502ag();
            bllsEvento_502ag.AltaEvento_502ag("Maestros", "Baja Combustible", 2);
            BLL_DigitoVerificador_502ag bllDigitoVerificador_502ag = new BLL_DigitoVerificador_502ag();
            bllDigitoVerificador_502ag.ActualizarDigitoCombustible_502ag();
            bllDigitoVerificador_502ag.ActualizarDigitoFactura_502ag();
        }
        #endregion

        public void ActualizarExistenciaCombustible_502ag(BE_Combustible_502ag combustible_502ag)
        {
            DAL_Combustible_502ag dalCombustible_502ag = new DAL_Combustible_502ag();
            dalCombustible_502ag.ActualizarExistenciaCombustible_502ag(combustible_502ag);
            BLL_DigitoVerificador_502ag bllDigitoVerificador_502ag = new BLL_DigitoVerificador_502ag();
            bllDigitoVerificador_502ag.ActualizarDigitoCombustible_502ag();
        }
        public string CalcularDVH_502ag()
        {
            DAL_Combustible_502ag dalCombustible_502ag = new DAL_Combustible_502ag();
            List<BE_Combustible_502ag> combustibles_502ag = dalCombustible_502ag.ObtenerListaCombustibles_502ag();
            List<string> horizontales_502ag = new List<string>();
            Encryptador_502ag encryptador_502ag = new Encryptador_502ag();
            foreach (BE_Combustible_502ag combustible_502ag in combustibles_502ag)
            {
                string horizontal_502ag = "";
                horizontal_502ag = combustible_502ag.CodCombustible_502ag + combustible_502ag.Nombre_502ag + combustible_502ag.CantDisponible_502ag + combustible_502ag.PrecioPorLitro_502ag;
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
            DAL_Combustible_502ag dalCombustible_502ag = new DAL_Combustible_502ag();
            List<BE_Combustible_502ag> combustibles_502ag = dalCombustible_502ag.ObtenerListaCombustibles_502ag();
            List<string> horizontales_502ag = new List<string>();
            Encryptador_502ag encryptador_502ag = new Encryptador_502ag();
            string codsCombustible_502ag = "";
            string nombres_502ag = "";
            string cantsDisponible_502ag = "";
            string preciosPorLitro_502ag = "";

            foreach (BE_Combustible_502ag combustible_502ag in combustibles_502ag)
            {
                codsCombustible_502ag += combustible_502ag.CodCombustible_502ag;
                nombres_502ag += combustible_502ag.Nombre_502ag;
                cantsDisponible_502ag += combustible_502ag.CantDisponible_502ag;
                preciosPorLitro_502ag += combustible_502ag.PrecioPorLitro_502ag;
            }

            string dvv_502ag = codsCombustible_502ag + nombres_502ag + cantsDisponible_502ag + preciosPorLitro_502ag;
            return encryptador_502ag.EncryptadorIrreversible_502ag(dvv_502ag);
        }



    }
}
