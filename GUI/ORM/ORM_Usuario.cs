﻿using System;
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
    public class ORM_Usuario
    {
        DAO_Usuario daoUsuario = new DAO_Usuario();
        public List<BE_Usuario> DevolverListaUsuarios()
        {
            List<BE_Usuario> listaUsuarios = new List<BE_Usuario>();
            foreach(DataRow dr in daoUsuario.DevolverDTUsuario().Rows)
            {
                if(dr.RowState != DataRowState.Deleted)
                {
                    BE_Usuario usuario = new BE_Usuario(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), Convert.ToBoolean(dr[7].ToString()), int.Parse(dr[8].ToString()), dr[9].ToString());
                    listaUsuarios.Add(usuario);
                }
            }
            return listaUsuarios;
        }
        public void ActualizarBloqueo(BE_Usuario entidad)
        {
            DataRow dr = daoUsuario.DevolverDTUsuario().Rows.Find(entidad.NombreUsuario);
            dr[7] = entidad.isBloqueado;
            dr[8] = entidad.Intentos;
            daoUsuario.Actualizar();
        }
        public void ActualizarContraseña(BE_Usuario entidad)
        {
            DataRow dr = daoUsuario.DevolverDTUsuario().Rows.Find(entidad.NombreUsuario);
            dr[1] = entidad.Contraseña;
            daoUsuario.Actualizar();
        }
        public void ActualizarIdioma(BE_Usuario entidad)
        {
            DataRow dr = daoUsuario.DevolverDTUsuario().Rows.Find(entidad.NombreUsuario);
            dr[9] = entidad.Idioma;
            daoUsuario.Actualizar();
        }
        public void Alta(BE_Usuario entidad)
        {
            daoUsuario.DevolverDTUsuario().Rows.Add(entidad.NombreUsuario, entidad.Contraseña, entidad.Rol, entidad.Nombre, entidad.Apellido, entidad.DNI, entidad.Email, entidad.isBloqueado, entidad.Intentos, entidad.Idioma);
            daoUsuario.Actualizar();
        }
        public void Baja(BE_Usuario entidad)
        {
            DataRow drBaja = daoUsuario.DevolverDTUsuario().Rows.Find(entidad.NombreUsuario);
            drBaja.Delete();
            daoUsuario.Actualizar();
        }
        public void Modificar(BE_Usuario entidad)
        {
            DataRow drModificar = daoUsuario.DevolverDTUsuario().Rows.Find(entidad.NombreUsuario);
            drModificar.ItemArray = new object[] {entidad.NombreUsuario, entidad.Contraseña, entidad.Rol, entidad.Nombre, entidad.Apellido, entidad.DNI, entidad.Email, entidad.isBloqueado, entidad.Intentos };
            daoUsuario.Actualizar();
        }
    }
}
