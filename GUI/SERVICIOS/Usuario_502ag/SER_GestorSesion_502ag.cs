using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SE_502ag;

namespace SERVICIOS_502ag
{
    public class SER_GestorSesion_502ag
    {
        private static SER_GestorSesion_502ag instanciaGestorSesion_502ag;
        public SE_Usuario_502ag sesion_502ag = null;
        public static SER_GestorSesion_502ag GestorSesion_502ag
        {
            get { 
                if (instanciaGestorSesion_502ag == null)
                {
                    instanciaGestorSesion_502ag = new SER_GestorSesion_502ag();
                }
                return instanciaGestorSesion_502ag;
            }
        }
        public void IniciarSesion_502ag(SE_Usuario_502ag usuario_502ag)
        {
            
            sesion_502ag = usuario_502ag;
            
        }
        public void CerrarSesion()
        {
            sesion_502ag = null;
        }

        public bool EstaLogeado_502ag()
        {
            if(sesion_502ag == null)
            {
                return true;
            }
            return false;
        }

        public void CambiarIdioma()
        {
            Traductor_502ag.GestorTraductor_502ag.CambiarIdioma_502ag();
        }
    }
}
