using BE_502ag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SERVICIOS;
using System.Text.RegularExpressions;
using System.Net;
using DAL_502ag;

namespace BLL_502ag
{
    public class BLL_Usuario_502ag
    {

        #region Login
        public void IniciarSesion_502ag(SER_Usuario_502ag usuario_502ag)
        {
            DAL_Usuario_502ag dalUsuario_502ag = new DAL_Usuario_502ag();
            usuario_502ag.Intentos_502ag = 0;
            SessionManager_502ag.GestorSessionManager_502ag.IniciarSesion_502ag(usuario_502ag);
            dalUsuario_502ag.ActualizarBloqueoLogin_502ag(usuario_502ag);
        }
        public void SesionFallida_502ag(SER_Usuario_502ag usuario_502ag)
        {
            DAL_Usuario_502ag dalUsuario_502ag = new DAL_Usuario_502ag();
            if (usuario_502ag.Rol_502ag != "admin")
            {
                usuario_502ag.Intentos_502ag++;
                if (usuario_502ag.Intentos_502ag == 3)
                {
                    usuario_502ag.isBloqueado_502ag = true;
                }
            }
            dalUsuario_502ag.ActualizarBloqueoLogin_502ag(usuario_502ag);
        }
        public bool VerificarExistenciaUsuario_502ag(SER_Usuario_502ag usuario_502ag)
        {
            bool esValido_502ag = true;
            if (usuario_502ag == null) esValido_502ag = false;
            return esValido_502ag;
        }
        public bool VerificarUsuarioBloqueado_502ag(SER_Usuario_502ag usuario_502ag)
        {
            bool esValido_502ag = true;
            if (usuario_502ag.isBloqueado_502ag == true) esValido_502ag = false;
            return esValido_502ag;
        }
        public bool VerificarUsuarioActivo_502ag(SER_Usuario_502ag usuario_502ag)
        {
            bool esValido_502ag = true;
            if (usuario_502ag.isActivo_502ag != true) esValido_502ag = false;
            return esValido_502ag;
        }
        public bool VerificarContraseña_502ag(SER_Usuario_502ag usuario_502ag, string contraseña)
        {
            bool esValido_502ag = true;
            Cifrador_502ag cifrador_502ag = new Cifrador_502ag();
            if (!(usuario_502ag.Contraseña_502ag == cifrador_502ag.CifradorIrreversible_502ag(contraseña)))
            {
                esValido_502ag= false;
            }
            return esValido_502ag;
        }

        #endregion

        #region Consulta
        public List<BE_Usuario_502ag> DevolverListaUsuarios_502ag()
        {
            DAL_Usuario_502ag dalUsuario_502ag = new DAL_Usuario_502ag();
            return dalUsuario_502ag.ObtenerListaUsuarios_502ag();
        }
        public BE_Usuario_502ag DevolverUsuario_502ag(string dni_502ag)
        {
            DAL_Usuario_502ag dalUsuario_502ag = new DAL_Usuario_502ag();
            return dalUsuario_502ag.ObtenerListaUsuarios_502ag().Find(x => x.DNI_502ag == dni_502ag);
        }
        public SER_Usuario_502ag DevolverUsuarioALogear_502ag(string nombreUsuario_502ag)
        {
            DAL_Usuario_502ag dalUsuario_502ag = new DAL_Usuario_502ag();
            return dalUsuario_502ag.ObtenerUsuarioALogear(nombreUsuario_502ag);
        }
        #endregion
        public void Bloquear(BE_Usuario_502ag entidad)
        {
            DAL_Usuario_502ag dalUsuario_502ag = new DAL_Usuario_502ag();
            if (entidad.Rol_502ag != "admin")
            {
                if (entidad.isBloqueado_502ag != true)
                {
                    entidad.isBloqueado_502ag = true;
                    entidad.Intentos_502ag = 3;
                    dalUsuario_502ag.ActualizarBloqueo_502ag(entidad);
                }
            }
        }

        #region Desbloquear
        public void Desbloquear_502ag(BE_Usuario_502ag usuario_502ag)
        {
            DAL_Usuario_502ag dalUsuario_502ag = new DAL_Usuario_502ag();
            if (usuario_502ag.isBloqueado_502ag != false)
            {
                usuario_502ag.isBloqueado_502ag = false;
                usuario_502ag.Intentos_502ag = 0;
                usuario_502ag.Contraseña_502ag = FormatearContraseña_502ag(usuario_502ag.Apellido_502ag, usuario_502ag.DNI_502ag);
                dalUsuario_502ag.ActualizarBloqueo_502ag(usuario_502ag);
            }
        }
        #endregion
        #region Contraseña
        public void CambiarContraseña_502ag(string nuevaContraseña_502ag, SER_Usuario_502ag usuario_502ag)
        {
            DAL_Usuario_502ag dalUsuario_502ag = new DAL_Usuario_502ag();
            Cifrador_502ag cifrador = new Cifrador_502ag();
            usuario_502ag.Contraseña_502ag = cifrador.CifradorIrreversible_502ag(nuevaContraseña_502ag);
            dalUsuario_502ag.ActualizarContraseña_502ag(usuario_502ag);
        }
        public string FormatearContraseña_502ag(string apellido_502ag, string DNI_502ag)
        {
            Cifrador_502ag cifrador_502ag = new Cifrador_502ag();
            string[] primerApellido_502ag = apellido_502ag.Split(' ');
            primerApellido_502ag[0] = primerApellido_502ag[0].ToLower().Trim();
            string contraseña_502ag = cifrador_502ag.CifradorIrreversible_502ag(DNI_502ag + primerApellido_502ag[0]);
            return contraseña_502ag;
        }
        public bool VerificarCoincidencia_502ag(string contraseña_502ag, string confirmarContraseña_502ag)
        {
            bool contraseñaCoinciden_502ag = (contraseña_502ag == confirmarContraseña_502ag);
            return contraseñaCoinciden_502ag;
        } 
        public bool VerificarContraseñaActual_502ag(string nuevaContraseña_502ag, SER_Usuario_502ag usuario_502ag)
        {
            Cifrador_502ag cifrador_502ag = new Cifrador_502ag();
            bool contraseñaEsIgual = (usuario_502ag.Contraseña_502ag == cifrador_502ag.CifradorIrreversible_502ag(nuevaContraseña_502ag));
            return contraseñaEsIgual;
        }

        #endregion
        public void CambiarIdioma_502ag(string nuevoIdioma)
        {
            SessionManager_502ag.GestorSessionManager_502ag.sesion_502ag.Idioma_502ag = nuevoIdioma;
            DAL_Usuario_502ag dalUsuario_502ag = new DAL_Usuario_502ag();
            BE_Usuario_502ag usuario_502ag = dalUsuario_502ag.ObtenerListaUsuarios_502ag().Find(x => x.NombreUsuario_502ag == SessionManager_502ag.GestorSessionManager_502ag.sesion_502ag.NombreUsuario_502ag);
            dalUsuario_502ag.ActualizarIdioma_502ag(usuario_502ag);
            SessionManager_502ag.GestorSessionManager_502ag.CambiarIdioma();
        }
        #region ActivarDesactivar
        public bool VerificarRol_502ag(BE_Usuario_502ag usuario_502ag)
        {
            bool esAdmin = false;
            if (usuario_502ag.Rol_502ag == "admin")  esAdmin = true;
            return esAdmin;
 
        }
        public void ActivarDesactivar_502ag(BE_Usuario_502ag usuario_502ag)
        {
            DAL_Usuario_502ag dalUsuario_502ag = new DAL_Usuario_502ag();
            if (usuario_502ag.isActivo_502ag == true)
            {
                usuario_502ag.isActivo_502ag = false;
            }
            else
            {
                usuario_502ag.isActivo_502ag = true;
            }
            dalUsuario_502ag.ActualizarActivo_502ag(usuario_502ag);
        }
        #endregion


        #region ABM
        #region AltaUsuario
        public void AltaUsuario_502ag(string nombreUsuario_502ag, string rol_502ag, string nombre_502ag, string apellido_502ag, string DNI_502ag, string email_502ag)
        {
            DAL_Usuario_502ag dalUsuario_502ag = new DAL_Usuario_502ag();
            string contraseña = FormatearContraseña_502ag(apellido_502ag, DNI_502ag);
            BE_Usuario_502ag nuevoUsuario = new BE_Usuario_502ag(DNI_502ag, nombreUsuario_502ag, rol_502ag, nombre_502ag, apellido_502ag, email_502ag);
            nuevoUsuario.isBloqueado_502ag = false;
            nuevoUsuario.Intentos_502ag = 0;
            nuevoUsuario.Contraseña_502ag = contraseña;
            nuevoUsuario.Idioma_502ag = "es";
            nuevoUsuario.isActivo_502ag = true;
            dalUsuario_502ag.AltaUsuario_502ag(nuevoUsuario);
        }
        public bool VerificarExistenciaUsuario_502ag(string nombreUsuario_502ag, string DNI_502ag)
        {
            bool usuarioValido_502ag = true;
            foreach(BE_Usuario_502ag usuarioEnLista_502ag in DevolverListaUsuarios_502ag())
            {
                if(usuarioEnLista_502ag.NombreUsuario_502ag == nombreUsuario_502ag || usuarioEnLista_502ag.DNI_502ag == DNI_502ag) usuarioValido_502ag = false;
            }
            return usuarioValido_502ag;
        }



        public bool VerificarAltaUsuario_502ag(string nombreUsuario_502ag, string nombre_502ag, string apellido_502ag, string DNI_502ag, string email_502ag)
        {
            bool usuarioValido_502ag = true;
            Regex reDNI_502ag = new Regex(@"^\d{8}$");
            Regex reUsuario_502ag = new Regex(@"^[a-zA-Z0-9]{3,20}$");
            Regex reEmail_502ag = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+.[a-zA-Z]{2,}$");
            Regex reNombreApellido_502ag = new Regex(@"^[A-Z][a-zÁÉÍÓÚáéíóúÑñ]{3,40}$");
            if (!reDNI_502ag.IsMatch(DNI_502ag)) usuarioValido_502ag = false; 
            if (!reUsuario_502ag.IsMatch(nombreUsuario_502ag)) usuarioValido_502ag = false; 
            if (!reNombreApellido_502ag.IsMatch(nombre_502ag)) usuarioValido_502ag = false; 
            if(!reNombreApellido_502ag.IsMatch(apellido_502ag)) usuarioValido_502ag= false;
            if(!reEmail_502ag.IsMatch(email_502ag)) usuarioValido_502ag = false;
            return usuarioValido_502ag;
        }
        #endregion
        
        #region Modificar
        public void ModificarUsuario_502ag(BE_Usuario_502ag usuario_502ag)
        {
            DAL_Usuario_502ag dalUsuario_502ag = new DAL_Usuario_502ag();
            dalUsuario_502ag.ModificarUsuario_502ag(usuario_502ag);
        }
        public bool VerificarModificarUsuario_502ag(BE_Usuario_502ag usuario_502ag)
        {
            bool usuarioValido_502ag = true;
            Regex reDNI_502ag = new Regex(@"^\d{8}$");
            Regex reEmail_502ag = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+.[a-zA-Z]{2,}$");
            Regex reNombreApellido_502ag = new Regex(@"^[A-Z][a-zÁÉÍÓÚáéíóúÑñ]{3,40}$");
            if (!reDNI_502ag.IsMatch(usuario_502ag.DNI_502ag)) usuarioValido_502ag = false;
            if (!reNombreApellido_502ag.IsMatch(usuario_502ag.Nombre_502ag)) usuarioValido_502ag = false;
            if (!reNombreApellido_502ag.IsMatch(usuario_502ag.Apellido_502ag)) usuarioValido_502ag = false;
            if (!reEmail_502ag.IsMatch(usuario_502ag.Email_502ag)) usuarioValido_502ag = false;
            return usuarioValido_502ag;
        }
        #endregion
        #endregion
    }
}
