using BE_502ag;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_502ag
{
    public class DAL_RepuestoOrdenTrabajo_502ag
    {
        public void AltaIntermedia_502ag(string codOT_502ag, int codRepuesto_502ag, int cantidad_502ag)
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                string insertQuery = $"INSERT INTO RepuestoOrdenTrabajo_502ag (CodigoOT_502ag, CodigoRepuesto_502ag, Cantidad_502ag) VALUES (@CodigoOT_502ag, @CodigoRepuesto_502ag, @Cantidad_502ag)";
                using (SqlCommand cmd_502ag = new SqlCommand(insertQuery, cx_502ag))
                {
                    cmd_502ag.Parameters.AddWithValue("@CodigoOT_502ag", codOT_502ag);
                    cmd_502ag.Parameters.AddWithValue("@CodigoRepuesto_502ag", codRepuesto_502ag);
                    cmd_502ag.Parameters.AddWithValue("@Cantidad_502ag", cantidad_502ag);
                    cmd_502ag.ExecuteNonQuery();
                }
            }
        }
        public void BajaIntermedia_502ag(string codOT_502ag, int codRepuesto_502ag)
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                string deleteQuery = $"DELETE FROM RepuestoOrdenTrabajo_502ag WHERE CodigoOT_502ag = @CodigoOT_502ag AND CodigoRepuesto_502ag = @CodigoRepuesto_502ag";
                using (SqlCommand cmd_502ag = new SqlCommand(deleteQuery, cx_502ag))
                {
                    cmd_502ag.Parameters.AddWithValue("@CodigoOT_502ag", codOT_502ag);
                    cmd_502ag.Parameters.AddWithValue("@CodigoRepuesto_502ag", codRepuesto_502ag);
                    cmd_502ag.ExecuteNonQuery();
                }
            }
        }

        public void ModificarIntermedia_502ag(string codOT_502ag, int codRepuesto_502ag, int cantidad_502ag)
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                string updateQuery = $"UPDATE RepuestoOrdenTrabajo_502ag SET Cantidad_502ag = @Cantidad_502ag WHERE CodigoOT_502ag = @CodigoOT_502ag AND CodigoRepuesto_502ag = @CodigoRepuesto_502ag";
                using (SqlCommand cmd_502ag = new SqlCommand(updateQuery, cx_502ag))
                {
                    cmd_502ag.Parameters.AddWithValue("@CodigoOT_502ag", codOT_502ag);
                    cmd_502ag.Parameters.AddWithValue("@CodigoRepuesto_502ag", codRepuesto_502ag);
                    cmd_502ag.Parameters.AddWithValue("@Cantidad_502ag", cantidad_502ag);
                    cmd_502ag.ExecuteNonQuery();
                }
            }
        }

        public List<BE_RepuestoOrdenTrabajo_502ag> ObtenerDatosIntermedia_502ag(string codOT_502ag)
        {
            List<BE_RepuestoOrdenTrabajo_502ag> listaRepuestosOrdenTrabajo_502ag = new List<BE_RepuestoOrdenTrabajo_502ag>();
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                string selectQuery_502ag = $"SELECT * FROM RepuestoOrdenTrabajo_502ag WHERE CodigoOT_502ag = @CodigoOT_502ag";
                using (SqlCommand cmd_502ag = new SqlCommand(selectQuery_502ag, cx_502ag))
                {
                    cmd_502ag.Parameters.AddWithValue("@CodigoOT_502ag", codOT_502ag);
                    using (SqlDataReader dr_502ag = cmd_502ag.ExecuteReader())
                    {
                        while (dr_502ag.Read())
                        {
                            BE_RepuestoOrdenTrabajo_502ag nuevo_502ag = new BE_RepuestoOrdenTrabajo_502ag(
                                dr_502ag["CodigoOT_502ag"].ToString(),
                                int.Parse(dr_502ag["CodigoRepuesto_502ag"].ToString()),
                                int.Parse(dr_502ag["Cantidad_502ag"].ToString())
                                );
                            listaRepuestosOrdenTrabajo_502ag.Add(nuevo_502ag);
                        }
                    }
                }
            }
            return listaRepuestosOrdenTrabajo_502ag;
        }

        public List<BE_RepuestoOrdenTrabajo_502ag> ObtenerTodosLosDatosIntermedia_502ag()
        {
            List<BE_RepuestoOrdenTrabajo_502ag> listaRepuestosOrdenTrabajo_502ag = new List<BE_RepuestoOrdenTrabajo_502ag>();
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                string selectQuery_502ag = $"SELECT * FROM RepuestoOrdenTrabajo_502ag";
                using (SqlCommand cmd_502ag = new SqlCommand(selectQuery_502ag, cx_502ag))
                {
                    using (SqlDataReader dr_502ag = cmd_502ag.ExecuteReader())
                    {
                        while (dr_502ag.Read())
                        {
                            BE_RepuestoOrdenTrabajo_502ag nuevo_502ag = new BE_RepuestoOrdenTrabajo_502ag(
                                dr_502ag["CodigoOT_502ag"].ToString(),
                                int.Parse(dr_502ag["CodigoRepuesto_502ag"].ToString()),
                                int.Parse(dr_502ag["Cantidad_502ag"].ToString())
                                );
                            listaRepuestosOrdenTrabajo_502ag.Add(nuevo_502ag);
                        }
                    }
                }
            }
            return listaRepuestosOrdenTrabajo_502ag;
        }
    }
}
