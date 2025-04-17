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
        public BE_Usuario_502ag sesion;
        public static SessionManager_502ag GestorSessionManager
        {
            get { 
                if (instanciaSessionManager == null)
                {
                    instanciaSessionManager = new SessionManager_502ag();
                }
                return instanciaSessionManager;
            }
        }
        public BE_Usuario_502ag IniciarSesion(BE_Usuario_502ag usuario)
        {
            if (sesion == null)
            {
                sesion = usuario;
            }
            return sesion;
        }
        public void CerrarSesion()
        {
            if(sesion != null)
            {
                sesion = null;
            }
        }
        public void CambiarIdioma()
        {
            Traductor_502ag.GestorTraductor.CambiarIdioma();
        }
    }
}
