using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using BE_502ag;

namespace ORM_502ag
{
    public class ORM_Usuario_502ag
    {
        DAO_Usuario_502ag daoUsuario_502ag = new DAO_Usuario_502ag();
        public List<BE_Usuario_502ag> DevolverListaUsuarios_502ag()
        {
            List<BE_Usuario_502ag> listaUsuarios_502ag = new List<BE_Usuario_502ag>();
            foreach(DataRow dr_502ag in daoUsuario_502ag.DevolverDTUsuario_502ag().Rows)
            {
                if(dr_502ag.RowState != DataRowState.Deleted)
                {
                    BE_Usuario_502ag usuario_502ag = new BE_Usuario_502ag(
                        dr_502ag["DNI_502ag"].ToString(), 
                        dr_502ag["NombreUsuario_502ag"].ToString(), 
                        dr_502ag["Contraseña_502ag"].ToString(), 
                        dr_502ag["Rol_502ag"].ToString(), 
                        dr_502ag["Nombre_502ag"].ToString(), 
                        dr_502ag["Apellido_502ag"].ToString(), 
                        dr_502ag["Email_502ag"].ToString(), 
                        Convert.ToBoolean(dr_502ag["IsBloqueado_502ag"].ToString()), 
                        int.Parse(dr_502ag["Intentos_502ag"].ToString()), 
                        dr_502ag["Idioma_502ag"].ToString(),
                        Convert.ToBoolean(dr_502ag["IsActivo_502ag"])        
                        );
                    listaUsuarios_502ag.Add(usuario_502ag);
                }
            }
            return listaUsuarios_502ag;
        }
        public void ActualizarBloqueo_502ag(BE_Usuario_502ag usuario_502ag)
        {
            DataRow dr_502ag = daoUsuario_502ag.DevolverDTUsuario_502ag().Rows.Find(usuario_502ag.DNI_502ag);
            dr_502ag["IsBloqueado_502ag"] = usuario_502ag.isBloqueado_502ag;
            dr_502ag["Intentos_502ag"] = usuario_502ag.Intentos_502ag;
            dr_502ag["Contraseña_502ag"] = usuario_502ag.Contraseña_502ag;
            daoUsuario_502ag.Actualizar_502ag();
        }

        public void ActualizarContraseña_502ag(BE_Usuario_502ag usuario_502ag)
        {
            DataRow dr_502ag = daoUsuario_502ag.DevolverDTUsuario_502ag().Rows.Find(usuario_502ag.DNI_502ag);
            dr_502ag["Contraseña_502ag"] = usuario_502ag.Contraseña_502ag;
            daoUsuario_502ag.Actualizar_502ag();
        }
        public void ActualizarIdioma_502ag(BE_Usuario_502ag usuario_502ag)
        {
            DataRow dr_502ag = daoUsuario_502ag.DevolverDTUsuario_502ag().Rows.Find(usuario_502ag.DNI_502ag);
            dr_502ag["Idioma_502ag"] = usuario_502ag.Idioma_502ag;
            daoUsuario_502ag.Actualizar_502ag();
        }
        #region ActivarDesactivar
        public void ActualizarActivo_502ag(BE_Usuario_502ag usuario_502ag)
        {
            DataRow dr_502ag = daoUsuario_502ag.DevolverDTUsuario_502ag().Rows.Find(usuario_502ag.DNI_502ag);
            dr_502ag["IsActivo_502ag"] = usuario_502ag.isActivo_502ag;
            daoUsuario_502ag.Actualizar_502ag();
        }

        #endregion


        #region ABM
        #region Alta
        public void AltaUsuario_502ag(BE_Usuario_502ag usuario_502ag)
        {
            daoUsuario_502ag.DevolverDTUsuario_502ag().Rows.Add(usuario_502ag.DNI_502ag, usuario_502ag.NombreUsuario_502ag, usuario_502ag.Contraseña_502ag, usuario_502ag.Rol_502ag, usuario_502ag.Nombre_502ag, usuario_502ag.Apellido_502ag, usuario_502ag.Email_502ag, usuario_502ag.isBloqueado_502ag, usuario_502ag.Intentos_502ag, usuario_502ag.Idioma_502ag, usuario_502ag.isActivo_502ag);
            daoUsuario_502ag.Actualizar_502ag();
        }
        #endregion
        public void Baja(BE_Usuario_502ag usuario_502ag)
        {
            DataRow drBaja = daoUsuario_502ag.DevolverDTUsuario_502ag().Rows.Find(usuario_502ag.NombreUsuario_502ag);
            drBaja.Delete();
            daoUsuario_502ag.Actualizar_502ag();
        }
        public void Modificar_502ag(BE_Usuario_502ag usuario_502ag)
        {
            DataRow drModificar_502ag = daoUsuario_502ag.DevolverDTUsuario_502ag().Rows.Find(usuario_502ag.DNI_502ag);
            drModificar_502ag.ItemArray = new object[] {usuario_502ag.DNI_502ag, usuario_502ag.NombreUsuario_502ag, usuario_502ag.Contraseña_502ag, usuario_502ag.Rol_502ag, usuario_502ag.Nombre_502ag, usuario_502ag.Apellido_502ag,  usuario_502ag.Email_502ag, usuario_502ag.isBloqueado_502ag, usuario_502ag.Intentos_502ag, usuario_502ag.isActivo_502ag };
            daoUsuario_502ag.Actualizar_502ag();
        }
        #endregion
    }
}
