using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using BE;

namespace ORM
{
    public class ORM_Usuario_502ag
    {
        DAO_Usuario_502ag daoUsuario = new DAO_Usuario_502ag();
        public List<BE_Usuario_502ag> DevolverListaUsuarios()
        {
            List<BE_Usuario_502ag> listaUsuarios = new List<BE_Usuario_502ag>();
            foreach(DataRow dr in daoUsuario.DevolverDTUsuario().Rows)
            {
                if(dr.RowState != DataRowState.Deleted)
                {
                    BE_Usuario_502ag usuario = new BE_Usuario_502ag(
                        dr["NombreUsuario_502ag"].ToString(), 
                        dr["Contraseña_502ag"].ToString(), 
                        dr["Rol_502ag"].ToString(), 
                        dr["Nombre_502ag"].ToString(), 
                        dr["Apellido_502ag"].ToString(), 
                        dr["DNI_502ag"].ToString(), 
                        dr["Email_502ag"].ToString(), 
                        Convert.ToBoolean(dr["IsBloqueado_502ag"].ToString()), 
                        int.Parse(dr["Intentos_502ag"].ToString()), 
                        dr["Idioma_502ag"].ToString());
                    listaUsuarios.Add(usuario);
                }
            }
            return listaUsuarios;
        }
        public void ActualizarBloqueo(BE_Usuario_502ag entidad)
        {
            DataRow dr = daoUsuario.DevolverDTUsuario().Rows.Find(entidad.NombreUsuario);
            dr["IsBloqueado_502ag"] = entidad.isBloqueado;
            dr["Intentos_502ag"] = entidad.Intentos;
            dr["Contraseña_502ag"] = entidad.Contraseña;
            daoUsuario.Actualizar();
        }

        public void ActualizarContraseña(BE_Usuario_502ag entidad)
        {
            DataRow dr = daoUsuario.DevolverDTUsuario().Rows.Find(entidad.NombreUsuario);
            dr["Contraseña_502ag"] = entidad.Contraseña;
            daoUsuario.Actualizar();
        }
        public void ActualizarIdioma(BE_Usuario_502ag entidad)
        {
            DataRow dr = daoUsuario.DevolverDTUsuario().Rows.Find(entidad.NombreUsuario);
            dr["Idioma_502ag"] = entidad.Idioma;
            daoUsuario.Actualizar();
        }

        #region ABM
        #region Alta
        public void AltaUsuario_502ag(BE_Usuario_502ag entidad)
        {
            daoUsuario.DevolverDTUsuario().Rows.Add(entidad.NombreUsuario, entidad.Contraseña, entidad.Rol, entidad.Nombre, entidad.Apellido, entidad.DNI, entidad.Email, entidad.isBloqueado, entidad.Intentos, entidad.Idioma);
            daoUsuario.Actualizar();
        }
        #endregion
        public void Baja(BE_Usuario_502ag entidad)
        {
            DataRow drBaja = daoUsuario.DevolverDTUsuario().Rows.Find(entidad.NombreUsuario);
            drBaja.Delete();
            daoUsuario.Actualizar();
        }
        public void Modificar(BE_Usuario_502ag entidad)
        {
            DataRow drModificar = daoUsuario.DevolverDTUsuario().Rows.Find(entidad.NombreUsuario);
            drModificar.ItemArray = new object[] {entidad.NombreUsuario, entidad.Contraseña, entidad.Rol, entidad.Nombre, entidad.Apellido, entidad.DNI, entidad.Email, entidad.isBloqueado, entidad.Intentos };
            daoUsuario.Actualizar();
        }
        #endregion
    }
}
