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
        ORM_Usuario ormUsuario = new ORM_Usuario();
        public static bool IniciarSesion(string nombre, string contraseña)
        {
            if(ORM_Usuario.ValidarUsuario(nombre, contraseña)) SERVICIOS.SessionManager.CrearSesion(nombre);
            return ORM_Usuario.ValidarUsuario(nombre, contraseña);
        }

        public List<BE_Usuario> DevolverListaUsuarios()
        {
            return ormUsuario.DevolverListaUsuarios();
        }
    }
}
