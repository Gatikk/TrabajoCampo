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
        Cifrador cifrador = new Cifrador();
        
        public void IniciarSesion(BE_Usuario entidad)
        {
            entidad.Intentos = 0;
            SERVICIOS.SessionManager.GestorSessionManager().IniciarSesion(entidad);
            ormUsuario.ActualizarBloqueo(entidad);
        }
        public void SesionFallida(BE_Usuario entidad)
        {
            if(entidad.Rol != "admin")
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
            if(entidad.Contraseña == cifrador.CifradorIrreversible(contraseña))
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
            return ormUsuario.DevolverListaUsuarios();
        }

        public void Bloquear(BE_Usuario entidad)
        {
            if(entidad.Rol != "admin")
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
            if(entidad.isBloqueado != false)
            {
                entidad.isBloqueado = false;
                entidad.Intentos = 0;
                ormUsuario.ActualizarBloqueo(entidad);
            }
        }

        public void CambiarContraseña(string nuevaContraseña, BE_Usuario entidad)
        {
            entidad.Contraseña = cifrador.CifradorIrreversible(nuevaContraseña);
            ormUsuario.ActualizarContraseña(entidad);
        }
        public void Alta(BE_Usuario entidad)
        {
            string[] primerApellido = entidad.Apellido.Split(' ');
            primerApellido[0] = primerApellido[0].ToLower().Trim();
            entidad.Contraseña = cifrador.CifradorIrreversible(entidad.DNI + primerApellido[0]);
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
