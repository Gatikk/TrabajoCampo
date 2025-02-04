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
        public bool IniciarSesion(string nombre, string contraseña)
        {
            //if(ORM_Usuario.ValidarUsuario(nombre, contraseña)) SERVICIOS.SessionManager.GestorSessionManager().IniciarSesion(nombre);
            //return ORM_Usuario.ValidarUsuario(nombre, contraseña);

            bool esValido = false;

            BE_Usuario usuarioALogear = ormUsuario.DevolverListaUsuarios().Find(x => x.NombreUsuario == nombre);
            
            if(usuarioALogear != null)
            {
                if(usuarioALogear.Contraseña == contraseña)
                {
                    esValido = true;
                    SERVICIOS.SessionManager.GestorSessionManager().IniciarSesion(usuarioALogear);
                }

            }
            return esValido;
        }

        public List<BE_Usuario> DevolverListaUsuarios()
        {
            return ormUsuario.DevolverListaUsuarios();
        }

        public void Alta(BE_Usuario entidad)
        {
            ormUsuario.Alta(entidad);
        }
        public void Baja(BE_Usuario entidad)
        {
            ormUsuario.Baja(entidad);
        }
        public void Modificar()
        {

        }
    }
}
