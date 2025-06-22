using SE_502ag;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_502ag
{
    public class DAL_PerfilFamilia_502ag
    {
        public void AltaPerfilPatente_502ag(SE_Familia_502ag perfil_502ag)
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                foreach (SE_Perfil_502ag permiso_502ag in perfil_502ag.lista_502ag)
                {
                    if (permiso_502ag is SE_Familia_502ag familia_502ag)
                    {
                        using (SqlCommand cmd_502ag = new SqlCommand("INSERT INTO PerfilFamilia_502ag (NombrePerfil_502ag, NombreFamilia_502ag) VALUES (@NombrePerfil_502ag, @NombreFamilia_502ag)",cx_502ag))
                        {
                            cmd_502ag.Parameters.AddWithValue("@NombrePerfil_502ag", perfil_502ag.Nombre_502ag);
                            cmd_502ag.Parameters.AddWithValue("@NombreFamilia_502ag", familia_502ag.Nombre_502ag);
                            cmd_502ag.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        public void BorrarRelacionPerfilFamilia_502ag(SE_Familia_502ag perfil_502ag)
        {
            List<string> listaFamilias = new List<string>();
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                using (SqlCommand cmd_502ag = new SqlCommand("SELECT * FROM PerfilFamilia_502ag WHERE NombrePerfil_502ag = @NombrePerfil_502ag", cx_502ag))
                {
                    cmd_502ag.Parameters.AddWithValue("@NombrePerfil_502ag", perfil_502ag.Nombre_502ag);
                    using (SqlDataReader dr_502ag = cmd_502ag.ExecuteReader())
                    {
                        while (dr_502ag.Read())
                        {
                            listaFamilias.Add(dr_502ag["NombreFamilia_502ag"].ToString());
                        }
                    }
                }
                foreach (string familiaEnLista in listaFamilias)
                {
                    using (SqlCommand cmd_502ag = new SqlCommand("DELETE FROM PerfilFamilia_502ag WHERE NombrePerfil_502ag = @NombrePerfil_502ag AND NombreFamilia_502ag = @NombreFamilia_502ag", cx_502ag))
                    {
                        cmd_502ag.Parameters.AddWithValue("@NombrePerfil_502ag", perfil_502ag.Nombre_502ag);
                        cmd_502ag.Parameters.AddWithValue("@NombreFamilia_502ag", familiaEnLista);
                        cmd_502ag.ExecuteNonQuery();
                    }
                }
            }
        }
        public void AsignarFamiliaAPerfil_502ag(SE_Familia_502ag perfil_502ag)
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                foreach (SE_Perfil_502ag permiso_502ag in perfil_502ag.lista_502ag)
                {
                    bool agregarPermiso_502ag = true;
                    if (permiso_502ag is SE_Familia_502ag familia_502ag)
                    {
                        using (SqlCommand cmd_502ag = new SqlCommand("SELECT * FROM PerfilFamilia_502ag WHERE NombrePerfil_502ag = @NombrePerfil_502ag", cx_502ag))
                        {
                            cmd_502ag.Parameters.AddWithValue("@NombrePerfil_502ag", perfil_502ag.Nombre_502ag);
                            using (SqlDataReader dr_502ag = cmd_502ag.ExecuteReader())
                            {
                                while (dr_502ag.Read())
                                {
                                    if (dr_502ag["NombreFamilia_502ag"].ToString() == familia_502ag.Nombre_502ag) agregarPermiso_502ag = false;
                                }
                            }
                            if (agregarPermiso_502ag)
                            {
                                cmd_502ag.CommandText = "INSERT INTO PerfilFamilia_502ag (NombrePerfil_502ag, NombreFamilia_502ag) VALUES (@NombrePerfil_502ag, @NombreFamilia_502ag)";
                                cmd_502ag.Parameters.AddWithValue("@NombreFamilia_502ag", familia_502ag.Nombre_502ag);
                                cmd_502ag.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
        }

        public void DesasignarFamiliaDePerfil_502ag(SE_Familia_502ag perfil_502ag)
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                List<string> listaFamilias_502ag = new List<string>();
                using (SqlCommand cmd_502ag = new SqlCommand("SELECT * FROM PerfilFamilia_502ag WHERE NombrePerfil_502ag = @NombrePerfil_502ag", cx_502ag))
                {
                    cmd_502ag.Parameters.AddWithValue("@NombrePerfil_502ag", perfil_502ag.Nombre_502ag);
                    using (SqlDataReader dr_502ag = cmd_502ag.ExecuteReader())
                    {
                        while (dr_502ag.Read())
                        {
                            string nombre_502ag = dr_502ag["NombreFamilia_502ag"].ToString();
                            listaFamilias_502ag.Add(nombre_502ag);
                        }
                    }
                }
                foreach (string familiaEnLista_502ag in listaFamilias_502ag)
                {
                    using (SqlCommand cmd_502ag = new SqlCommand("DELETE FROM PerfilFamilia_502ag WHERE NombrePerfil_502ag = @NombrePerfil_502ag AND NombreFamilia_502ag = @NombreFamilia_502ag", cx_502ag))
                    {
                        bool sigueAsignado_502ag = perfil_502ag.lista_502ag.Any(x => x.Nombre_502ag == familiaEnLista_502ag);
                        if (!sigueAsignado_502ag)
                        {
                            cmd_502ag.Parameters.AddWithValue("@NombrePerfil_502ag", perfil_502ag.Nombre_502ag);
                            cmd_502ag.Parameters.AddWithValue("@NombreFamilia_502ag", familiaEnLista_502ag);
                            cmd_502ag.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
        public SE_Familia_502ag ObtenerFamiliasDePerfil_502ag(SE_Familia_502ag perfil_502ag)
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                using (SqlCommand cmd_502ag = new SqlCommand("SELECT * FROM PerfilFamilia_502ag WHERE NombrePerfil_502ag = @NombrePerfil_502ag", cx_502ag))
                {
                    cmd_502ag.Parameters.AddWithValue("@NombrePerfil_502ag", perfil_502ag.Nombre_502ag);
                    using (SqlDataReader dr_502ag = cmd_502ag.ExecuteReader())
                    {
                        while (dr_502ag.Read())
                        {
                            SE_Perfil_502ag familia_502ag = new SE_Familia_502ag(dr_502ag["NombreFamilia_502ag"].ToString());
                            perfil_502ag.Agregar_502ag(familia_502ag);
                        }
                    }
                }
            }
            return perfil_502ag;
        }
    }
}
