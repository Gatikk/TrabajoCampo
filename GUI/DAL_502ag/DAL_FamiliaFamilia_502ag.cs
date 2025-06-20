using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SE_502ag;
using DAL_502ag;

namespace DAL_502ag
{
    public class DAL_FamiliaFamilia_502ag
    {
        public void AltaFamiliaFamilia_502ag(SE_Familia_502ag familia_502ag)
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag()) 
            {
                cx_502ag.Open();
                foreach(SE_Perfil_502ag perfil_502ag in familia_502ag.lista_502ag)
                {
                    if(perfil_502ag is SE_Familia_502ag familiaHijo_502ag)
                    {
                        using (SqlCommand cmd_502ag = new SqlCommand("INSERT INTO FamiliaFamilia_502ag (NombrePadre_502ag, NombreHijo_502ag) VALUES (@NombrePadre_502ag, @NombreHijo_502ag)", cx_502ag))
                        {
                            cmd_502ag.Parameters.AddWithValue("@NombrePadre_502ag", familia_502ag.Nombre_502ag);
                            cmd_502ag.Parameters.AddWithValue("@NombreHijo_502ag", familiaHijo_502ag.Nombre_502ag);
                            cmd_502ag.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        public SE_Familia_502ag ObtenerPermisosDeFamilia_502ag(SE_Familia_502ag familia_502ag)
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                using (SqlCommand cmd_502ag = new SqlCommand($"SELECT * FROM FamiliaFamilia_502ag WHERE NombrePadre_502ag = @NombrePadre_502ag", cx_502ag))
                {
                    cmd_502ag.Parameters.AddWithValue("@NombrePadre_502ag", familia_502ag.Nombre_502ag);
                    using (SqlDataReader dr_502ag = cmd_502ag.ExecuteReader())
                    {
                        while (dr_502ag.Read())
                        {
                            SE_Perfil_502ag familiaHijo_502ag = new SE_Familia_502ag(dr_502ag["NombreHijo_502ag"].ToString());
                            familia_502ag.Agregar_502ag(familiaHijo_502ag);
                        }
                    }
                }
                return familia_502ag;
            }
        }


        public bool FamiliaEsHijo_502ag(SE_Familia_502ag familiaHijo_502ag, SE_Familia_502ag familiaPadre_502ag)
        {
            bool noSePuedeDarDeAlta_502ag = false;
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                using (SqlCommand cmd_502ag = new SqlCommand("SELECT * FROM FamiliaFamilia_502ag WHERE NombrePadre_502ag = @NombrePadre_502ag", cx_502ag))
                {
                    cmd_502ag.Parameters.AddWithValue("@NombrePadre_502ag", familiaHijo_502ag.Nombre_502ag);
                    using (SqlDataReader dr_502ag = cmd_502ag.ExecuteReader())
                    {
                        while (dr_502ag.Read())
                        {
                            if (dr_502ag["NombreHijo_502ag"].ToString() == familiaPadre_502ag.Nombre_502ag)
                            {
                                noSePuedeDarDeAlta_502ag = true;
                                break;
                            }
                            else
                            {
                                SE_Familia_502ag familia_502ag = new SE_Familia_502ag(dr_502ag["NombreHijo_502ag"].ToString());
                                noSePuedeDarDeAlta_502ag = FamiliaEsHijo_502ag(familia_502ag, familiaPadre_502ag);
                            }   
                        }
                    }
                }
            }
            return noSePuedeDarDeAlta_502ag;
        }

        public SE_Familia_502ag ObtenerFamiliasDeFamilia_502ag(SE_Familia_502ag familiaPadre_502ag)
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                using (SqlCommand cmd_502ag = new SqlCommand("SELECT * FROM FamiliaFamilia_502ag WHERE NombrePadre_502ag = @NombrePadre_502ag", cx_502ag))
                {
                    cmd_502ag.Parameters.AddWithValue("@NombrePadre_502ag", familiaPadre_502ag.Nombre_502ag);
                    using (SqlDataReader dr_502ag = cmd_502ag.ExecuteReader())
                    {
                        while (dr_502ag.Read())
                        {
                            SE_Perfil_502ag familia_502ag = new SE_Familia_502ag(dr_502ag["NombreHijo_502ag"].ToString());
                            familiaPadre_502ag.Agregar_502ag(familia_502ag);
                        }
                    }
                }
            }
            return familiaPadre_502ag;
        }
    }
}
