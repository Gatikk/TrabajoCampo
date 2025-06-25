using SE_502ag;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_502ag
{
    public class DAL_FamiliaPatente_502ag
    {
        public void AltaFamiliaPatente_502ag(SE_Familia_502ag familia_502ag)
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                foreach (SE_Perfil_502ag perfil_502ag in familia_502ag.lista_502ag)
                {
                    if(perfil_502ag is SE_Patente_502ag patente_502ag)
                    {
                        using (SqlCommand cmd_502ag = new SqlCommand("INSERT INTO FamiliaPatente_502ag (NombreFamilia_502ag, NombrePatente_502ag) VALUES (@NombreFamilia_502ag, @NombrePatente_502ag)", cx_502ag))
                        {
                            cmd_502ag.Parameters.AddWithValue("@NombreFamilia_502ag", familia_502ag.Nombre_502ag);
                            cmd_502ag.Parameters.AddWithValue("@NombrePatente_502ag", patente_502ag.Nombre_502ag);
                            cmd_502ag.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        public void EliminarPatenteDeFamilia_502ag(SE_Familia_502ag familia_502ag, SE_Patente_502ag patente_502ag)
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                using (SqlCommand cmd = new SqlCommand("DELETE FROM FamiliaPatente_502ag WHERE NombreFamilia_502ag = @NombreFamilia_502ag AND NombrePatente_502ag = @NombrePatente_502ag", cx_502ag))
                {
                    cmd.Parameters.AddWithValue("@NombreFamilia_502ag", familia_502ag.Nombre_502ag);
                    cmd.Parameters.AddWithValue("@NombrePatente_502ag", patente_502ag.Nombre_502ag);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AsignarPatenteAFamilia_502ag(SE_Familia_502ag familia_502ag)
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                foreach (SE_Perfil_502ag permiso_502ag in familia_502ag.lista_502ag)
                {
                    bool agregarPermiso = true;
                    if (permiso_502ag is SE_Patente_502ag patente_502ag)
                    {
                        using (SqlCommand cmd_502ag = new SqlCommand("SELECT * FROM FamiliaPatente_502ag WHERE NombreFamilia_502ag = @NombreFamilia_502ag", cx_502ag))
                        {
                            cmd_502ag.Parameters.AddWithValue("@NombreFamilia_502ag", familia_502ag.Nombre_502ag);
                            using (SqlDataReader dr_502ag = cmd_502ag.ExecuteReader())
                            {
                                while (dr_502ag.Read())
                                {
                                    if (dr_502ag["NombrePatente_502ag"].ToString() == patente_502ag.Nombre_502ag) agregarPermiso = false;
                                }
                            }
                            if (agregarPermiso)
                            {
                                cmd_502ag.CommandText = "INSERT INTO FamiliaPatente_502ag (NombreFamilia_502ag, NombrePatente_502ag) VALUES (@NombreFamilia_502ag, @NombrePatente_502ag)";
                                cmd_502ag.Parameters.AddWithValue("@NombrePatente_502ag", patente_502ag.Nombre_502ag);
                                cmd_502ag.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
        }

        public void BorrarRelacionFamiliaPatente_502ag(SE_Familia_502ag familia_502ag)
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                using(SqlCommand cmd_502ag = new SqlCommand("DELETE FROM FamiliaPatente_502ag WHERE NombreFamilia_502ag = @NombreFamilia_502ag", cx_502ag))
                {
                    cmd_502ag.Parameters.AddWithValue("@NombreFamilia_502ag", familia_502ag.Nombre_502ag);
                    cmd_502ag.ExecuteNonQuery();
                }
            }
        }
        public void DesasignarPatenteDeFamilia(SE_Familia_502ag familia_502ag)
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                List<string> listaPatentes = new List<string>();
                using (SqlCommand cmd_502ag = new SqlCommand("SELECT * FROM FamiliaPatente_502ag WHERE NombreFamilia_502ag = @NombreFamilia_502ag", cx_502ag))
                {
                    cmd_502ag.Parameters.AddWithValue("@NombreFamilia_502ag", familia_502ag.Nombre_502ag);
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
                    using (SqlCommand cmd_502ag = new SqlCommand("DELETE FROM FamiliaPatente_502ag WHERE NombreFamilia_502ag = @NombreFamilia_502ag AND NombrePatente_502ag = @NombrePatente_502ag", cx_502ag))
                    {
                        bool sigueAsignado = familia_502ag.lista_502ag.Any(x => x.Nombre_502ag == patenteEnLista);
                        if (!sigueAsignado)
                        {
                            cmd_502ag.Parameters.AddWithValue("@NombreFamilia_502ag", familia_502ag.Nombre_502ag);
                            cmd_502ag.Parameters.AddWithValue("@NombrePatente_502ag", patenteEnLista);
                            cmd_502ag.ExecuteNonQuery();
                        }
                    }
                } 
            }
        }


        public SE_Familia_502ag ObtenerPatentesDeFamilia_502ag(SE_Familia_502ag familia_502ag)
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                using(SqlCommand cmd_502ag = new SqlCommand($"SELECT * FROM FamiliaPatente_502ag WHERE NombreFamilia_502ag = @NombreFamilia_502ag", cx_502ag))
                {
                    cmd_502ag.Parameters.AddWithValue("@NombreFamilia_502ag", familia_502ag.Nombre_502ag);
                    using (SqlDataReader dr_502ag = cmd_502ag.ExecuteReader())
                    {
                        while (dr_502ag.Read())
                        {
                            SE_Perfil_502ag patente_502ag = new SE_Patente_502ag(dr_502ag["NombrePatente_502ag"].ToString());
                            familia_502ag.Agregar_502ag(patente_502ag);
                        }
                    }
                }
            }
            return familia_502ag;
        } 
    }
}
