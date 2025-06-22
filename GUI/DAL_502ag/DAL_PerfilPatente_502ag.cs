using SE_502ag;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_502ag
{
    public class DAL_PerfilPatente_502ag
    {
        public void AltaPerfilPatente_502ag(SE_Familia_502ag perfil_502ag)
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                foreach (SE_Perfil_502ag permiso_502ag in perfil_502ag.lista_502ag)
                {
                    if(permiso_502ag is SE_Patente_502ag patente_502ag)
                    {
                        using (SqlCommand cmd_502ag = new SqlCommand("INSERT INTO PerfilPatente_502ag (NombrePerfil_502ag, NombrePatente_502ag) VALUES (@NombrePerfil_502ag, @NombrePatente_502ag)",cx_502ag))
                        {
                            cmd_502ag.Parameters.AddWithValue("@NombrePerfil_502ag", perfil_502ag.Nombre_502ag);
                            cmd_502ag.Parameters.AddWithValue("@NombrePatente_502ag", patente_502ag.Nombre_502ag);
                            cmd_502ag.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        public void BorrarRelacionPerfilPatente_502ag(SE_Familia_502ag perfil_502ag)
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                List<string> listaPatentes = new List<string>();
                using (SqlCommand cmd_502ag = new SqlCommand("SELECT * FROM PerfilPatente_502ag WHERE NombrePerfil_502ag = @NombrePerfil_502ag", cx_502ag))
                {
                    cmd_502ag.Parameters.AddWithValue("@NombrePerfil_502ag", perfil_502ag.Nombre_502ag);
                    using (SqlDataReader dr_502ag = cmd_502ag.ExecuteReader())
                    {
                        while (dr_502ag.Read())
                        {
                            string nombre_502ag = dr_502ag["NombrePatente_502ag"].ToString();
                            listaPatentes.Add(nombre_502ag);
                        }
                    }
                }
                foreach (string patenteEnLista in listaPatentes)
                {
                    using (SqlCommand cmd_502ag = new SqlCommand("DELETE FROM PerfilPatente_502ag WHERE NombrePerfil_502ag = @NombrePerfil_502ag AND NombrePatente_502ag = @NombrePatente_502ag", cx_502ag))
                    {
                        cmd_502ag.Parameters.AddWithValue("@NombrePerfil_502ag", perfil_502ag.Nombre_502ag);
                        cmd_502ag.Parameters.AddWithValue("@NombrePatente_502ag", patenteEnLista);
                        cmd_502ag.ExecuteNonQuery();
                    }
                }
            }
        }
        public void AsignarPatenteAPerfil_502ag(SE_Familia_502ag perfil_502ag)
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                foreach (SE_Perfil_502ag permiso_502ag in perfil_502ag.lista_502ag)
                {
                    bool agregarPermiso_502ag = true;
                    if (permiso_502ag is SE_Patente_502ag patente_502ag)
                    {
                        using (SqlCommand cmd_502ag = new SqlCommand("SELECT * FROM PerfilPatente_502ag WHERE NombrePerfil_502ag = @NombrePerfil_502ag", cx_502ag))
                        {
                            cmd_502ag.Parameters.AddWithValue("@NombrePerfil_502ag", perfil_502ag.Nombre_502ag);
                            using (SqlDataReader dr_502ag = cmd_502ag.ExecuteReader())
                            {
                                while (dr_502ag.Read())
                                {
                                    if (dr_502ag["NombrePatente_502ag"].ToString() == patente_502ag.Nombre_502ag) agregarPermiso_502ag = false;
                                }
                            }
                            if (agregarPermiso_502ag)
                            {
                                cmd_502ag.CommandText = "INSERT INTO PerfilPatente_502ag (NombrePerfil_502ag, NombrePatente_502ag) VALUES (@NombrePerfil_502ag, @NombrePatente_502ag)";
                                cmd_502ag.Parameters.AddWithValue("@NombrePatente_502ag", patente_502ag.Nombre_502ag);
                                cmd_502ag.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
        }

        public void DesasignarPatenteDePerfil_502ag(SE_Familia_502ag perfil_502ag)
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                List<string> listaPatentes_502ag = new List<string>();
                using (SqlCommand cmd_502ag = new SqlCommand("SELECT * FROM PerfilPatente_502ag WHERE NombrePerfil_502ag = @NombrePerfil_502ag", cx_502ag))
                {
                    cmd_502ag.Parameters.AddWithValue("@NombrePerfil_502ag", perfil_502ag.Nombre_502ag);
                    using (SqlDataReader dr_502ag = cmd_502ag.ExecuteReader())
                    {
                        while (dr_502ag.Read())
                        {
                            string nombre_502ag = dr_502ag["NombrePatente_502ag"].ToString();
                            listaPatentes_502ag.Add(nombre_502ag);
                        }
                    }
                }
                foreach (string patenteEnLista_502ag in listaPatentes_502ag)
                {
                    using (SqlCommand cmd_502ag = new SqlCommand("DELETE FROM PerfilPatente_502ag WHERE NombrePerfil_502ag = @NombrePerfil_502ag AND NombrePatente_502ag = @NombrePatente_502ag", cx_502ag))
                    {
                        bool sigueAsignado_502ag = perfil_502ag.lista_502ag.Any(x => x.Nombre_502ag == patenteEnLista_502ag);
                        if (!sigueAsignado_502ag)
                        {
                            cmd_502ag.Parameters.AddWithValue("@NombrePerfil_502ag", perfil_502ag.Nombre_502ag);
                            cmd_502ag.Parameters.AddWithValue("@NombrePatente_502ag", patenteEnLista_502ag);
                            cmd_502ag.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        public void EliminarPatenteDePerfil_502ag(SE_Familia_502ag perfil_502ag, SE_Patente_502ag patente_502ag)
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                using (SqlCommand cmd = new SqlCommand("DELETE FROM PerfilPatente_502ag WHERE NombrePerfil_502ag = @NombrePerfil_502ag AND NombrePatente_502ag = @NombrePatente_502ag", cx_502ag))
                {
                    cmd.Parameters.AddWithValue("@NombrePerfil_502ag", perfil_502ag.Nombre_502ag);
                    cmd.Parameters.AddWithValue("@NombrePatente_502ag", patente_502ag.Nombre_502ag);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public SE_Familia_502ag ObtenerPatentesDePerfil_502ag(SE_Familia_502ag perfil_502ag)
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                using (SqlCommand cmd_502ag = new SqlCommand("SELECT * FROM PerfilPatente_502ag WHERE NombrePerfil_502ag = @NombrePerfil_502ag", cx_502ag))
                {
                    cmd_502ag.Parameters.AddWithValue("@NombrePerfil_502ag", perfil_502ag.Nombre_502ag);
                    using (SqlDataReader dr_502ag = cmd_502ag.ExecuteReader())
                    {
                        while (dr_502ag.Read())
                        {
                            SE_Perfil_502ag familia_502ag = new SE_Patente_502ag(dr_502ag["NombrePatente_502ag"].ToString());
                            perfil_502ag.Agregar_502ag(familia_502ag);
                        }
                    }
                }
            }
            return perfil_502ag;
        }

    }
}
