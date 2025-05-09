using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DAL_502ag;
using SE_502ag;
using SERVICIOS_502ag;

namespace SERVICIOS_502ag
{
    public class SER_GestorUsuario_502ag
    {

        #region Login
        public void IniciarSesion_502ag(SE_Usuario_502ag usuario_502ag)
        {
            DAL_Usuario_502ag dalUsuario_502ag = new DAL_Usuario_502ag();
            usuario_502ag.Intentos_502ag = 0;
            SER_GestorSesion_502ag.GestorSesion_502ag.IniciarSesion_502ag(usuario_502ag);
            dalUsuario_502ag.ActualizarBloqueoLogin_502ag(usuario_502ag);
        }
        public void SesionFallida_502ag(SE_Usuario_502ag usuario_502ag)
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
        public bool VerificarExistenciaUsuario_502ag(SE_Usuario_502ag usuario_502ag)
        {
            bool esValido_502ag = true;
            if (usuario_502ag == null) esValido_502ag = false;
            return esValido_502ag;
        }
        public bool VerificarUsuarioBloqueado_502ag(SE_Usuario_502ag usuario_502ag)
        {
            bool esValido_502ag = true;
            if (usuario_502ag.isBloqueado_502ag == true) esValido_502ag = false;
            return esValido_502ag;
        }
        public bool VerificarUsuarioActivo_502ag(SE_Usuario_502ag usuario_502ag)
        {
            bool esValido_502ag = true;
            if (usuario_502ag.isActivo_502ag != true) esValido_502ag = false;
            return esValido_502ag;
        }
        public bool VerificarContraseña_502ag(SE_Usuario_502ag usuario_502ag, string contraseña)
        {
            bool esValido_502ag = true;
            Encryptador_502ag cifrador_502ag = new Encryptador_502ag();
            if (!(usuario_502ag.Contraseña_502ag == cifrador_502ag.EncryptadorIrreversible_502ag(contraseña)))
            {
                esValido_502ag = false;
            }
            return esValido_502ag;
        }
        #endregion

        #region Consulta
        public List<SE_Usuario_502ag> ObtenerListaUsuarios_502ag()
        {
            DAL_Usuario_502ag dalUsuario_502ag = new DAL_Usuario_502ag();
            return dalUsuario_502ag.ObtenerListaUsuarios_502ag();
        }
        public SE_Usuario_502ag ObtenerUsuario_502ag(string dni_502ag)
        {
            DAL_Usuario_502ag dalUsuario_502ag = new DAL_Usuario_502ag();
            return dalUsuario_502ag.ObtenerUsuario_502ag(dni_502ag);
        }
        public SE_Usuario_502ag ObtenerUsuarioALogear_502ag(string nombreUsuario_502ag)
        {
            DAL_Usuario_502ag dalUsuario_502ag = new DAL_Usuario_502ag();
            return dalUsuario_502ag.ObtenerUsuarioALogear(nombreUsuario_502ag);
        }
        #endregion
        public void BloquearUsuario_502ag(SE_Usuario_502ag usuario_502ag)
        {
            DAL_Usuario_502ag dalUsuario_502ag = new DAL_Usuario_502ag();
            if (usuario_502ag.Rol_502ag != "admin")
            {
                if (usuario_502ag.isBloqueado_502ag != true)
                {
                    usuario_502ag.isBloqueado_502ag = true;
                    usuario_502ag.Intentos_502ag = 3;
                    dalUsuario_502ag.ActualizarBloqueo_502ag(usuario_502ag);
                }
            }
        }
        #region Desbloquear
        public void Desbloquear_502ag(SE_Usuario_502ag usuario_502ag)
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
        public void CambiarContraseña_502ag(string nuevaContraseña_502ag, SE_Usuario_502ag usuario_502ag)
        {
            DAL_Usuario_502ag dalUsuario_502ag = new DAL_Usuario_502ag();
            Encryptador_502ag cifrador = new Encryptador_502ag();
            usuario_502ag.Contraseña_502ag = cifrador.EncryptadorIrreversible_502ag(nuevaContraseña_502ag);
            dalUsuario_502ag.ActualizarContraseña_502ag(usuario_502ag);
        }
        public string FormatearContraseña_502ag(string apellido_502ag, string DNI_502ag)
        {
            Encryptador_502ag cifrador_502ag = new Encryptador_502ag();
            string[] primerApellido_502ag = apellido_502ag.Split(' ');
            primerApellido_502ag[0] = primerApellido_502ag[0].ToLower().Trim();
            string contraseña_502ag = cifrador_502ag.EncryptadorIrreversible_502ag(DNI_502ag + primerApellido_502ag[0]);
            return contraseña_502ag;
        }
        public bool VerificarCoincidencia_502ag(string contraseña_502ag, string confirmarContraseña_502ag)
        {
            bool contraseñaCoinciden_502ag = (contraseña_502ag == confirmarContraseña_502ag);
            return contraseñaCoinciden_502ag;
        }
        public bool VerificarContraseñaActual_502ag(string nuevaContraseña_502ag, SE_Usuario_502ag usuario_502ag)
        {
            Encryptador_502ag cifrador_502ag = new Encryptador_502ag();
            bool contraseñaEsIgual = (usuario_502ag.Contraseña_502ag == cifrador_502ag.EncryptadorIrreversible_502ag(nuevaContraseña_502ag));
            return contraseñaEsIgual;
        }

        public bool CompararContraseñaActualTextBox_502ag(string contraseñaActual_502ag, SE_Usuario_502ag usuario_502ag)
        {
            Encryptador_502ag cifrador_502ag = new Encryptador_502ag();
            bool contraseñaEsIgual = (usuario_502ag.Contraseña_502ag == cifrador_502ag.EncryptadorIrreversible_502ag(contraseñaActual_502ag));
            return contraseñaEsIgual;
        }


        #endregion


        #region ActivarDesactivar
        public bool VerificarRol_502ag(SE_Usuario_502ag usuario_502ag)
        {
            bool esAdmin = false;
            if (usuario_502ag.Rol_502ag == "admin") esAdmin = true;
            return esAdmin;

        }
        public void ActivarDesactivar_502ag(SE_Usuario_502ag usuario_502ag)
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
        public void AltaUsuario_502ag(string rol_502ag, string nombre_502ag, string apellido_502ag, string DNI_502ag, string email_502ag)
        {
            DAL_Usuario_502ag dalUsuario_502ag = new DAL_Usuario_502ag();
            string contraseña = FormatearContraseña_502ag(apellido_502ag, DNI_502ag);
            string nombreUsuario_502ag = DNI_502ag+nombre_502ag.ToLower();
            SE_Usuario_502ag usuario_502ag = new SE_Usuario_502ag(DNI_502ag, nombreUsuario_502ag, rol_502ag, nombre_502ag, apellido_502ag, email_502ag);
            usuario_502ag.isBloqueado_502ag = false;
            usuario_502ag.Intentos_502ag = 0;
            usuario_502ag.Contraseña_502ag = contraseña;
            usuario_502ag.Idioma_502ag = "es";
            usuario_502ag.isActivo_502ag = true;
            dalUsuario_502ag.AltaUsuario_502ag(usuario_502ag);
        }
        public bool VerificarExistenciaUsuario_502ag(string DNI_502ag, string email_502ag)
        {
            bool usuarioValido_502ag = true;
            foreach (SE_Usuario_502ag usuarioEnLista_502ag in ObtenerListaUsuarios_502ag())
            {
                if (usuarioEnLista_502ag.DNI_502ag == DNI_502ag || usuarioEnLista_502ag.Email_502ag == email_502ag ) usuarioValido_502ag = false;
            }
            return usuarioValido_502ag;
        }
        public bool VerificarAltaUsuario_502ag(string nombre_502ag, string apellido_502ag, string DNI_502ag, string email_502ag)
        {
            bool usuarioValido_502ag = true;
            Regex reDNI_502ag = new Regex(@"^\d{8}$");
            Regex reEmail_502ag = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+.[a-zA-Z]{2,40}$");
            Regex reNombreApellido_502ag = new Regex(@"^[A-Z][a-zÁÉÍÓÚáéíóúÑñ]{3,40}$");
            if (!reDNI_502ag.IsMatch(DNI_502ag)) usuarioValido_502ag = false;
            if (!reNombreApellido_502ag.IsMatch(nombre_502ag)) usuarioValido_502ag = false;
            if (!reNombreApellido_502ag.IsMatch(apellido_502ag)) usuarioValido_502ag = false;
            if (!reEmail_502ag.IsMatch(email_502ag)) usuarioValido_502ag = false;
            return usuarioValido_502ag;
        }
        #endregion

        #region Modificar
        public void ModificarUsuario_502ag(SE_Usuario_502ag usuario_502ag,string rol_502ag, string email_502ag)
        {
            DAL_Usuario_502ag dalUsuario_502ag = new DAL_Usuario_502ag();
            usuario_502ag.Rol_502ag = rol_502ag;
            usuario_502ag.Email_502ag = email_502ag;
            dalUsuario_502ag.ModificarUsuario_502ag(usuario_502ag);
        }
        public bool VerificarModificarUsuario_502ag(string email_502ag)
        {
            bool usuarioValido_502ag = true;
            Regex reEmail_502ag = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+.[a-zA-Z]{2,}$");
            if (!reEmail_502ag.IsMatch(email_502ag)) usuarioValido_502ag = false;
            return usuarioValido_502ag;
        }
        #endregion
        #endregion
    }
}
