using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SE_502ag;

namespace DAL_502ag
{
    public class DAL_Usuario_502ag
    {
        public List<SE_Usuario_502ag> ObtenerListaUsuarios_502ag()
        {
            List<SE_Usuario_502ag> listaUsuarios_502ag = new List<SE_Usuario_502ag>();
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                using (SqlCommand cmd_502ag = new SqlCommand("SELECT * FROM Usuario_502ag", cx_502ag))
                {
                    cx_502ag.Open();
                    using (SqlDataReader dr_502ag = cmd_502ag.ExecuteReader())
                    {
                        while (dr_502ag.Read())
                        {
                            SE_Usuario_502ag usuario_502ag = new SE_Usuario_502ag(
                                dr_502ag["DNI_502ag"].ToString(),
                                dr_502ag["NombreUsuario_502ag"].ToString(),
                                dr_502ag["Contraseña_502ag"].ToString(),
                                dr_502ag["Rol_502ag"].ToString(),
                                dr_502ag["Nombre_502ag"].ToString(),
                                dr_502ag["Apellido_502ag"].ToString(),
                                dr_502ag["Email_502ag"].ToString(),
                                bool.Parse(dr_502ag["IsBloqueado_502ag"].ToString()),
                                int.Parse(dr_502ag["Intentos_502ag"].ToString()),
                                dr_502ag["Idioma_502ag"].ToString(),
                                bool.Parse(dr_502ag["IsActivo_502ag"].ToString()));
                            listaUsuarios_502ag.Add(usuario_502ag);
                        }
                    }
                }
            }
            return listaUsuarios_502ag;
        }
        public SE_Usuario_502ag ObtenerUsuario_502ag(string dni_502ag)
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                using (SqlCommand cmd_502ag = new SqlCommand("SELECT * FROM Usuario_502ag WHERE DNI_502ag = @DNI_502ag ", cx_502ag))
                {
                    cmd_502ag.Parameters.AddWithValue("@DNI_502ag", dni_502ag);
                    cx_502ag.Open();
                    using (SqlDataReader dr_502ag = cmd_502ag.ExecuteReader())
                    {
                        if (dr_502ag.Read())
                        {
                            return new SE_Usuario_502ag(
                               dr_502ag["DNI_502ag"].ToString(),
                               dr_502ag["NombreUsuario_502ag"].ToString(),
                               dr_502ag["Contraseña_502ag"].ToString(),
                               dr_502ag["Rol_502ag"].ToString(),
                               dr_502ag["Nombre_502ag"].ToString(),
                               dr_502ag["Apellido_502ag"].ToString(),
                               dr_502ag["Email_502ag"].ToString(),
                               bool.Parse(dr_502ag["IsBloqueado_502ag"].ToString()),
                               int.Parse(dr_502ag["Intentos_502ag"].ToString()),
                               dr_502ag["Idioma_502ag"].ToString(),
                               bool.Parse(dr_502ag["IsActivo_502ag"].ToString()));
                        }
                    }
                }
            }
            return null;
        }
        public SE_Usuario_502ag ObtenerUsuarioALogear(string nombreUsuario_502ag)
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                using (SqlCommand cmd_502ag = new SqlCommand("SELECT * FROM Usuario_502ag WHERE NombreUsuario_502ag = @NombreUsuario_502ag ", cx_502ag))
                {
                    cmd_502ag.Parameters.AddWithValue("@NombreUsuario_502ag", nombreUsuario_502ag);
                    cx_502ag.Open();
                    using (SqlDataReader dr_502ag = cmd_502ag.ExecuteReader())
                    {
                        if (dr_502ag.Read())
                        {
                            return new SE_Usuario_502ag(
                               dr_502ag["DNI_502ag"].ToString(),
                               dr_502ag["NombreUsuario_502ag"].ToString(),
                               dr_502ag["Contraseña_502ag"].ToString(),
                               dr_502ag["Rol_502ag"].ToString(),
                               dr_502ag["Nombre_502ag"].ToString(),
                               dr_502ag["Apellido_502ag"].ToString(),
                               dr_502ag["Email_502ag"].ToString(),
                               bool.Parse(dr_502ag["IsBloqueado_502ag"].ToString()),
                               int.Parse(dr_502ag["Intentos_502ag"].ToString()),
                               dr_502ag["Idioma_502ag"].ToString(),
                               bool.Parse(dr_502ag["IsActivo_502ag"].ToString()));
                        }
                    }
                }
            }
            return null;
        }
        #region AltaUsuario
        public void AltaUsuario_502ag(SE_Usuario_502ag usuario_502ag)
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                string insertQuery_502ag = "INSERT INTO Usuario_502ag (DNI_502ag, NombreUsuario_502ag, Contraseña_502ag, Rol_502ag, Nombre_502ag, Apellido_502ag, Email_502ag," +
                    "IsBloqueado_502ag, Intentos_502ag, Idioma_502ag, IsActivo_502ag) " +
                    "VALUES (@DNI_502ag, @NombreUsuario_502ag, @Contraseña_502ag, @Rol_502ag, @Nombre_502ag, @Apellido_502ag, @Email_502ag," +
                    "@IsBloqueado_502ag, @Intentos_502ag, @Idioma_502ag, @IsActivo_502ag)";
                using (SqlCommand cmd_502ag = new SqlCommand(insertQuery_502ag, cx_502ag)) 
                {
                    cmd_502ag.Parameters.AddWithValue("@DNI_502ag", usuario_502ag.DNI_502ag);
                    cmd_502ag.Parameters.AddWithValue("@NombreUsuario_502ag", usuario_502ag.NombreUsuario_502ag);
                    cmd_502ag.Parameters.AddWithValue("@Contraseña_502ag", usuario_502ag.Contraseña_502ag);
                    cmd_502ag.Parameters.AddWithValue("@Rol_502ag", usuario_502ag.Rol_502ag);
                    cmd_502ag.Parameters.AddWithValue("@Nombre_502ag", usuario_502ag.Nombre_502ag);
                    cmd_502ag.Parameters.AddWithValue("@Apellido_502ag", usuario_502ag.Apellido_502ag);
                    cmd_502ag.Parameters.AddWithValue("@Email_502ag", usuario_502ag.Email_502ag);
                    cmd_502ag.Parameters.AddWithValue("@IsBloqueado_502ag", usuario_502ag.isBloqueado_502ag);
                    cmd_502ag.Parameters.AddWithValue("@Intentos_502ag", usuario_502ag.Intentos_502ag);
                    cmd_502ag.Parameters.AddWithValue("@Idioma_502ag", usuario_502ag.Idioma_502ag);
                    cmd_502ag.Parameters.AddWithValue("@IsActivo_502ag", usuario_502ag.isActivo_502ag);
                    cmd_502ag.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region ModificarUsuario
        public void ModificarUsuario_502ag(SE_Usuario_502ag usuario_502ag)
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                string updateQuery_502ag = "UPDATE Usuario_502ag SET Rol_502ag = @Rol_502ag, Nombre_502ag = @Nombre_502ag, Apellido_502ag = @Apellido_502ag, Email_502ag = @Email_502ag WHERE DNI_502ag = @DNI_502ag";
                using(SqlCommand cmd_502ag = new SqlCommand("SELECT * FROM Usuario_502ag", cx_502ag))
                {
                    cmd_502ag.CommandText = updateQuery_502ag;
                    cmd_502ag.Parameters.AddWithValue("@DNI_502ag", usuario_502ag.DNI_502ag);
                    cmd_502ag.Parameters.AddWithValue("@Rol_502ag", usuario_502ag.Rol_502ag);
                    cmd_502ag.Parameters.AddWithValue("@Nombre_502ag", usuario_502ag.Nombre_502ag);
                    cmd_502ag.Parameters.AddWithValue("@Apellido_502ag", usuario_502ag.Apellido_502ag);
                    cmd_502ag.Parameters.AddWithValue("@Email_502ag", usuario_502ag.Email_502ag);
                    cmd_502ag.ExecuteNonQuery();
                }
            }
        }
        #endregion
        public void ActualizarBloqueo_502ag(SE_Usuario_502ag usuario_502ag)
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                string updateQuery_502ag = "UPDATE Usuario_502ag SET IsBloqueado_502ag = @IsBloqueado_502ag, Intentos_502ag = @Intentos_502ag, Contraseña_502ag = @Contraseña_502ag WHERE DNI_502ag = @DNI_502ag";
                using(SqlCommand cmd_502ag = new SqlCommand("SELECT * FROM Usuario_502ag", cx_502ag))
                {
                    cmd_502ag.CommandText = updateQuery_502ag;
                    cmd_502ag.Parameters.AddWithValue("@DNI_502ag", usuario_502ag.DNI_502ag);
                    cmd_502ag.Parameters.AddWithValue("@IsBloqueado_502ag", usuario_502ag.isBloqueado_502ag);
                    cmd_502ag.Parameters.AddWithValue("@Intentos_502ag", usuario_502ag.Intentos_502ag);
                    cmd_502ag.Parameters.AddWithValue("@Contraseña_502ag", usuario_502ag.Contraseña_502ag);
                    cmd_502ag.ExecuteNonQuery();
                }
            }
        }
        public void ActualizarBloqueoLogin_502ag(SE_Usuario_502ag usuario_502ag)
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                string updateQuery_502ag = "UPDATE Usuario_502ag SET IsBloqueado_502ag = @IsBloqueado_502ag, Intentos_502ag = @Intentos_502ag WHERE DNI_502ag = @DNI_502ag";
                using (SqlCommand cmd_502ag = new SqlCommand("SELECT * FROM Usuario_502ag", cx_502ag))
                {
                    cmd_502ag.CommandText = updateQuery_502ag;
                    cmd_502ag.Parameters.AddWithValue("@DNI_502ag", usuario_502ag.DNI_502ag);
                    cmd_502ag.Parameters.AddWithValue("@IsBloqueado_502ag", usuario_502ag.isBloqueado_502ag);
                    cmd_502ag.Parameters.AddWithValue("@Intentos_502ag", usuario_502ag.Intentos_502ag);
                    cmd_502ag.ExecuteNonQuery();
                }
            }
        }
        public void ActualizarContraseña_502ag(SE_Usuario_502ag usuario_502ag)
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                string updateQuery_502ag = "UPDATE Usuario_502ag SET Contraseña_502ag = @Contraseña_502ag WHERE DNI_502ag = @DNI_502ag";
                using (SqlCommand cmd_502ag = new SqlCommand("SELECT * FROM Usuario_502ag", cx_502ag))
                {
                    cmd_502ag.CommandText = updateQuery_502ag;
                    cmd_502ag.Parameters.AddWithValue("@DNI_502ag", usuario_502ag.DNI_502ag);
                    cmd_502ag.Parameters.AddWithValue("Contraseña_502ag", usuario_502ag.Contraseña_502ag);
                    cmd_502ag.ExecuteNonQuery();
                }
            }
        }
        
        #region ActivarDesactivar
        public void ActualizarActivo_502ag(SE_Usuario_502ag usuario_502ag)
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                string updateQuery_502ag = "UPDATE Usuario_502ag SET IsActivo_502ag = @IsActivo_502ag WHERE DNI_502ag = @DNI_502ag";
                using (SqlCommand cmd_502ag = new SqlCommand(updateQuery_502ag, cx_502ag))
                {
                    cmd_502ag.CommandText = updateQuery_502ag;
                    cmd_502ag.Parameters.AddWithValue("@DNI_502ag", usuario_502ag.DNI_502ag);
                    cmd_502ag.Parameters.AddWithValue("IsActivo_502ag", usuario_502ag.isActivo_502ag);
                    cmd_502ag.ExecuteNonQuery();
                }
            }
        }
        #endregion


    }
}
