using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL_502ag
{
    public class BLL_Pago_502ag
    {
        public bool VerificarDatosPago_502ag(string numTarjeta_502ag, string codSeguridad_502ag, string fechaCad_502ag, string titular_502ag)
        {
            bool esValido_502ag = true;
            Regex reTarjeta_502ag = new Regex(@"^(\d{4}-){3}\d{4}$");
            Regex reCodigoSeg_502ag = new Regex(@"^\d{3}$");
            Regex reFechaCaducidad_502ag = new Regex(@"^(0[1-9]|1[0-2])\/\d{2}$");
            Regex reTitular_502ag = new Regex(@"^([A-Za-zÁÉÍÓÚáéíóúÑñ]+(?: [A-Za-zÁÉÍÓÚáéíóúÑñ]+){0,3})$");
            if (!reTarjeta_502ag.IsMatch(numTarjeta_502ag)){ esValido_502ag = false;}
            if(!reCodigoSeg_502ag.IsMatch(codSeguridad_502ag)){ esValido_502ag = false;}
            if(!reFechaCaducidad_502ag.IsMatch(fechaCad_502ag)){ esValido_502ag = false;}
            if(!reTitular_502ag.IsMatch(titular_502ag)){ esValido_502ag = false;}
            return esValido_502ag;
        }
    }
}
