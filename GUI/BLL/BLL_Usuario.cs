using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM;
using SERVICIOS;

namespace BLL
{
    public class BLL_Usuario
    {
        public static bool IniciarSesion(string nombre, string contraseña)
        {
            if(ORM_Usuario.ValidarUsuario(nombre, contraseña)) SERVICIOS.SessionManager.IniciarSesion(nombre);
            return ORM_Usuario.ValidarUsuario(nombre, contraseña);
        }
    }
}
