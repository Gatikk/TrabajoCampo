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
        public bool VerificarTitular_502ag(string titular_502ag)
        {
            Encryptador_502ag cifrador_502ag = new Encryptador_502ag();
            Regex reTitular_502ag = new Regex(@"^([A-Za-zÁÉÍÓÚáéíóúÑñ]+(?: [A-Za-zÁÉÍÓÚáéíóúÑñ]+){0,3})$");
            if (!reTitular_502ag.IsMatch(cifrador_502ag.DesencryptadorReversible_502ag(titular_502ag))) return false;
            return true;
        }
        public bool VerificarNumero_502ag(string numTarjeta_502ag)
        {
            Encryptador_502ag cifrador_502ag = new Encryptador_502ag();
            Regex reTarjeta_502ag = new Regex(@"^(\d{4}-){3}\d{4}$");
            if (!reTarjeta_502ag.IsMatch(cifrador_502ag.DesencryptadorReversible_502ag(numTarjeta_502ag))) return false;
            return true;
        }
        public bool VerificarCodigo_502ag(string codigo_502ag)
        {
            Encryptador_502ag cifrador_502ag = new Encryptador_502ag();
            Regex reCodigoSeg_502ag = new Regex(@"^\d{3}$");
            if (!reCodigoSeg_502ag.IsMatch(cifrador_502ag.DesencryptadorReversible_502ag(codigo_502ag))) return false;
            return true;
        }
        public bool VerificarFechaCaducidad_502ag(string fechaCaducidad_502ag)
        {
            Encryptador_502ag cifrador_502ag = new Encryptador_502ag();
            Regex reFechaCaducidad_502ag = new Regex(@"^(0[1-9]|1[0-2])\/\d{2}$");
            if (!reFechaCaducidad_502ag.IsMatch(cifrador_502ag.DesencryptadorReversible_502ag(fechaCaducidad_502ag))) return false;
            return true;
        }
        public bool ValidarPago_502ag(BE_Tarjeta_502ag tarjeta_502ag)
        {
            Encryptador_502ag cifrador_502ag = new Encryptador_502ag();
            string fechaCad_502ag = cifrador_502ag.DesencryptadorReversible_502ag(tarjeta_502ag.FechaCaducidad_502ag);
            string[] fecha = fechaCad_502ag.Split('/');
            if (int.Parse(fecha[1]) <= 24) return false;
            if (int.Parse(fecha[0]) < 11 && int.Parse(fecha[1]) <= 25) return false;
            return true;
        }
    }
}
