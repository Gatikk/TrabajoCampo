using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SE_502ag;

namespace DAL_502ag
{
    public class DAL_Perfil_502ag
    {
        public void AltaPerfil_502ag(SE_Familia_502ag perfil_502ag)
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                using(SqlCommand cmd_502ag = new SqlCommand("INSERT INTO Perfil_502ag (NombrePerfil_502ag) VALUES (@NombrePerfil_502ag)", cx_502ag))
                {
                    cmd_502ag.Parameters.AddWithValue("@NombrePerfil_502ag", perfil_502ag.Nombre_502ag);
                    cmd_502ag.ExecuteNonQuery();
                }
            }
        }
        public void BorrarPerfil_502ag(SE_Familia_502ag perfil_502ag)
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                using (SqlCommand cmd_502ag = new SqlCommand("DELETE FROM Perfil_502ag WHERE NombrePerfil_502ag = @NombrePerfil_502ag", cx_502ag))
                {
                    cmd_502ag.Parameters.AddWithValue("@NombrePerfil_502ag", perfil_502ag.Nombre_502ag);
                    cmd_502ag.ExecuteNonQuery();
                }
            }
        }

        public List<SE_Familia_502ag> ObtenerListaPerfiles_502ag()
        {
            List<SE_Familia_502ag> listaPerfiles_502ag = new List<SE_Familia_502ag>();
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                using(SqlCommand cmd_502ag = new SqlCommand("SELECT * FROM Perfil_502ag", cx_502ag))
                {
                    using(SqlDataReader dr_502ag = cmd_502ag.ExecuteReader())
                    {
                        while (dr_502ag.Read())
                        {
                            string nombre_502ag = dr_502ag["NombrePerfil_502ag"].ToString();
                            SE_Familia_502ag perfil_502ag = new  SE_Familia_502ag(nombre_502ag);
                            listaPerfiles_502ag.Add(perfil_502ag);

                        }
                    }
                }
            }
            return listaPerfiles_502ag;
        }
    }
}
