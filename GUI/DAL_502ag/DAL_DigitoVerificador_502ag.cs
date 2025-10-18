using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_502ag
{
    public class DAL_DigitoVerificador_502ag
    {

        public void ActualizarDigitos_502ag(string nombreTabla_502ag, string dvh_502ag, string dvv_502ag)
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                string updateQuery_502ag = $"UPDATE DigitoVerificador_502ag SET DVH_502ag = @DVH_502ag, DVV_502ag = @DVV_502ag WHERE NombreTabla_502ag = @NombreTabla_502ag";
                using (SqlCommand cmd_502ag = new SqlCommand(updateQuery_502ag, cx_502ag))
                {
                    cmd_502ag.Parameters.AddWithValue("@DVH_502ag", dvh_502ag);
                    cmd_502ag.Parameters.AddWithValue("@DVV_502ag", dvv_502ag);
                    cmd_502ag.Parameters.AddWithValue("@NombreTabla_502ag", nombreTabla_502ag);
                    cmd_502ag.ExecuteNonQuery();
                }  
            }
        }

        public string ObtenerDVH_502ag(string nombreTabla_502ag)
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                using (SqlCommand cmd_502ag = new SqlCommand("SELECT DVH_502ag FROM DigitoVerificador_502ag WHERE NombreTabla_502ag = @NombreTabla_502ag", cx_502ag))
                {
                    cmd_502ag.Parameters.AddWithValue("@NombreTabla_502ag", nombreTabla_502ag);
                    using (SqlDataReader dr_502ag = cmd_502ag.ExecuteReader())
                    {
                        if (dr_502ag.Read())
                        {
                            return dr_502ag["DVH_502ag"].ToString();
                        }
                    }
                }
            }
            return null;
        }

        public string ObtenerDVV_502ag(string nombreTabla_502ag)
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                using (SqlCommand cmd_502ag = new SqlCommand("SELECT DVV_502ag FROM DigitoVerificador_502ag WHERE NombreTabla_502ag = @NombreTabla_502ag", cx_502ag))
                {
                    cmd_502ag.Parameters.AddWithValue("@NombreTabla_502ag", nombreTabla_502ag);
                    using (SqlDataReader dr_502ag = cmd_502ag.ExecuteReader())
                    {
                        if (dr_502ag.Read())
                        {
                            return dr_502ag["DVV_502ag"].ToString();
                        }
                    }
                }
            }
            return null;
        }


    }
}
