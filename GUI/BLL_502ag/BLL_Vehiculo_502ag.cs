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
    public class BLL_Vehiculo_502ag
    {
        //RFN1
        public bool SimulacionCarga_502ag(BE_Vehiculo_502ag vehiculo_502ag, decimal litrosPorCiclo_502ag, decimal litrosRestantes_502ag)
        {
            decimal litrosACargar_502ag = Math.Min(litrosPorCiclo_502ag, litrosRestantes_502ag);
            decimal espacioDisponible_502ag = vehiculo_502ag.CantidadMaxima_502ag - vehiculo_502ag.CantidadActual_502ag;
            litrosACargar_502ag = Math.Min(litrosACargar_502ag, espacioDisponible_502ag);

            vehiculo_502ag.CantidadActual_502ag += litrosACargar_502ag;
            litrosRestantes_502ag -= litrosACargar_502ag;

            return litrosRestantes_502ag <= 0 || vehiculo_502ag.CantidadActual_502ag >= vehiculo_502ag.CantidadMaxima_502ag;
        }


        //RFN2
        public void AltaVehiculo_502ag(string patente_502ag, string marca_502ag, string modelo_502ag, int anio_502ag)
        {
            DAL_Vehiculo_502ag dalVehiculo_502ag = new DAL_Vehiculo_502ag();
            BE_Vehiculo_502ag vehiculo_502ag  = new BE_Vehiculo_502ag(patente_502ag, marca_502ag, modelo_502ag, anio_502ag, true);
            dalVehiculo_502ag.AltaVehiculo_502ag(vehiculo_502ag);

            BLLS_Evento_502ag bllsEvento_502ag = new BLLS_Evento_502ag();
            bllsEvento_502ag.AltaEvento_502ag("Maestros", "Registrar Vehículo", 2);
         
            BLL_DigitoVerificador_502ag bllDigitoVerificador_502ag = new BLL_DigitoVerificador_502ag();
            bllDigitoVerificador_502ag.ActualizarDigitoVehiculo_502ag(CalcularDVH_502ag(), CalcularDVV_502ag());
        }

        public BE_Vehiculo_502ag ObtenerVehiculo_502ag(string patente_502ag)
        {
            DAL_Vehiculo_502ag dalVehiculo_502ag = new DAL_Vehiculo_502ag();

            BE_Vehiculo_502ag vehiculo_502ag = dalVehiculo_502ag.ObtenerVehiculo_502ag(patente_502ag);
            if(vehiculo_502ag != null)
            {
                if (vehiculo_502ag.IsActivo_502ag == true)
                {
                    return vehiculo_502ag;
                }
            }
            return null;
        }
        public bool VerificarPatenteYaRegistrada_502ag(string patente_502ag)
        {
            DAL_Vehiculo_502ag dalVehiculo_502ag = new DAL_Vehiculo_502ag();
            List<BE_Vehiculo_502ag> listaVehiculos_502ag = dalVehiculo_502ag.ObtenerVehiculos_502ag();
            if (listaVehiculos_502ag.Find(x => x.Patente_502ag.Trim() == patente_502ag) != null) { return false; }
            return true;
        }

        public bool VerificarPatente_502ag(string patente_502ag)
        {
            Regex rePatente_502ag = new Regex(@"^(?:[A-Z]{3}\d{3}|[A-Z]{2}\d{3}[A-Z]{2}|[A-Z]{1}\d{3}[A-Z]{3})$");
            if (!rePatente_502ag.IsMatch(patente_502ag)) return false;
            return true;
        }

        public bool VerificarMarcaModelo_502ag(string input_502ag)
        {
            Regex reInput_502ag = new Regex(@"^[A-Za-z0-9ÁÉÍÓÚÜÑäëïöüñ\- ]{2,30}$");
            if (!reInput_502ag.IsMatch(input_502ag)) return false;
            return true;
        }

        public bool VerificarAnio_502ag(int anio_502ag) 
        {
            if (anio_502ag >= 1995 && anio_502ag <= DateTime.Now.Year) return true; 
            return false;
        }
        public string CalcularDVH_502ag()
        {
            DAL_Vehiculo_502ag dalVehiculo_502ag = new DAL_Vehiculo_502ag();
            List<BE_Vehiculo_502ag> vehiculos_502ag = dalVehiculo_502ag.ObtenerVehiculos_502ag();
            List<string> horizontales_502ag = new List<string>();
            Encryptador_502ag encryptador_502ag = new Encryptador_502ag();
            foreach (BE_Vehiculo_502ag vehiculo_502ag in vehiculos_502ag)
            {
                string horizontal_502ag = "";
                horizontal_502ag = vehiculo_502ag.Patente_502ag + vehiculo_502ag.Marca_502ag + vehiculo_502ag.Modelo_502ag + vehiculo_502ag.Anio_502ag+vehiculo_502ag.IsActivo_502ag;
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
            DAL_Vehiculo_502ag dalVehiculo_502ag = new DAL_Vehiculo_502ag();
            List<BE_Vehiculo_502ag> vehiculos_502ag = dalVehiculo_502ag.ObtenerVehiculos_502ag();
            List<string> horizontales_502ag = new List<string>();
            Encryptador_502ag encryptador_502ag = new Encryptador_502ag();
            string patentes_502ag = "";
            string marcas_502ag = "";
            string modelos_502ag = "";
            string anios_502ag = "";
            string activos_502ag = "";

            foreach (BE_Vehiculo_502ag vehiculo_502ag in vehiculos_502ag)
            {
                patentes_502ag += vehiculo_502ag.Patente_502ag;
                marcas_502ag += vehiculo_502ag.Marca_502ag;
                modelos_502ag += vehiculo_502ag.Modelo_502ag;
                anios_502ag += vehiculo_502ag.Anio_502ag;
                activos_502ag += vehiculo_502ag.IsActivo_502ag;
            }

            string dvv_502ag = patentes_502ag + marcas_502ag+ modelos_502ag+ anios_502ag+activos_502ag;
            return encryptador_502ag.EncryptadorIrreversible_502ag(dvv_502ag);
        }
    }
}
