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
        public void IniciarSesion(BE_Usuario entidad)
        {
            ORM_Usuario ormUsuario = new ORM_Usuario();
            entidad.Intentos = 0;
            SessionManager.GestorSessionManager.IniciarSesion(entidad);
            ormUsuario.ActualizarBloqueo(entidad);
        }
        public void SesionFallida(BE_Usuario entidad)
        {
            ORM_Usuario ormUsuario = new ORM_Usuario();
            if (entidad.Rol != "admin")
            {
                entidad.Intentos++;
                if(entidad.Intentos == 3)
                {
                    entidad.isBloqueado = true;
                }
            }
            ormUsuario.ActualizarBloqueo(entidad);
        }
        public bool VerificarContraseña(BE_Usuario entidad, string contraseña)
        {
            Cifrador cifrador = new Cifrador();
            if (entidad.Contraseña == cifrador.CifradorIrreversible(contraseña))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<BE_Usuario> DevolverListaUsuarios()
        {
            ORM_Usuario ormUsuario = new ORM_Usuario();
            return ormUsuario.DevolverListaUsuarios();
        }

        public void Bloquear(BE_Usuario entidad)
        {
            ORM_Usuario ormUsuario = new ORM_Usuario();
            if (entidad.Rol != "admin")
            {
                if(entidad.isBloqueado != true)
                {
                    entidad.isBloqueado = true;
                    entidad.Intentos = 3;
                    ormUsuario.ActualizarBloqueo(entidad);
                }
            }
        }
        public void Desbloquear(BE_Usuario entidad)
        {
            ORM_Usuario ormUsuario = new ORM_Usuario();
            if (entidad.isBloqueado != false)
            {
                entidad.isBloqueado = false;
                entidad.Intentos = 0;
                ormUsuario.ActualizarBloqueo(entidad);
            }
        }
        public void CambiarContraseña(string nuevaContraseña, BE_Usuario entidad)
        {
            ORM_Usuario ormUsuario = new ORM_Usuario();
            Cifrador cifrador = new Cifrador();
            entidad.Contraseña = cifrador.CifradorIrreversible(nuevaContraseña);
            ormUsuario.ActualizarContraseña(entidad);
        }
        public void CambiarIdioma(string nuevoIdioma)
        {
            SessionManager.GestorSessionManager.sesion.Idioma = nuevoIdioma;
            ORM_Usuario ormUsuario = new ORM_Usuario();
            ormUsuario.ActualizarIdioma(SessionManager.GestorSessionManager.sesion);
            SessionManager.GestorSessionManager.CambiarIdioma();
        }
        public void Alta(BE_Usuario entidad)
        {
            ORM_Usuario ormUsuario = new ORM_Usuario();
            Cifrador cifrador = new Cifrador();
            string[] primerApellido = entidad.Apellido.Split(' ');
            primerApellido[0] = primerApellido[0].ToLower().Trim();
            entidad.Contraseña = cifrador.CifradorIrreversible(entidad.DNI + primerApellido[0]);
            entidad.Idioma = "es";
            ormUsuario.Alta(entidad);
        }
        public void Baja(BE_Usuario entidad)
        {
            ORM_Usuario ormUsuario = new ORM_Usuario();
            ormUsuario.Baja(entidad);
        }
        public void Modificar(BE_Usuario entidad)
        {
            ORM_Usuario ormUsuario = new ORM_Usuario();
            ormUsuario.Modificar(entidad);
        }
    }
}
