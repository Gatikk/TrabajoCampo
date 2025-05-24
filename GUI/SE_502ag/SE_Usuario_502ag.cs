using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_502ag
{
    public class SE_Usuario_502ag
    {
        public string DNI_502ag { get; set; }
        public string NombreUsuario_502ag { get; set; }
        public string Contraseña_502ag { get; set; }
        public string Rol_502ag { get; set; }
        public string Nombre_502ag { get; set; }
        public string Apellido_502ag { get; set; }
        public string Email_502ag { get; set; }
        public bool isBloqueado_502ag { get; set; }
        public int Intentos_502ag { get; set; }
        public bool isActivo_502ag { get; set; }
        public bool ContraseñaCambiada_502ag { get; set; }  
        public DateTime UltimoLogin_502ag { get; set; }

        public SE_Usuario_502ag(string pDNI_502ag, string pNombreUsuario_502ag, string pContraseña_502ag, string pRol_502ag, string pNombre_502ag, string pApellido_502ag, string pEmail_502ag, bool pIsBloqueado_502ag, int pIntentos_502ag, bool pIsActivo_502ag, bool pContraseñaCambiada_502ag, DateTime pUltimoLogin_502ag)
        {
            DNI_502ag = pDNI_502ag;
            NombreUsuario_502ag = pNombreUsuario_502ag;
            Contraseña_502ag = pContraseña_502ag;
            Rol_502ag = pRol_502ag;
            Nombre_502ag = pNombre_502ag;
            Apellido_502ag = pApellido_502ag;
            Email_502ag = pEmail_502ag;
            isBloqueado_502ag = pIsBloqueado_502ag;
            Intentos_502ag = pIntentos_502ag;
            isActivo_502ag = pIsActivo_502ag;
            ContraseñaCambiada_502ag = pContraseñaCambiada_502ag;
            UltimoLogin_502ag = pUltimoLogin_502ag;
        }
        public SE_Usuario_502ag(string pDNI_502ag, string pNombreUsuario_502ag, string pRol_502ag, string pNombre_502ag, string pApellido_502ag, string pEmail_502ag)
        {
            DNI_502ag = pDNI_502ag;
            NombreUsuario_502ag = pNombreUsuario_502ag;
            Rol_502ag = pRol_502ag;
            Nombre_502ag = pNombre_502ag;
            Apellido_502ag = pApellido_502ag;
            Email_502ag = pEmail_502ag;
        }
    }
}
