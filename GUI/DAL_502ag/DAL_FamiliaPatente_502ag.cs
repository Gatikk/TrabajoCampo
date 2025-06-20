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
