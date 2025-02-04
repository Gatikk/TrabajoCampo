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
            bool esValido = false;

            BE_Usuario usuarioALogear = ormUsuario.DevolverListaUsuarios().Find(x => x.NombreUsuario == nombre);       
            {
                if(usuarioALogear.isBloqueado != true)
                {
                    if(usuarioALogear != null)
                    {
                        if(usuarioALogear.Contraseña == contraseña)
                        {
                            esValido = true;
                            usuarioALogear.Intentos = 0;
                            SERVICIOS.SessionManager.GestorSessionManager().IniciarSesion(usuarioALogear);
                        }
                        else
                        {
                            if (usuarioALogear.Rol != "admin")
                            {
                                usuarioALogear.Intentos++;
                                if (usuarioALogear.Intentos == 3)
                                {
                                    usuarioALogear.isBloqueado = true;
                                }
                                ormUsuario.IntentosIniciarSesion(usuarioALogear);
                            }
                        }
                    }
                }
                else
                {
                    //agregar evento usuario bloqueado
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
