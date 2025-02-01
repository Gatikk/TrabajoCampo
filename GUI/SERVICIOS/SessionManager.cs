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
        private static BE_Usuario instancia;
        public static BE_Usuario CrearSesion(string Nombre)
        {
            if (instancia == null)
            {
                instancia = new BE_Usuario(Nombre);
            }
            return instancia;
        }
        public static void CerrarSesion()
        {
            if(instancia != null)
            {
                instancia = null;
            }
        }
        public static string DevolverNombre()
        {
            return instancia.NombreUsuario;
        }
    }
}
