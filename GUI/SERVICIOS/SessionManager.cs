using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace SERVICIOS
{
    public class SessionManager
    {
        private static SessionManager instanciaSessionManager;
        public BE_Usuario sesion;
        public static SessionManager GestorSessionManager
        {
            get { 
                if (instanciaSessionManager == null)
                {
                    instanciaSessionManager = new SessionManager();
                }
                return instanciaSessionManager;
            }
        }
        public BE_Usuario IniciarSesion(BE_Usuario usuario)
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
        public string DevolverNombre()
        {
            return sesion.NombreUsuario;
        }
        public void CambiarIdioma()
        {
            Traductor.GestorTraductor.CambiarIdioma();
        }
    }
}
