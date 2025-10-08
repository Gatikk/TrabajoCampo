using BE_502ag;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_502ag
{
    public class DAL_Repuesto_502ag
    {
        public List<BE_Repuesto_502ag> ObtenerRepuestos_502ag()
        {
            List<BE_Repuesto_502ag> listaRepuestos_502ag = new List<BE_Repuesto_502ag>();
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                using (SqlCommand cmd_502ag = new SqlCommand("SELECT * FROM Repuesto_502ag", cx_502ag))
                {
                    cx_502ag.Open();
                    using (SqlDataReader dr_502ag = cmd_502ag.ExecuteReader())
                    {
                        while (dr_502ag.Read())
                        {
                            BE_Repuesto_502ag repuesto_502ag = new BE_Repuesto_502ag(
                                int.Parse(dr_502ag["Codigo_502ag"].ToString()),
                                dr_502ag["Descripcion_502ag"].ToString(),
                                decimal.Parse(dr_502ag["Precio_502ag"].ToString()),
                                int.Parse(dr_502ag["CantidadDisponible_502ag"].ToString())
                                );
                            listaRepuestos_502ag.Add(repuesto_502ag);
                        }
                    }
                }
            }
            return listaRepuestos_502ag;
        }
        public BE_Repuesto_502ag ObtenerRepuesto_502ag(int codRepuesto_502ag)
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                using (SqlCommand cmd_502ag = new SqlCommand("SELECT * FROM Repuesto_502ag WHERE Codigo_502ag = @Codigo_502ag", cx_502ag))
                {
                    cx_502ag.Open();
                    cmd_502ag.Parameters.AddWithValue("@Codigo_502ag", codRepuesto_502ag);
                    using (SqlDataReader dr_502ag = cmd_502ag.ExecuteReader())
                    {
                        if (dr_502ag.Read())
                        {
                            return new BE_Repuesto_502ag(
                                int.Parse(dr_502ag["Codigo_502ag"].ToString()),
                                dr_502ag["Descripcion_502ag"].ToString(),
                                decimal.Parse(dr_502ag["Precio_502ag"].ToString()),
                                int.Parse(dr_502ag["CantidadDisponible_502ag"].ToString())
                            );
                        }
                    }
                }
            }
            return null;
        }
        #region AltaRepuesto
        public void AltaRepuesto_502ag(BE_Repuesto_502ag repuesto_502ag)
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                string insertQuery_502ag = "INSERT INTO Repuesto_502ag (Descripcion_502ag, Precio_502ag, CantidadDisponible_502ag)" +
                    "VALUES (@Descripcion_502ag, @Precio_502ag, @CantidadDisponible_502ag)";
                using (SqlCommand cmd_502ag = new SqlCommand(insertQuery_502ag, cx_502ag))
                {
                    cmd_502ag.Parameters.AddWithValue("@Descripcion_502ag", repuesto_502ag.Descripcion_502ag);
                    cmd_502ag.Parameters.AddWithValue("@Precio_502ag", repuesto_502ag.Precio_502ag);
                    cmd_502ag.Parameters.AddWithValue("@CantidadDisponible_502ag", repuesto_502ag.CantidadDisponible_502ag);
                    cmd_502ag.ExecuteNonQuery();
                }
            }
        }
        #endregion
        #region ModificarRepuesto
        public void ModificarRepuesto_502ag(BE_Repuesto_502ag repuesto_502ag)
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                string updateQuery_502ag = "UPDATE Repuesto_502ag SET Descripcion_502ag = @Descripcion_502ag, Precio_502ag = @Precio_502ag, " +
                    "CantidadDisponible_502ag = @CantidadDisponible_502ag WHERE Codigo_502ag = @Codigo_502ag";
                using (SqlCommand cmd_502ag = new SqlCommand(updateQuery_502ag, cx_502ag))
                {
                    cmd_502ag.Parameters.AddWithValue("@Codigo_502ag", repuesto_502ag.Codigo_502ag);
                    cmd_502ag.Parameters.AddWithValue("@Descripcion_502ag", repuesto_502ag.Descripcion_502ag);
                    cmd_502ag.Parameters.AddWithValue("@Precio_502ag", repuesto_502ag.Precio_502ag);
                    cmd_502ag.Parameters.AddWithValue("@CantidadDisponible_502ag", repuesto_502ag.CantidadDisponible_502ag);
                    cmd_502ag.ExecuteNonQuery();
                }
            }
        }
        #endregion
        #region BajaRepuesto
        public void BajaRepuesto_502ag(BE_Repuesto_502ag repuesto_502ag)
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                string deleteQuery_502ag = "DELETE FROM Repuesto_502ag WHERE Codigo_502ag = @Codigo_502ag";
                using (SqlCommand cmd_502ag = new SqlCommand(deleteQuery_502ag, cx_502ag))
                {
                    cmd_502ag.Parameters.AddWithValue("@Codigo_502ag", repuesto_502ag.Codigo_502ag);
                    cmd_502ag.ExecuteNonQuery();
                }
            }
        }
        #endregion
        
    }
}
