using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace SERVICIOS
{
    public class SessionManager_502ag
    {
        private static SessionManager_502ag instanciaSessionManager;
        public BE_Usuario_502ag sesion_502ag;
        public static SessionManager_502ag GestorSessionManager_502ag
        {
            get { 
                if (instanciaSessionManager == null)
                {
                    instanciaSessionManager = new SessionManager_502ag();
                }
                return instanciaSessionManager;
            }
        }
        public BE_Usuario_502ag IniciarSesion_502ag(BE_Usuario_502ag usuario)
        {
            if (sesion_502ag == null)
            {
                sesion_502ag = usuario;
            }
            return sesion_502ag;
        }
        public void CerrarSesion()
        {
            if(sesion_502ag != null)
            {
                sesion_502ag = null;
            }
        }
        public void CambiarIdioma()
        {
            Traductor_502ag.GestorTraductor.CambiarIdioma();
        }
    }
}
