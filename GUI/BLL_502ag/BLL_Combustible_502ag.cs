using BE_502ag;
using DAL_502ag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        }
        public bool VerificarDatosIngresadosAlta_502ag(string codCombustible_502ag, string nombre_502ag, string cantDisponible_502ag, string precioPorLitro_502ag)
        {
            bool esValido_502ag = true;
            Regex reCodigo_502ag = new Regex(@"^\d{3}$");
            Regex reDecimal_502ag = new Regex(@"^\d+(\.\d{1,2})?$");
            if(!reCodigo_502ag.IsMatch(codCombustible_502ag)) esValido_502ag = false;
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

        #region ModificarCombustible
        public void ModificarCombustible_502ag(BE_Combustible_502ag combustible_502ag, string nombre_502ag, decimal cantDisponible_502ag, decimal precioPorLitro_502ag)
        {
            DAL_Combustible_502ag dalCombustible_502ag = new DAL_Combustible_502ag();
            combustible_502ag.Nombre_502ag = nombre_502ag;
            combustible_502ag.CantDisponible_502ag = cantDisponible_502ag;
            combustible_502ag.PrecioPorLitro_502ag = precioPorLitro_502ag;
            dalCombustible_502ag.ModificarCombustible_502ag(combustible_502ag);
        }
        public bool VerificarDatosIngresadosModificar_502ag(string nombre_502ag, string cantDisponible_502ag, string precioPorLitro_502ag)
        {
            bool esValido_502ag = true;
            Regex reDecimal_502ag = new Regex(@"^\d+(\.\d{1,2})?$");
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
            dalCombustible_502ag.BajaCombustible_520ag(combustible_502ag);
        }
        #endregion

    }
}
