using SE_502ag;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_502ag
{
    public class DAL_Familia_502ag
    {
        public void AltaFamilia_502ag(SE_Familia_502ag familia_502ag)
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                using (SqlCommand cmd_502ag = new SqlCommand("INSERT INTO Familia_502ag (NombreFamilia_502ag) VALUES (@NombreFamilia_502ag)", cx_502ag))
                {
                    cmd_502ag.Parameters.AddWithValue("@NombreFamilia_502ag", familia_502ag.Nombre_502ag);
                    cmd_502ag.ExecuteNonQuery();
                }
            }
        }

        public void BorrarFamilia_502ag(SE_Familia_502ag familia_502ag)
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                using (SqlCommand cmd_502ag = new SqlCommand("DELETE FROM Familia_502ag WHERE NombreFamilia_502ag = @NombreFamilia_502ag",cx_502ag))
                {
                    cmd_502ag.Parameters.AddWithValue("@NombreFamilia_502ag", familia_502ag.Nombre_502ag);
                    cmd_502ag.ExecuteNonQuery();
                }
            }
        }

        public List<SE_Familia_502ag> ObtenerListaFamiliasCompleta_502ag()
        {
            List<SE_Familia_502ag> listaFamilias_502ag = new List<SE_Familia_502ag>();
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                using (SqlCommand cmd_502ag = new SqlCommand("SELECT * FROM Familia_502ag", cx_502ag))
                {
                    using (SqlDataReader dr_502ag = cmd_502ag.ExecuteReader())
                    {
                        while (dr_502ag.Read())
                        {
                            string nombreFamilia_502ag = dr_502ag["NombreFamilia_502ag"].ToString();
                            SE_Familia_502ag familia_502ag = new SE_Familia_502ag(nombreFamilia_502ag);
                            listaFamilias_502ag.Add(familia_502ag);
                        }
                    }
                }
            }
            return listaFamilias_502ag;
        }
    }
}
