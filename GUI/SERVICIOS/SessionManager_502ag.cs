using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICIOS
{
    public class SessionManager_502ag
    {
        private static SessionManager_502ag instanciaSessionManager_502ag;
        public string idioma_502ag;
        public string rol_502ag;
        public string nombreUsuario_502ag;
        public string dni_502ag;
        public static SessionManager_502ag GestorSessionManager_502ag
        {
            get { 
                if (instanciaSessionManager_502ag == null)
                {
                    instanciaSessionManager_502ag = new SessionManager_502ag();
                }
                return instanciaSessionManager_502ag;
            }
        }
        public void IniciarSesion_502ag(string pNombreUsuario_502ag, string pIdioma_502ag, string pRol_502ag, string pDNI_502ag)
        {
            nombreUsuario_502ag = pNombreUsuario_502ag;
            idioma_502ag = pIdioma_502ag;
            rol_502ag = pRol_502ag; 
            dni_502ag = pDNI_502ag;
        }
        public void CerrarSesion()
        {
            nombreUsuario_502ag = null;
            idioma_502ag = null;
            rol_502ag = null;
        }
        public void CambiarIdioma()
        {
            Traductor_502ag.GestorTraductor.CambiarIdioma();
        }
    }
}
