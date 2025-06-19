using BE_502ag;
using SERVICIOS_502ag;
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
        private bool VerificarDatosPago_502ag(BE_Tarjeta_502ag tarjeta_502ag)
        {
            Encryptador_502ag cifrador_502ag = new Encryptador_502ag();
            bool esValido_502ag = true;
            Regex reTarjeta_502ag = new Regex(@"^(\d{4}-){3}\d{4}$");
            Regex reCodigoSeg_502ag = new Regex(@"^\d{3}$");
            Regex reFechaCaducidad_502ag = new Regex(@"^(0[1-9]|1[0-2])\/\d{2}$");
            Regex reTitular_502ag = new Regex(@"^([A-Za-zÁÉÍÓÚáéíóúÑñ]+(?: [A-Za-zÁÉÍÓÚáéíóúÑñ]+){0,3})$");
            if (!reTarjeta_502ag.IsMatch(cifrador_502ag.DesencryptadorReversible_502ag(tarjeta_502ag.NumeroTarjeta_502ag))){ esValido_502ag = false;}
            if(!reCodigoSeg_502ag.IsMatch(cifrador_502ag.DesencryptadorReversible_502ag(tarjeta_502ag.CodigoSeguridad_502ag))){ esValido_502ag = false;}
            if(!reFechaCaducidad_502ag.IsMatch(cifrador_502ag.DesencryptadorReversible_502ag(tarjeta_502ag.FechaCaducidad_502ag))){ esValido_502ag = false;}
            if(!reTitular_502ag.IsMatch(cifrador_502ag.DesencryptadorReversible_502ag(tarjeta_502ag.Titular_502ag))){ esValido_502ag = false;}
            return esValido_502ag;
        }

        public bool ValidarPago_502ag(BE_Tarjeta_502ag tarjeta_502ag)
        {
            return VerificarDatosPago_502ag(tarjeta_502ag);
        }
    }
}
