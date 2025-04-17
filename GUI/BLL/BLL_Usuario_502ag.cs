using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM;
using SERVICIOS;
using System.Text.RegularExpressions;

namespace BLL
{
    public class BLL_Usuario_502ag
    {

        #region Login
        public void IniciarSesion(BE_Usuario_502ag entidad)
        {
            ORM_Usuario_502ag ormUsuario = new ORM_Usuario_502ag();
            entidad.Intentos = 0;
            SessionManager_502ag.GestorSessionManager.IniciarSesion(entidad);
            ormUsuario.ActualizarBloqueo(entidad);
        }
        public void SesionFallida(BE_Usuario_502ag entidad)
        {
            ORM_Usuario_502ag ormUsuario = new ORM_Usuario_502ag();
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
        public bool VerificarContraseña(BE_Usuario_502ag entidad, string contraseña)
        {
            Cifrador_502ag cifrador = new Cifrador_502ag();
            if (entidad.Contraseña == cifrador.CifradorIrreversible(contraseña))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion


        public List<BE_Usuario_502ag> DevolverListaUsuarios()
        {
            ORM_Usuario_502ag ormUsuario = new ORM_Usuario_502ag();
            return ormUsuario.DevolverListaUsuarios();
        }
        public BE_Usuario_502ag DevolverUsuario_502ag(string nombreUsuario)
        {
            ORM_Usuario_502ag ormUsuario = new ORM_Usuario_502ag();
            return ormUsuario.DevolverListaUsuarios().Find(x => x.NombreUsuario == nombreUsuario);
        }

        public void Bloquear(BE_Usuario_502ag entidad)
        {
            ORM_Usuario_502ag ormUsuario = new ORM_Usuario_502ag();
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

        #region Desbloquear
        public void Desbloquear(BE_Usuario_502ag entidad)
        {
            ORM_Usuario_502ag ormUsuario = new ORM_Usuario_502ag();
            if (entidad.isBloqueado != false)
            {
                entidad.isBloqueado = false;
                entidad.Intentos = 0;
                entidad.Contraseña = FormatearContraseña_502ag(entidad.Apellido, entidad.DNI);
                ormUsuario.ActualizarBloqueo(entidad);
            }
        }
        #endregion
        #region Contraseña
        public void CambiarContraseña(string nuevaContraseña, BE_Usuario_502ag entidad)
        {
            ORM_Usuario_502ag ormUsuario = new ORM_Usuario_502ag();
            Cifrador_502ag cifrador = new Cifrador_502ag();
            entidad.Contraseña = cifrador.CifradorIrreversible(nuevaContraseña);
            ormUsuario.ActualizarContraseña(entidad);
        }
        public string FormatearContraseña_502ag(string apellido, string DNI)
        {
            Cifrador_502ag cifrador = new Cifrador_502ag();
            string[] primerApellido = apellido.Split(' ');
            primerApellido[0] = primerApellido[0].ToLower().Trim();
            string contraseña = cifrador.CifradorIrreversible(DNI + primerApellido[0]);
            return contraseña;
        }
        #endregion
        public void CambiarIdioma(string nuevoIdioma)
        {
            SessionManager_502ag.GestorSessionManager.sesion.Idioma = nuevoIdioma;
            ORM_Usuario_502ag ormUsuario = new ORM_Usuario_502ag();
            ormUsuario.ActualizarIdioma(SessionManager_502ag.GestorSessionManager.sesion);
            SessionManager_502ag.GestorSessionManager.CambiarIdioma();
        }

        #region ABM
        #region AltaUsuario
        public void AltaUsuario_502ag(string nombreUsuario, string rol, string nombre, string apellido, string DNI, string email)
        {
            ORM_Usuario_502ag ormUsuario = new ORM_Usuario_502ag();
            string contraseña = FormatearContraseña_502ag(apellido, DNI);
            BE_Usuario_502ag nuevoUsuario = new BE_Usuario_502ag(nombreUsuario, rol, nombre, apellido,DNI, email);
            nuevoUsuario.isBloqueado = false;
            nuevoUsuario.Intentos = 0;
            nuevoUsuario.Contraseña = contraseña;
            nuevoUsuario.Idioma = "es";
            ormUsuario.AltaUsuario_502ag(nuevoUsuario);
        }
        public bool VerificarExistenciaUsuario_502ag(string nombreUsuario, string DNI)
        {
            bool usuarioValido = true;
            foreach(BE_Usuario_502ag usuarioEnLista in DevolverListaUsuarios())
            {
                if(usuarioEnLista.NombreUsuario == nombreUsuario || usuarioEnLista.DNI == DNI) usuarioValido = false;
            }
            return usuarioValido;
        }
        public bool VerificarAltaUsuario_502ag(string nombreUsuario, string nombre, string apellido, string DNI, string email)
        {
            bool usuarioValido = true;
            Regex reDNI = new Regex(@"^\d{8}$");
            Regex reUsuario = new Regex(@"^[a-zA-Z0-9]{3,20}$");
            Regex reEmail = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+.[a-zA-Z]{2,}$");
            Regex reNombreApellido = new Regex(@"^[A-Z][a-zÁÉÍÓÚáéíóúÑñ]{3,40}$");
            if (!reDNI.IsMatch(DNI)) usuarioValido = false; 
            if (!reUsuario.IsMatch(nombreUsuario)) usuarioValido = false; 
            if (!reNombreApellido.IsMatch(nombre)) usuarioValido = false; 
            if(!reNombreApellido.IsMatch(apellido)) usuarioValido= false;
            if(!reEmail.IsMatch(email)) usuarioValido = false;
            return usuarioValido;
        }
        #endregion
        
        public void Baja(BE_Usuario_502ag entidad)
        {
            ORM_Usuario_502ag ormUsuario = new ORM_Usuario_502ag();
            ormUsuario.Baja(entidad);
        }
        public void Modificar(BE_Usuario_502ag entidad)
        {
            ORM_Usuario_502ag ormUsuario = new ORM_Usuario_502ag();
            ormUsuario.Modificar(entidad);
        }
        #endregion
    }
}
