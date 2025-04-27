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
        public SER_Usuario_502ag sesion_502ag = null;
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
        public void IniciarSesion_502ag(SER_Usuario_502ag usuario_502ag)
        {
            
            sesion_502ag = usuario_502ag;
            
        }
        public void CerrarSesion()
        {
            sesion_502ag = null;
        }

        public bool estaLogeado_502ag()
        {
            bool estaLogeado_502ag = false;
            if(sesion_502ag == null)
            {
                estaLogeado_502ag =  true;
            }
            return estaLogeado_502ag;
        }

        public void CambiarIdioma()
        {
            Traductor_502ag.GestorTraductor.CambiarIdioma();
        }
    }
}
